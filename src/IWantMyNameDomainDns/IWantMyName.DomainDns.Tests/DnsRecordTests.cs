using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IWantMyName.DomainDns.Tests
{
    [TestClass]
    public class DnsRecordTests
    {
	    private string _username;
	    private string _password;

        [TestInitialize]
	    public void Initialize()
	    {
            _username= "<Your-Username-Here>";
            _password = "<Your-Password-Here>";
	    }

        [TestMethod]
        public async Task Create_TXT_RecordTest()
        {
            var dnsClient = new DomainDnsClient(_username,_password);
            var response = await dnsClient.CreateRecord("test1.yourdomain.com",RecordType.TXT, "YourTXTRecordValue");

            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public async Task Delete_TXT_RecordTest()
        {
	        var dnsClient = new DomainDnsClient(_username, _password);
            var response = await dnsClient.DeleteRecord("test1.yourdomain.com", RecordType.TXT);

            Assert.IsTrue(response.Success);
        }
    }
}
