# Integrate Caching and Content Delivery

## Azure Front Door

"Azure Front Door is an Application Delivery Network (ADN) as a service, offering various 
layer 7 load-balancing capabilities for your application. It provides dynamic site acceleration
(DSA) along with global load balancing with near real-time failover."

#### Compression

- Support dynamic compression at the edge.
- Compression types supported:
  - GZip
  - Brotli (takes precedence)

*This ONLY works for supported MIME types from a fixed list maintained by Microsoft.*

*Dynamic compression only works for files from 1 KB to 8 MB in size.*

#### Cache Purge Types

**Single Path** - Purge an asset by using the full path to the asset.

**Wildcard Purge** - Purge all assets in a folder and its subfolders.

**Root Domain** - Purge all cached assets in the root domain.



## Azure CDN

Multiple CDN networks (Microsoft, Verizon, Akamai)

Object request from a POP (Point Of Presence) location.
If object does not exist, fetch from origin.
Object is cached at the POP location.

### Caching rules

- Global Caching Rule (overrides HTTP cache headers)
- Custom Caching Rule (overrides Global Caching Rules)

Global Caching Rules define:

- Cache behaviour
- Expiration duration
- Query string caching behaviour

*Custom Caching Rules can set custom behaviour and duration by path pattern!*

#### Cache Behaviour in Azure CDN

**Bypass Cache** - Don't cache anything and ignore cache HTTP-headers

**Override** - Ignores cache duration in headers, uses Azure CDN config value

**Set if missing** - Uses the Azure CDN config value if duration header i missing



#### Query String Handling

**Ignore query strings** - Query string only used on initial fetch from origin (default)

**Bypass caching** - Asset not cached at the POP, query string always passed to origin

**Cache every unique URL** - URL with query string used to set cache value



### How caching works

Globally distributed network

Reduced asset load times

Reduced hosting bandwidth

Increased availability and redundancy

Protection from DDOS attacks

### Content types

Static Content - Images, CSS, JS etc.

Dynamic Content - Query results, user interactive

### Pricing tiers

Standard Microsoft

Standard Akamai

Standard Verizon

Premium Verizon

https://docs.microsoft.com/en-us/azure/cdn/cdn-features

### HTTP Headers

Control caching using HTTP headers. Original usage for webserver queries but now also used by CDN's.

- Cache-control (Takes precedent over Expires header)
- Expires

Standard Akamai only supports "Max-age", "No-store" and "No-cache" headers.

### Configuration options

Custom DNS domain

Compression

Caching rules

Geo filtering

Optimization

Dynamic site acceleration (use FrontDoor instead of CDN)



## Azure Redis Cache

"Azure Cache for Redis is a fully managed, in-memory cache that enables
high-performance and scalable architectures. Use it to create cloud or hybrid
deployments that handle millions of requests per second at sub-millisecond latency."



### Pricing tiers

- Basic
  - Minimal feature set
  - No SLA
  - Testing and development purposes
  - 53GB memory and 20 000 connected clients
- Standard
  - 2 replicated nodes
  - 99.9% SLA
  - 53GB memory and 20 000 connected clients
- Premium
  - Redis cluster
  - Low latency
  - 99.95% SLA
  - 100 GB memory and 40 000 connected clients
- Enterprise
  - Full Redis feature set
  - 99.99% SLA
- Enterprise Flash
  - Fast non-volatile storage

**You can scale up, but you cannot scale down!**



### Caching patterns

- Cache-aside pattern
  - Checks cache if data exists
  - If not, retrieve from data store
  - Store a copy in the cache
- Content Cache Pattern
  - Cache static content (images, templates, stylesheets etc.)
  - Reduces server load
  - Redis Output Cache Provider is available for ASP.NET
- User Session Caching Pattern
  - Maintain application state (e.g. shopping cart, profile data etc.)
- Job and Message Queuing (advanced)
- Distributed transactions (advanced)





## Cache and expiration policies

- Each cache entry has a TTL (time to live)
- Items invalidated when they are purged or TTL expires

#### Controlling Caching Behavior

- Using a caching policy
- Using the web.config file
- Programmatically

#### Default Caching Behaviour

Default TTL

Azure CDN - 7 days

Azure Front Door - Between 1-3 days

Redis - No default expiry (need to be set when added to cache)







