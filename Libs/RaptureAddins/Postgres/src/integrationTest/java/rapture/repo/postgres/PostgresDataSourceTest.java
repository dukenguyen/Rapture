/**
 * Copyright (C) 2011-2015 Incapture Technologies LLC
 *
 * This is an autogenerated license statement. When copyright notices appear below
 * this one that copyright supercedes this statement.
 *
 * Unless required by applicable law or agreed to in writing, software is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
 * or implied.
 *
 * Unless explicit permission obtained in writing this software cannot be distributed.
 */
package rapture.repo.postgres;

import static org.junit.Assert.*;

import java.beans.PropertyVetoException;
import java.sql.Connection;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import rapture.kernel.TransactionManager;
import rapture.postgres.PostgresFactory;
import rapture.repo.jdbc.TransactionAwareDataSource;

/**
 * Created by yanwang on 4/21/15.
 */
public class PostgresDataSourceTest {
    private static final int MAX_POOL_SIZE = 15;
    private TransactionAwareDataSource dataSource;

    @Before
    public void setup() throws PropertyVetoException {
        dataSource = PostgresFactory.getDataSource("default");
        assertNull(TransactionManager.getActiveTransaction());
    }

    @After
    public void after() {
        assertNull(TransactionManager.getActiveTransaction());
    }

    private class TransactionThread implements Runnable {
        private String transactionId;
        private boolean doCommit;

        public TransactionThread(String transactionId, boolean doCommit) {
            this.transactionId = transactionId;
            this.doCommit = doCommit;
        }

        @Override
        public void run() {
            try {
                begin(transactionId);
                Connection connection = dataSource.getConnection();
                assertFalse(dataSource.shouldClose(connection));
                assertFalse(connection.getAutoCommit());

                if(doCommit) {
                    commit(transactionId);
                    assertTrue(dataSource.shouldClose(connection));
                    assertTrue(connection.isClosed());
                }
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    private class GetConnectionThread implements Runnable {
        private String transactionId;
        private Connection connection;

        public GetConnectionThread(String transactionId) {
            this.transactionId = transactionId;
        }

        public Connection getConnection() {
            return connection;
        }

        @Override
        public void run() {
            try {
                TransactionManager.registerThread(transactionId);
                connection = dataSource.getConnection();
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    @Test
    public void testSameTransactionSameConnection() throws SQLException, InterruptedException {
        // different threads bound to the same transaction should get the same connection
        final String transactionId = getTransactionId(MAX_POOL_SIZE);
        begin(transactionId);
        Connection connection = null;
        for(int i = 0; i < 3; i++) {
            GetConnectionThread thread = new GetConnectionThread(transactionId);
            runInThread(thread);
            if(connection == null) {
                connection = thread.getConnection();
            } else {
                assertEquals(connection, thread.getConnection());
            }
        }
        rollback(transactionId);
        assertTrue(connection.isClosed());
    }

    @Test
    public void testSingleThreadMultiTransaction() throws InterruptedException {
        runInThread(new Runnable() {
            @Override
            public void run() {
                try {
                    getNonTransactionalConnection();
                    getTransactionalConnection("tx111");
                    getNonTransactionalConnection();
                    getTransactionalConnection("tx222");
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }
        });
    }

    @Test
    public void testTransactionalConnection() throws InterruptedException, SQLException {
        for(int i = 0; i < 2 * MAX_POOL_SIZE; i++) {
            runInThread(new TransactionThread(getTransactionId(i), true));
        }
    }

    @Test
    public void testNonTransactionalConnection() throws SQLException, InterruptedException {
        // use half of the pool connections for transactions
        for (int i = 0; i < MAX_POOL_SIZE / 2; i++) {
            runInThread(new TransactionThread(getTransactionId(i), false));
        }
        // check connections for non-transactions are not transactional
        for (int i = 0; i < MAX_POOL_SIZE; i++) {
            getNonTransactionalConnection();
        }
        for (int i = 0; i < MAX_POOL_SIZE / 2; i++) {
            rollback(getTransactionId(i));
        }
    }

    @Test
    public void testExhaustPoolWithTransactions() throws SQLException, InterruptedException {
        // start transactions that will exhaust the pool
        for (int i = 0; i < MAX_POOL_SIZE; i++) {
            runInThread(new TransactionThread(getTransactionId(i), false));
        }
        shouldFailToGetConnection();
        // rollback all transactions
        for(int i = 0; i < MAX_POOL_SIZE; i++) {
            rollback(getTransactionId(i));
        }
        getNonTransactionalConnection();
    }

    @Test
    public void testExhaustPoolWithNonTransactions() throws SQLException {
        // get all the connections from pool
        List<Connection> connections = new ArrayList<>();
        for (int i = 0; i < MAX_POOL_SIZE; i++) {
            connections.add(dataSource.getConnection());
        }
        shouldFailToGetConnection();
        // close all connections
        for(Connection connection : connections) {
            connection.close();
        }
        getNonTransactionalConnection();
    }

    private void shouldFailToGetConnection() {
        try {
            dataSource.getConnection();
            fail("Should have failed to get connection");
        } catch (SQLException e) {
            assertEquals("An attempt by a client to checkout a Connection has timed out.", e.getMessage());
        }
    }

    private void begin(String transactionId) {
        TransactionManager.begin(transactionId);
        TransactionManager.registerThread(transactionId);
    }

    private void commit(String transactionId) throws SQLException {
        TransactionManager.commit(transactionId);
        dataSource.commit(transactionId);
    }

    private void rollback(String transactionId) throws SQLException {
        TransactionManager.rollback(transactionId);
        dataSource.rollback(transactionId);
    }

    private void getNonTransactionalConnection() throws SQLException {
        Connection connection = dataSource.getConnection();
        assertTrue(connection.getAutoCommit());
        assertTrue(dataSource.shouldClose(connection));

        connection.close();
        assertTrue(connection.isClosed());
    }

    private void getTransactionalConnection(String transactionId) throws SQLException {
        begin(transactionId);
        Connection connection = dataSource.getConnection();
        assertFalse(connection.getAutoCommit());
        assertFalse(dataSource.shouldClose(connection));

        commit(transactionId);
        assertTrue(connection.isClosed());
    }

    private void runInThread(Runnable runnable) throws InterruptedException {
        Thread thread = new Thread(runnable);
        thread.start();
        thread.join();
    }

    private String getTransactionId(int i) {
        return "tx_" + i;
    }

}
