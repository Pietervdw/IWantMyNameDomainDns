using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IWantMyName.DomainDns
{
    public class DomainDnsClient
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public DomainDnsClient(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public DomainDnsClient()
        {
            
        }

        public DnsRecordCreateResult CeateRecord(RecordType recordType, string value, int ttl=3600)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"{Username}:{Password}");

            var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

            return new DnsRecordCreateResult();
        }
    }
}
