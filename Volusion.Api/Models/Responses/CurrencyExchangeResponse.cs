using Newtonsoft.Json;
using Volusion.Core.Api.Responses;

namespace Volusion.Api.Models.Responses
{
    public class CurrencyExchangeResponse : StandardResponse
    {
        public CurrencyExchangeResponse()
        {
            CurrencyExchange = new CurrencyExchangeJson();
        }

        [JsonProperty(PropertyName = "currencyExchange")]
        public CurrencyExchangeJson CurrencyExchange { get; set; }

        public class CurrencyExchangeJson
        {
            [JsonProperty(PropertyName = "source")]
            public string Source { get; set; }

            [JsonProperty(PropertyName = "target")]
            public string Target { get; set; }

            [JsonProperty(PropertyName = "rate")]
            public decimal Rate { get; set; }
        }
    }
}