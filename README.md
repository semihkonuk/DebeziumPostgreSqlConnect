## Debezium Example With Postgresql
This is a example project for CDC.

From project root directory, start up your application by running  `docker-compose up`

After that login to postgresql 

<pre><code>dokcer exec -it postgresqlContainerId bash</code></pre>

<pre><code>psql -d ExampleDb -U example -W`</code></pre>

Set wal_level as logical 

<pre><code>ALTER SYSTEM SET wal_level = logical;</code></pre>

Create a table named employee 

<pre><code>CREATE TABLE employee(id serial PRIMARY KEY,name varchar,lastname varchar);</code></pre>

Upload our configuration to the connector
<pre><code>curl -i -X POST -H "Accept:application/json" -H "Content-Type:application/json" localhost:8083/connectors/ --data "@debezium.json"
</code></pre>

![image3](https://user-images.githubusercontent.com/9461099/161401926-d2f10703-d635-4036-9ae7-774341d1c1f5.png)

<p>if see this result, connector created successfully. let's check the connector status, is it working</p>

<pre><code>curl localhost:8083/connectors/exampledb-connector/status</code></pre>

![image1](https://user-images.githubusercontent.com/9461099/161401917-ca0e2e66-9023-4aee-a846-c3eb1d8ef6c4.png)

follow console app log;
<pre><code>docker logs --follow consoleAppContainerId</code></pre>

or use kafka consumer 
<pre><code>kafka-console-consumer --bootstrap-server kafka:9092 --from-beginning --topic topicName --property print.key=true --property key.separator="-"</code></pre>

Now that consumer is watching the topic, we run an insert command and watch for output.
