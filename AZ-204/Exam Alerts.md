### Implement IaaS Solutions

- Provision VMs for remote access
- Create ARM templates
- Create container images for solutions by using Docker
- Publish an image to the Azure Container Registry (ACR)
- Run containers by using Azure Container Instance (ACI)
- *Azure Kubernetes Service (AKS) is OUT OF SCOPE!*

#### What to learn more

- Managed identities (system and user). Use PowerShell to do tasks (create, get passwords etc.)
- Backup & restore approaches for VMs.
- Accelerated Networking. Prevents latency and lag. Increase connectivity inside a vnet.
- When not use an Azure VM. Learn what is the most cost effective.



### Create Azure App Service Web Apps (most in exam)

- Create an Azure App Service Web App
- Enable diagnostics logging
- Deploy code to a web app
- Configure web app settings incl. SSL, API and connection strings
- Implement autoscaling rules, including autoscaling and scaling by operational or system metrics

#### What to learn more

- Understand the capabilities of each pricing tier

- Know the order of steps to create and deploy an application. 

- Fully understand deployment slots and slot swapping. Common challanges. When it make sense to use autoswap and not. Understand how to to things. Adding initialization steps.

- Know how to configure scaling and which tiers support which options.

- Know what use cases require the isolated tier.

- Understand the process of deploying containers.

- Accessing logs - Historical and real-time

- Review CLI commands (args not required)

- Azure App Service Environment (ASE) - Use in isolated network. 

- Custom warm-up for deployment slots - How to warm up before swapping to production.


##### AppService Tiers

- Free (F) 

- Shared (D) - Runs on shared VMs. Designed for development and testing. Metered on a per app basis.

- Basic (Bx) -  Not for production workload. No app scaling and traffic management. Supports instances. Does support loadbalancing between instances.

- Standard (Sx) - Production. Supports autoscaling. 

- Premium (PxVx) - Increased resources to the standard tier.

- Isolated (I) - Mission critical workload. Isolated vnet.


### Implement Azure Functions

- Implement input and output bindings for a function
- Implement function triggers by using data operations, timers and webhooks
- Implement Azure Durable Functions

#### What to learn more

- Understand the configuration of input and output bindings.

- Know the role Azure Functions fill architecturally

- Review integrations with other services (blob, servicebus, etc)

- Know what use cases Durable Functions are the best fit for

- Know how to access function metrics and logging information


##### Durable Functions App Patterns

- Function Chaining - Output from on action as input other action (complexed that needs to run in order)

- Fan-out/Fan-in - Refers to the pattern of executing multiple functions in parallel, and then waiting for all to finish. Often some aggregation work is done on results returned from the functions.

- Async HTTP API's - 

- Monitoring - Timers. Check to see when somethings are complete.

- Human interaction

- Aggregator (Stateful Entities)




