using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IWantMyName.DomainDns.Tests
{
    [TestClass]
    public class DnsRecordTests
    {
        [TestMethod]
        public void Create_A_RecordTest()
        {
            var dnsClient = new DomainDnsClient("", "");
            dnsClient.CeateRecord(RecordType.A, "109.169.12.90");
        }
    }
}
