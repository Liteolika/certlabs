# Message base solutions



## Azure Queue Storage

- Requires an Azure Storage Account (GPv2)
- Queues are created within a single storage account
- Supports messages up to 64KiB (kibibytes) in size (equals to 65.536 kilobytes)
- Messages exist within a single queue
- Number of messages limited only by size of the storage account*
- Supports a configurable TTL per message (with default 7 days)
- Data redundancy is equal to the storage account (GRS, LRS etc.)

### Queue URL Structure

https://[storageaccount].queue.core.windows.net/[queue-name]

### Queue Security

- Data in queues is encrypted by default
- Azure Storage stored access policies can work with queues
- Interaction with queue data are done via HTTP or HTTPS
- Supportes the following authorization approaches
  - Shared key
  - Shared access signature (SAS)
  -  Azure AD



Visibility timeout is configurable for a queue

### Scalability limits for queues

- A single queue cannot exceed 500 TiB (70 terrabytes)
- A single message cannot exceed 64KiB (kibibytes)
- A queue supports no more than 5 stored access policies
- A storage account can support 20.000 messages per second (1 KiB message)
- A single queue can support 2000 messages per second (1 KiB message)



### Manage with Azure CLI

```bash
az storage account create --name petermessstore -g mess --sku Standard_LRS
```

```bash
az storage queue create --name messes --account-name petermessstore
```

```bash
az storage message peek --account-name petermessstore --queue-name messes --num-messages 32
```


Max is 32. Does not affect the queue.

```bash
az storage message clear --account-name petermessstore --queue-name messes
```

```bash
az storage queue delete --account-name petermessstore --name messes
```



# Azure Service Bus

"Fully-managed enterprise message broker service that enables multiple modes of messaging
with integrations for common messaging systems including Java Message Service (JMS)"

https://[namespace].servicebus.windows.net/[queue-or-topic-name]

**Supports FIFO (first-in-first-out)**

**Supports Dead-letter Queue (DLQ)** for queues and topics. This enables you to captures messages that were not processed during their lifetime, and act accordingly with those messages.

### Organization

- Namespace
  - Queue (One producer, one consumer)
  - Topic (One publisher, multiple subscribers) 
    - Can be filtered so that some subscribers only see some messages

#### Features

- Supports both HTTP/HTTPS and AMQP protocols
- Includes messaging for both queues and topics
- At namespace level it supports the following performance tiers: Basic, Standard and Premium
- Supports advanced configurability
  - Ordering of messages 
  - Batching
  - Dead letter queue (DLQ)
  - Duplicate detection (Checks that it hasn't been processed by another consumer)

### Tiers

- Basic Tier
  - The basic tier of Azure Service Bus only supports queues (not topics). To fully utilize the functionality of this service, it is recommended to use the standard or premium tier.
- Standard Tier
  - "Pay as you go" pricing
  - Throughput is variable and has variable latency
  - Utilizes shared resources
  - Provides automatic scaling
  - Supports messages up to 256 KB
  - Does not support geo-disaster recovery or availability zones
- Premium Tier
  - Fixed pricing based on messaging units
  - Throughput is fixed based on messaging units
  - Utilizes dedicated resources
  - Requires configuration of scaling rules
  - Supports messages up to 1 MB
  - Supports geo-disaster recovery and availability zones

### Scaling

- Standard tier namespaces support partitioning of queues and topics
- Partitioning is not supported for premium tier namespaces
- Partitioning enables separate messaging stores and brokers for a single entity
- Partitioned queues and topics can us a partition key to determine the partition
- Without a partition key, a round-robin algorithm is leveraged by Azure
- Transactions on partitioned entity must use a partition key



### Azure Queue Solutions

- Azure Queue Storage Use Cases
  - Total storage for queue needs to be over 80GB
  - Logs needed for all transactions executed against queue
  - Need to track progress of message processing
- Azure Service Bus Use Cases
  - Need support for receiving messages without polling (with AMQP 1.0)
  - There is a need to guarantee message processing order (FIFO)
  -  There is a need to detect duplicate messages
  - You need to support messages up to 256 KB
  - You may need to support topic based notifications (one to many)
  - You need to support publishing and consuming in batches

### Azure Service Bus Topics

Enables a one-to-many relationship between messages and consumers

A consumer creates a subscription to a topic

Subscriptions act as dedicated queues for a subscriber with configuration options. Each subscriber gets their own "virtual" queue.

Topic filters can be specified as:

- Boolean filters
- SQL filters
- Correlation filters



### Azure CLI commands

az servicebus namespace create --resource-group mess --name asbpeters  --sku Standard

az servicebus queue create --namespace-name asbpeters --name testqueue  --resource-group mess

az servicebus queue delete --namespace-name asbpeters --name testqueue  --resource-group mess

az servicebus topic create --namespace-name asbpeters --name testtopic --resource-group mess

az servicebus topic delete --namespace-name asbpeters --name testtopic --resource-group mess

az servicebus topic subscription create --namespace-name asbpeters --name testsub --topic-name testtopic --resource-group mess





















