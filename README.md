# IWantMyNameDomainDns
A C# Wrapper for the iwantmyname.com Domain &amp; DNS API

iwantmyname.com provides an API to manage your domain DNS records. This is a great way to for example create subdomains automatically for multi-tenant applications.
This libary provides a simple and easy way to create and delete DNS records for domains registered at iwantmyname.com

You can read more about the API at https://iwantmyname.com/developer/domain-dns-api

In order to use this library, simply add a reference to it to your project. 

### Creating a TXT record
```csharp

public async Task Create_TXT_RecordTest()
{
    var dnsClient = new DomainDnsClient("<Your-Username>", "<Your-Password>");
    var response = await dnsClient.CreateRecord("test1.yourdomain.com",RecordType.TXT, "YourTXTRecordValue");
}

```

### Deleting a TXT record
```csharp

public async Task Delete_TXT_RecordTest()
{
    var dnsClient = new DomainDnsClient("<Your-Username>", "<Your-Password>");
    var response = await dnsClient.DeleteRecord("test1.yourdomain.com", RecordType.TXT);
}


```
