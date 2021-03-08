### Implement user authentication and authorization

- Implement OAuth2 authentication
- Create and implement shared access signatures
- Register apps and use Azure AD to authenticate users
- Control access to resources by using role-base access controls (RBAC)

### Learn more about

##### App Manifest - Attributes to review

appRoles 

groupMembershipClaims

optionalClaims

oauth2AllowImplicitFlow

oauth2Permissions

signInAudience

##### Core Azure RBAC Concepts

Security Principal (Users, groups and also managed identities)

Role Definition (What can be done for a specific role)

Scope (What the role can be applied to)

Role Assignment (a definition of principal, role definition and scope)

##### Shared Access Signature types

User delegation (not using storage account key to sign signature, using AD credentials)
Currently only works with blob storage

Service SAS - Scoped to a specific service in your storage account such as blob, table, queue etc.

Account SAS - Scoped to one or more services

##### Azure Storage SAS Forms

Ad hoc SAS - Include data such as start/end into the signature

Service SAS (with stored access policy) - Only include policy in signature

##### SAS best practices

Always use HTTPS when creating or distributing an SAS

Use user delegation SAS whenever possible

Define a stored access policy for a service specific SAS

Use near-term expiration on ad hoc, service or account SAS

Follow least-privilege access for resources to be accessed

##### Azure App Service Mutual TLS Auth

Not supported on free or shared tiers

Certificate is the "X-ARR-ClientCert" header

Certificate value is Base64 encoded

Application code (write yourself) is required to validate certificate

##### Scenario understanding

Review different use cases for authentication approaches - Which solution is best 

Understand the order to implement different approaches

Know the limits of services and service tiers

Be able to spot poor security implementations

### Implement secure cloud solutions

Secure app configuration data by using the AppConfiguration and KeyVault API

Manage keys, secrets and certificates by using the KeyVault API

Implement Managed Identities for Azure resources

