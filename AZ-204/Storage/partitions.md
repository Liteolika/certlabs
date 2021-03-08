### Logical Partition

A set of items within a container that share the same partition key. 
A container can have as many logical partitions as it needs, but each partition is limited to 20GB of storage.
Logical paritions are managed by Cosmos DB, but their use is governed by your partition key strategy.

### Physical Partition

"A container is scaled by disitributing data and throughput across physical partitions. Internally, one or
more logical partitions are mapped to a single physical partition. They are entierly managed by Azure Cosmos DB."

### Replica Set

A physical partition contains multiple replicas of the data, known as a replica set. By having this data replicated,
you enable your storage to be durable and fault tolerant. These replica sets are managed by Cosmos DB.

### Partition Key

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