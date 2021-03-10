# Connect To and Consume Azure Services and Third-Party Services



## Objectives

#### Develop an App Service Logic App

- Create Logic App
- Create a customer connector for Logic Apps
- Create a custom template for Logic Apps

##### Authoring Approaches

Azure Portal

IDE (VS, VS Code)

CLI (Azure CLI, Powershell)

##### Key Terms

Workflow  - Trigger - Actions - Connector

- Connectors
  - Built-in - Enables Logic Apps to access Azure Services
  - Managed - Connectors are created and managed by Microsoft
  - Custom - Created by you to integrate with e.g. internal systems

##### Enterprise Integration Pack

Microsoft provides tools to integrate Logic Apps with common enterprise tools such as Electronic Data Interchange (EDI) and Enterprise Application Integration (EAI)

Utilizes an integration account to store artifacts.



#### Implementing API Management (APIM)

- Create an APIM instance
- Configure authentication for APIs
- Define policies for APIs

##### Service Tiers

Consumption - Per call - Shared hardware

Developer - Testing and validation

Basic - SLA

Standard - Azure AD integration

Premium - Increased SLA, multi region deployments

*Isolated - Preview*

##### Caching

- Internal cache - Provided within the APIM service
  - Limited in size base on the APIM tier
  - Not available on the consumption tier for APIM
- External - Redis compatible cache outside of APIM, such as Azure Cache for Redis

Both type of caching are configured in the APIM policies.

##### Access restrictions and authentication

- Access Restriction
  - Limiting access to an API based on specific settings
  - Checking an HTTP header for existence and value
  - Limit call rate by subscription and key
  - Restrict by IP address
  - Usage quotas per key
  - Validate JWT
- Authentication
  - Verify credentials for a caller of an API
  - Basic Auth
  - Client Ceritificate Auth
  -  Managed Identity Auth



##### Policy definition

API Management Policy

```xml
<policies>
    <inbound>
        <base />
        <cache-lookup vary-by-developer="false" vary-by-developer-groups="false" caching-type="internal">
            <vary-by-query-parameters>v</vary-by-query-parameters>
        </cache-lookup>
    </inbound>
    <outbound>
        <cache-store duration="60" />
        <base />
    </outbound>
</policies>
```





### Develop x-based Solutions

- **Events**
  - Lightweight notification of a state change
  - Publisher does not know (or care) how the message is handled
  - Follows a publisher/subscriber model
- **Messages**
  - Application data from a source system to be consumed elsewhere
  - There is an expectation that a message will be handled by a receiver
  - Can follow either a publisher/subscriber or a producer/consumer model

##### Event types

**Discrete Events** - Report state change from a system and enable subscribers to take action

**Series Events** - Report a condition and enable subscribers to analyse a condition over time



#### Selecting an Event-based service

- Does your solution have an expectation of how data is handled or does it contain app data? 
  If so, select a messaging service.
- Do you need a solution to send events to mobile devices as push notifications?
  Select Azure Notification Hub
- Does your solution produce discrete events, that report state changes that a system can act on?
  Select Azure Event Grid
- Does your solution report state over time for analysis by another system, such as in a data pipeline?
  Select Azure Event Hub



#### Develop Event-based Solutions

- Implement solutions that use Azure Event Grid
- Implement solutions that use Azure Notification Hubs
- Implement solutions that use Azure Event Hub



#### Develop Message-based Solutions

- Implement solutions that use Azure Service Bus
- Implement solutions that use Azure Queue Storage queues



##### Services Overview

- Azure Storage Queues
- Azure Service Bus
  - Topic filters
    - Boolean
    - Correlation
    - SQL



##### Interacting with Services using the CLI

Peek = Look without the visibility

##### Selecting a Message Service



1 

1 Inbound

2 outbound

3 internal

4 Authorization



2

Edit in Portal - Custom connector

3

Use Service Bus - Producer/Consumer pattern

4

Logic App - Enterprise Intergration Pack

5

Access Restrictions - JWT token

1 validate-jwt

2 openid-config

3 required-claims

6

Azure Service Bus









