# Blob storage



### Storage Account

Name must be unique. (https://[account].blob.core.windows.net)

Must be between 3 - 24 chars long.

Only lower-case letters and numbers



### Blob Container(s)

Is a flat object storage. Not folders.

https://[account].blob.core.windows.net/[container]

To list blobs: https://[account].blob.core.windows.net/[container]?comp=list

### Blob(s)

https://[account].blob.core.windows.net/[container]/[blob]
https://[account].blob.core.windows.net/[container]/[some]/[path]/[blob]

No folder just path prefixes (/path/prefix/blobname.mp4) gives a virtual directory.



## Authorize Requests to Blob Storage

Shared Key (Storage Account Key) - Included in connectionstring

Shared Access Signatures (SAS)

Tokens appended to blob url's.

Azure Active Directory

Anonymous public read access



## Blobtypes

Block Blob - Files

Append Blob - Appends to a file

Page Blob - Virtual disks (random read/write access)



## Storage Account Kinds

##### StorageV2

Blob, File, Queue and Table

Standard - Magnetic drives

Premium - Solid state drives (only support page blobs)

##### BlockBlobStorage (Premium)

Blob

##### FileStorage (Premium)

File

##### Storage (V1) - (Legacy - Can be upgraded to V2)

##### BlobStorage - (Legacy - Can be upgraded to V2)



## Replication Strategies

Regions = Europe, US, Asia

Zone = Datacenter (West Europe, North Europe)

##### Local Redundant Storage (LRS) 

3 copies of data in the same region and zone (datacenter). (3 copies in West Europe)

##### Zone-Redundant Storage (ZRS)

3 copies of data in 3 zones in one region. (1 copy in West Europe, 1 copy in North Europe, xxxxx)

Not supported in all regions. Needs at least 3 zones (datacenters).

##### Geo Redundant Storage (GRS)

3 copies of data in one zone and 3 copies of data in a second zone in another region.

Async copying!

##### Geo-Zone-Redundant Storage (GZRS)

3 copies of data in 3 zones in one region. (1 copy in West Europe, 1 copy in North Europe, xxxxx)

3 copies of data in a second zone in another region.

### IMPORTANT

You can only read and write data from/to the primary region. If an error occurs you must do a fail over.

After failover the secondary region becomes the primary region. The failover takes about 1 hour.

If you need to always read data from the secondary region you need to choose RA-GRS or RA-GZRS. This creates a secondary endpoint: https://[account]-secondary.blob.core.windows.net













