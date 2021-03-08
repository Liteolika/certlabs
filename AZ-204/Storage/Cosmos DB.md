### Azure Cosmos DB

##### Key features

- Integrated analytics
- Region support
- Schema-agnostic
- Automatic indexing
- Support multiple SDK's



##### DB Organization

- Cosmos DB Account (SQL API)
  - Database (App1)
    - Container (like table in trad. relational DB)
      - Item(s)
    - Container
  - Database (App2)
    - Container
      - Item(s)

​		

### Supported API's

Five different API's

- ##### SQL (default DB if nothing specified)

  - Core API 
  - You want to leverage a SQL-like language to query data
  - You want to store data as JSON documents
  - If no other use case fit, choose the SQL API

- ##### Cassandra

  - You have existing tooling/databases with Cassandra
  - Uses Cassandra Query Language (CQL)
  - You want to store data in a wide-column format (two dimensional key-value store)

- ##### MongoDB

  - You have existing tooling/databases with MongoDB
  - JSON document store

- ##### Gremlin

  - You need to store graph relationships between data
  - Product recommendations and social networks
  - Apache Tinkerpop's Gremlin language for querying relationships

- ##### Azure Table

  - Part of Azure Storage (differences in effect)
  - You want to query data using OData och LINQ queries



#### Database Entity

- SQL - Database
- Cassandra - Keyspace
- MongoDB - Database
- Gremlin - Database
- Azure Table - N/A

#### Container Entity

- SQL - Container
- Cassandra - Table
- MongoDB - Collection
- Gremlin - Graph
- Azure Table - Table



### Data Consistency Levels

"Distributed databases that rely on replication for high availability, low latency, or both, must
make a fundamental trade-off between the read consistency, availability, latency and throughput." (MS Doc)

#### Consistency Level Spectrum

**Eventual		Consistent Prefix		Session		Bounded Staleness		Strong**

​           <--------------------------------------------------------------------------------------------------->
Low Latency																										Higher Latency
Higher Throughput																							Lower Throughput
Higher Availability																							Lower Availability



- ##### Eventual

  - Write to connected node. Not replicated directly.
  - Provides no guarantee for the item update order.

- ##### Consistent Prefix

  - Guarantees that updates are returned in order.
  - When the order of item updates matter.

- ##### Session

  - Guarantees that a client session will read its own writes.

- ##### Bounded Staleness

  - Guarantees that a read has a max lag (either versions or time).
  - Gives a fairly recent version in the number of version or elapsed time.
  - Items are bound to the staleness of the data.

- ##### Strong

  - Guarantees that reads get the most recent version of an item.



### Consistency Levels for SQL API's

##### Account Default

Consistency level is set on the Cosmos DB account. Every operation will follow that level.

##### Request-specific level

Specific operation can override the account default.

### Consistency Levels and API's

For Gremlin and Azure Table API's, Cosmos DB uses account default consistency level.

For Cassandra writes, the account default consistency level is used.
For Cassandra reads, the client consistency is mapped to a Cosmos DB level.

For MongoDB, the write concern uses the account default consistency level.
For MongoDB, the reads concern will use a mapping to a Cosmos DB level.



#### Throughput considerations

Both strong and bounded staleness reads will consume twice the normal amount of request units for a request,
as Cosmos DB will need to query two replicas to meet the criteria of the consistency level.



## Partitioning

##### Logical Partition

A set of items within a container that share the same partition key. 
A container can have as many logical partitions as it needs, but each partition is limited to 20GB of storage.
Logical paritions are managed by Cosmos DB, but their use is governed by your partition key strategy.

##### Physical Partition

"A container is scaled by disitributing data and throughput across physical partitions. Internally, one or
more logical partitions are mapped to a single physical partition. They are entierly managed by Azure Cosmos DB."

##### Replica Set

A physical partition contains multiple replicas of the data, known as a replica set. By having this data replicated,
you enable your storage to be durable and fault tolerant. These replica sets are managed by Cosmos DB.

##### Partition Key

Serves as the means of routing your request to the correct partition.
Made up of both the key and the value of the defined partition key.
Should be a value that does not change for the item.
Should have many different values represented in the container.

"Azure Cosmos DB uses hash-based partitioning to spread logical partitions across physical partitions.
Azure Cosmos DB hashes the partition key value of an item. Then, Cosmos DB allocates the key space of partition key
hashes evenly across the physical partitions."




--------------------------------------------------

##### Strategy considerations

Throughput is distributed evenly across all of your physical partitions.
Multi-item transactions required triggers or stored procedures.
You will want to minimize cross-partition queries for heavier workloads.
Decide upon a partition key strategy before creating your container.