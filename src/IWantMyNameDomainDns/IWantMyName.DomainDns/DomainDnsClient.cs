using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IWantMyName.DomainDns
{
	public class DomainDnsClient
	{
		public string BaseUrl { get; set; } = "https://iwantmyname.com/basicauth/ddns";
		public string Username { get; set; }
		public string Password { get; set; }

		public DomainDnsClient(string username, string password)
		{
			Username = username;
			Password = password;
		}

		public DomainDnsClient(string username, string password, string baseUrl)
		{
			Username = username;
			Password = password;
			BaseUrl = baseUrl;
		}

		public DomainDnsClient() { }

		private HttpClient CreateHttpClient()
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Clear();
			var usernamePasswordBytes = System.Text.Encoding.ASCII.GetBytes($"{Username}:{Password}");
			var encodedUsernamePassword = Convert.ToBase64String(usernamePasswordBytes);
			client.DefaultRequestHeaders.Add("Authorization", $"Basic {encodedUsernamePassword}");
			return client;
		}

		public async Task<DnsRecordResult> CreateRecord(string hostname, RecordType recordType, string value, int ttl = 3600)
		{
			if (recordType.Value == RecordType.A.Value || recordType.Value == RecordType.AAAA.Value)
				return await CreateARecord(hostname, value, ttl);

			try
			{
				HttpResponseMessage httpResponse;
				using (var client = CreateHttpClient())
				{
					List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>
					{
						new KeyValuePair<string, string>("hostname", hostname),
						new KeyValuePair<string, string>("type", recordType.Value),
						new KeyValuePair<string, string>("value", value)
					};

					if (ttl != 3600)
						queryParameters.Add(new KeyValuePair<string, string>("ttl", ttl.ToString()));

					httpResponse = await client.PostAsync(BaseUrl, new FormUrlEncodedContent(queryParameters));
				}

				var responseContent = await httpResponse.Content.ReadAsStringAsync();
				if (httpResponse.IsSuccessStatusCode)
				{
					if (responseContent.Contains("good"))
						return new DnsRecordResult() { Success = true, Message = responseContent };

					return new DnsRecordResult() { Success = false, Message = responseContent };
				}

				return new DnsRecordResult() { Success = false, Message = responseContent };
			}
			catch (Exception ex)
			{
				return new DnsRecordResult() { Success = false, Message = ex.Message };
			}
		}

		public async Task<DnsRecordResult> DeleteRecord(string hostname, RecordType recordType)
		{
			try
			{
				HttpResponseMessage httpResponse;
				using (var client = CreateHttpClient())
				{
					List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>
					{
						new KeyValuePair<string, string>("hostname", hostname),
						new KeyValuePair<string, string>("type", recordType.Value),
						new KeyValuePair<string, string>("value", "delete")
					};
					httpResponse = await client.PostAsync(BaseUrl, new FormUrlEncodedContent(queryParameters));
				}

				var responseContent = await httpResponse.Content.ReadAsStringAsync();
				if (httpResponse.IsSuccessStatusCode)
				{
					if (responseContent.Contains("deleted"))
						return new DnsRecordResult() { Success = true, Message = responseContent };

					return new DnsRecordResult() { Success = false, Message = responseContent };
				}

				return new DnsRecordResult() { Success = false, Message = responseContent };
			}
			catch (Exception ex)
			{
				return new DnsRecordResult() { Success = false, Message = ex.Message };
			}
		}

		private async Task<DnsRecordResult> CreateARecord(string hostname, string ipAddress, int ttl = 3600)
		{
			try
			{
				HttpResponseMessage httpResponse;
				using (var client = CreateHttpClient())
				{
					List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>
					{
						new KeyValuePair<string, string>("hostname", hostname),
						new KeyValuePair<string, string>("myip", ipAddress)
					};

					if (ttl != 3600)
						queryParameters.Add(new KeyValuePair<string, string>("ttl", ttl.ToString()));

					httpResponse = await client.PostAsync(BaseUrl, new FormUrlEncodedContent(queryParameters));
				}

				var responseContent = await httpResponse.Content.ReadAsStringAsync();
				if (httpResponse.IsSuccessStatusCode)
				{
					if (responseContent.Contains("good"))
						return new DnsRecordResult() { Success = true, Message = responseContent };

					return new DnsRecordResult() { Success = false, Message = responseContent };
				}

				return new DnsRecordResult() { Success = false, Message = responseContent };
			}
			catch (Exception ex)
			{
				return new DnsRecordResult() { Success = false, Message = ex.Message };
			}

		}
	}
}
