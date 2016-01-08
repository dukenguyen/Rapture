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
package rapture.postgres;

import org.springframework.dao.DataAccessException;

/**
 * @author bardhi
 * @since 3/26/15.
 */
public class PostgresException extends Exception {
    public PostgresException(String message, DataAccessException cause) {
        super(message, cause);
    }
}
