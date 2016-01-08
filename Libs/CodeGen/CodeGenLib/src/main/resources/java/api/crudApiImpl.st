/**
 * Copyright (C) 2011-2013 Incapture Technologies LLC
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
package <package>;

import java.util.List;
import <typePackage>.<name>;
import rapture.common.CallingContext;
import rapture.common.RaptureURI;
import rapture.object.storage.CrudStorableInfo;
import rapture.object.storage.ObjectStorage;
import rapture.persistence.storable.mapper.impl.jackson.StorableObjectMapper;
import rapture.repo.Repository;
import rapture.kernel.Kernel;
import org.apache.log4j.Logger;
import rapture.common.RaptureFolderInfo;
import static rapture.common.Scheme.DOCUMENT;

public class <name>ApiImpl extends <name>ApiBase {
    private static Logger log = Logger.getLogger(<name>ApiImpl.class);
    
    @Override
    public <name> get<name>(CallingContext context, String uri) {
        log.info("Attempting to retrieve crud document at " + uri);
        RaptureURI theRealUri = new RaptureURI(uri);
        log.info("Crud document storage at " + theRealUri.getDocPath());
        return ObjectStorage.read(theRealUri, <name>.class, new CrudStorableInfo(), StorableObjectMapper.getMapper());
    }

    @Override
    public Boolean delete<name>(CallingContext context, String uri) {
        ObjectStorage.delete(context.getUser(), new RaptureURI(uri), null);
        return true;
    }

    @Override
    public <name> put<name>(CallingContext context, <name> content) {
        RaptureURI storageLocation = content.getStorageLocation();
        log.info("Crud document storage at " + storageLocation.getDocPath());
        ObjectStorage.write(content, context.getUser(), new CrudStorableInfo(), "Adding", StorableObjectMapper.getMapper());
        return content;
    }

    @Override
    public List\<RaptureFolderInfo\> getChildren(CallingContext context, String uri) {
        RaptureURI internalURI = new RaptureURI(uri, DOCUMENT);
        Repository repo = Kernel.INSTANCE.getRepo(internalURI.getAuthority());
        String area = internalURI.getDocPath() == null ? "" : internalURI.getDocPath();
        log.info("Loading children from repo " + internalURI.getAuthority() + " with area: " + area);
        return repo.getChildren(area);
    }
}