using HomeBudget.Models.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
// Rozbicie API 4)
namespace HomeBudget.BussinesLogic
{
    public class CryptoCurrencyClient
    {
        private readonly string baseUrl;
        private readonly string apiKey;

        public CryptoCurrencyClient(string baseUrl, string apiKey)
        {
            this.baseUrl = baseUrl;
            this.apiKey = apiKey;
        }
        public CapCoinResponse GetList(string convert, int page = 0, int pageSize = 10)
        {
            var URL = new UriBuilder(baseUrl);
            if (page < 0)
                return null;

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = ((page * pageSize) + 1).ToString();
            queryString["limit"] = pageSize.ToString();
            queryString["convert"] = convert;

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", apiKey);
            client.Headers.Add("Accepts", "application/json");
            var responseString = client.DownloadString(URL.ToString());

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<CapCoinResponse>(responseString);
            foreach (var item in result.data)
            {
                item.price = item.quote[convert]["price"] ?? (float)item.quote[convert]["price"];
            }
            return result;
        }
    }
}
