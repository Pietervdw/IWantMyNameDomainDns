# iwantmyname.com Domain & DNS API C# Wrapper library
A C# Wrapper for the iwantmyname.com Domain &amp; DNS API

[![NuGet Version](https://img.shields.io/nuget/v/IWantMyName.DomainDns.svg?style=flat)](https://www.nuget.org/packages/RestWrapper/)

iwantmyname.com provides an API to manage your domain DNS records. This is a great way to for example create subdomains automatically for multi-tenant applications.
This libary provides a simple and easy way to create and delete DNS records for domains registered at iwantmyname.com

You can read more about the API at https://iwantmyname.com/developer/domain-dns-api

Get it from [NuGet](https://www.nuget.org/packages/IWantMyName.DomainDns/).  

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
