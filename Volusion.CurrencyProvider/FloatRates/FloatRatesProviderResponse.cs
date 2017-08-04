using Newtonsoft.Json;

namespace Volusion.CurrencyProvider.FloatRates
{
    public class FloatRatesProviderResponse
    {
        public FloatRatesProviderResponse()
        {
            Usd = new ValJson();
            Dop = new ValJson();
            Mxn = new ValJson();
        }

        [JsonProperty(PropertyName = "usd")]
        public ValJson Usd { get; set; }

        [JsonProperty(PropertyName = "dop")]
        public ValJson Dop { get; set; }

        [JsonProperty(PropertyName = "mxn")]
        public ValJson Mxn { get; set; }

        public class ValJson
        {
            [JsonProperty(PropertyName = "code")]
            public string Code { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "rate")]
            public decimal Rate { get; set; }
        }
    }
}