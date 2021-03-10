# Logic Apps

Build powerful integrations. 

Exchange data between disparate systems.

Has a large collection of pre-built customizable components.





Creating flow

Working with logic apps in Portal and VS using a designer. 

Can be deployed from Azure CLI but it needs a workload definition file.



### Components

- Workflow
  - Trigger - Has a managed connector to integrate with data
  - Action - Has a managed connector to integrate with data

### Triggers

- Scheduled triggers
  - Start date and fixed interval.
    - Recurrence - Will not re run missed occurrences)
    - Sliding Window Trigger - Process data in contiguous chunks. Re runs missed occurrences.
- Polling trigger (polling timers)
- Push trigger (webhook)

- ### Connectors

- Built-in connectors

- Managed connectors

  - Provided by Microsoft
  - Provides access to services

- On-premises connectors

- Integration account connectors



### Making decisions

Add the logic to logic apps.

Control the execution flow.

- Six inbuilt control actions
  - Condition
  - For Each
  - Switch
  - Until
  - Scope (group actions in execution scope)
  - Terminate











