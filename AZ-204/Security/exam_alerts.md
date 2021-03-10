### Implement user authentication and authorization

- Implement OAuth2 authentication
- Create and implement shared access signatures
- Register apps and use Azure AD to authenticate users
- Control access to resources by using role-base access controls (RBAC)

### Learn more about

##### App Manifest - Attributes to review

- appRoles - Specifies the collection of roles that an app may declare
  - allowedMemberTypes: ["User"],
  - isEnabled: true
- groupMembershipClaims - Configures the `groups` claim issued in a user or OAuth 2.0 access token that the app expects.
  - None, SecurityGroup, ApplicationGroup, DirectoryRole, All
- optionalClaims - The optional claims returned in the token by the security token service for this specific app. Objects { "idToken": [ { name: "upn" }]}
- oauth2AllowImplicitFlow - Specifies whether this web app can request OAuth2.0 implicit flow access tokens. The default is false.

- oauth2Permissions - Specifies the collection of OAuth 2.0 permission scopes that the web API (resource) app exposes to client apps. 

- signInAudience -  Specifies what Microsoft accounts are supported for the current application. Supported values are:
  - AzureADMyOrg
  - AzureADMultipleOrgs
  - AzureADandPersonalMicrosoftAccount
  - PersonalMicrosoftAccount (xbox, skype etc.)

https://docs.microsoft.com/en-us/azure/active-directory/develop/reference-app-manifest

##### Core Azure RBAC Concepts

- Security Principal (Users, groups and also managed identities)

- Role Definition (What can be done for a specific role)

- Scope (What the role can be applied to)

- Role Assignment (a definition of principal, role definition and scope)


##### Shared Access Signature types

- User delegation (not using storage account key to sign signature, using AD credentials)
  Currently only works with blob storage
- Service SAS - Scoped to a specific service in your storage account such as blob, table, queue etc.

- Account SAS - Scoped to one or more services


##### Azure Storage SAS Forms

- Ad hoc SAS - Include data such as start/end into the signature

- Service SAS (with stored access policy) - Only include policy in signature


##### SAS best practices

- Always use HTTPS when creating or distributing an SAS

- Use user delegation SAS whenever possible

- Define a stored access policy for a service specific SAS

- Use near-term expiration on ad hoc, service or account SAS

- Follow least-privilege access for resources to be accessed


##### Azure App Service Mutual TLS Auth

- Not supported on free or shared tiers

- Certificate is the "X-ARR-ClientCert" header

- Certificate value is Base64 encoded

- Application code (write yourself) is required to validate certificate
- https://docs.microsoft.com/en-us/azure/app-service/app-service-web-configure-tls-mutual-auth

##### Scenario understanding

- Review different use cases for authentication approaches - Which solution is best 

- Understand the order to implement different approaches

- Know the limits of services and service tiers

- Be able to spot poor security implementations


### Implement secure cloud solutions

- Secure app configuration data by using the AppConfiguration and KeyVault API

- Manage keys, secrets and certificates by using the KeyVault API

- Implement Managed Identities for Azure resources


