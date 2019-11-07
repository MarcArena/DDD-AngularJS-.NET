using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace devTest.Data.Base
{
    public class WebApiService : IWebApiService
    {   
        public T Get<T>(string url, double? timeout = 1000)
        {
            T result = JsonConvert.DeserializeObject<T>(string.Empty);

            HttpClient client = new HttpClient
            {
                Timeout = TimeSpan.FromMilliseconds(timeout.Value)
            };

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            try
            {
                HttpResponseMessage response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = response.Content.ReadAsStringAsync().Result;

                    result = JsonConvert.DeserializeObject<T>(jsonString);
                }
            }

            catch (Exception ex) { }

            return result;
        }
    }
}