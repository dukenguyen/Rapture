# RestServer

### Overview ###
This is a Rapture application that exposes various document, blob, and series Rapture API calls using a REST interface.  It listens on port 4567.

### System Diagram ###
![System Diagram](/Apps/RestServer/images/restserver.png)

# Installation and Running #

## Using Docker ##
The entire setup can be run using all docker containers.  This is the easiest way to run the stack without doing builds or compiling.  Here are the relevant commands.

**Start RabbitMQ**
```
docker run -d -p 5672:5672 -p 15672:15672 --name rabbit incapture/rabbit
```
**Start MongoDB**
```
docker run -d -p 27017:27017 --name mongo incapture/mongo
```
**Start ElasticSearch**
```
docker run -d -p 9300:9300 -p 9200:9200 --name elasticsearch incapture/elasticsearch
```
**Start Postgres**
```
docker run -d -p 5432:5432 --name postgres incapture/postgres
```
**Start RestServer**
```
docker run -d -p 4567:4567 --link mongo --link rabbit --link elasticsearch --link postgres --name restserver incapture/restserver
```
The RestServer REST API will be available at [http://localhost:4567](http://localhost:4567) or http://192.168.99.100:4567 or equivalent depending on your docker configuration (native or virtual).

# REST API #
* [Login](#login) 
* [Document](#document)
* [Blob](#blob) 
* [Series](#series)

<a name="login"/>
**Login**
```
POST /login
Body: {"username":"user1", "password":"somepassword"}
```
Response:
```
HTTP 200: session_id
```
<a name="document"/>
**Create a document repo**
```
POST /doc/:authority
Example: /doc/mydocs
Body: {"config":"NREP USING MONGODB {prefix=\"mydocs\"}"}
```
Response:
```
HTTP 200: document://mydocs
```
**Create/Update a document**
```
PUT /doc/:uri
Example: /doc/mydocs/a
Body: {"a":"b"}
```
Response:
```
HTTP 200: {"a":"b"}
```
**Get a document**
```
GET /doc/:uri
Example: /doc/mydocs/a
```
Response:
```
{"a":"b"}
```
**Get a document's meta information**
```
GET /doc/:uri?meta=true
Example: /doc/mydocs/a?meta=true
```
Response:
```
{"displayName":"a","metaData":{"version":2,"createdTimestamp":1471973694426,"modifiedTimestamp":1471973722727,"user":"rapture","comment":"","deleted":false,"tags":{},"semanticUri":""},"content":"{\"a\":\"b\"}"}
```
**Get a document using versions**
```
GET /doc/:uri
Example: /doc/mydocs/a@2
```
Response:
```
{"a":"b"}
```
**Delete a document**
```
DELETE /doc/:uri
Example: /doc/mydocs/a
```
Response:
```
HTTP 200: true
```
**Delete a document repo**
```
DELETE /doc/:authority
Example: /doc/mydocs
```
Response:
```
HTTP 200: true
```
<a name="blob"/>
**Create a blob repo**
```
POST /blob/:authority
Example: /blob/myblobs
Body: {"config":"BLOB USING MONGODB {prefix=\"mydocs\"}", "metaConfig":"REP USING MONGODB {prefix=\"mydocs\"}"}
```
Response:
```
HTTP 200: blob://myblobs
```
**Create/Update a blob**
```
PUT /blob/:uri
Content-Type: :mime-type
Example: /blob/myblobs/a
Content-Type: text/plain
Body: some text value
```
Response:
```
HTTP 200: blob://myblobs/a
```
**Get a blob**
```
GET /blob/:uri
Example: /blob/myblobs/a
```
Response:
```
{"headers":{"Content-Length":"14","Content-Type":"text/plain"},"content":[97,32,115,116,114,105,110,103,32,118,97,108,117,101]}
```
**Delete a blob**
```
DELETE /blob/:uri
Example: /blob/myblobs/a
```
Response:
```
HTTP 200: true
```
**Delete a blob repo**
```
DELETE /blob/:authority
Example: /blob/myblobs
```
Response:
```
HTTP 200: true
```
<a name="series"/>
**Create a series repo**
```
POST /series/:authority
Example: /series/myseries
Body: {"config":"SREP USING MONGODB {prefix=\"myseries\"}"}
```
Response:
```
HTTP 200: series://myseries
```
**Create/Update a series**
```
PUT /series/:uri
Example: /series/myseries/a
Body: {"keys":["k1", "k2"], "values":["v1", "v2"]}
```
Response:
```
HTTP 200: series://myseries/a
```
**Get a series points**
```
GET /series/:uri
Example: /series/myseries/a
```
Response:
```
[{"column":"k1","value":"v1"},{"column":"k2","value":"v2"}]

```
**Delete a series**
```
DELETE /series/:uri
Example: /series/myseries/a
```
Response:
```
HTTP 200: true
```
**Delete a document repo**
```
DELETE /series/:authority
Example: /series/myseries
```
Response:
```
HTTP 200: true
```
# REST API Examples #
Refer to the integration test [here](src/integrationTest/java/rapture/server/rest)