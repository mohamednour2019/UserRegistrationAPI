using RegistrationWebApplication.Core.ServicesContracts;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace RegistrationWebApplication.Core.Services
{
    public class GetDateService : IGetDateService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public GetDateService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<DateTime> GetDate(string Contenintal, string Country)
        {
            using(HttpClient client= _httpClientFactory.CreateClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage();
                requestMessage.Method=HttpMethod.Get;
                requestMessage.RequestUri = new Uri($"https://tools.aimylogic.com/api/now?tz={Contenintal}/{Country}&format=yyyy/dd/MM hh:mm:ss");
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                string responseContent= await response.Content.ReadAsStringAsync();
                Dictionary<string, object> result = JsonSerializer.Deserialize<Dictionary<string, object>>(responseContent);
                string DateTimeString = result["formatted"].ToString();
                DateTime date = DateTime.Parse(DateTimeString);
                return date;
            }
        }
    }
}
