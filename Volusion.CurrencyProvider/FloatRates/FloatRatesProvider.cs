using System;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using Volusion.Core.Api;
using Volusion.Core.Api.Enums;
using Volusion.Core.Api.Helpers;
using Volusion.CurrencyProvider.Enums;
using Volusion.CurrencyProvider.Queries;

namespace Volusion.CurrencyProvider.FloatRates
{
    public class FloatRatesProvider : ICurrencyService
    {
        private readonly ICurrencySettings _currencySettings;

        public FloatRatesProvider(ICurrencySettings currencySettings)
        {
            _currencySettings = currencySettings;
        }

        public CurrencyExchangeQuery GetCurrencyExchange(string fromCurrency, string toCurrency)
        {
            var query = new CurrencyExchangeQuery();

            try
            {
                var client = new RestClient(_currencySettings.FloatRatesDomain);

                var request = new RestRequest(string.Format("daily/{0}.json", fromCurrency.ToLower()), Method.GET);

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Cache-Control", "no-cache");

                request.JsonSerializer = new RestSharpJsonNetSerializer();

                var response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    ApiHelper.SetModelStateWhenResourceNotFound(query.ModelState, response, client.BaseUrl.ToString(), request.Resource);
                    return query;
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    query.ModelState.HttpStatusCode = response.StatusCode;
                    query.ModelState.UserMessage = "Unable to convert currency";
                    query.ModelState.LogMessage = "Error converting currency";
                    return query;
                }

                var currencyResponse = JsonConvert.DeserializeObject<FloatRatesProviderResponse>(response.Content);
                query.SourceCurrency = fromCurrency;
                query.TargetCurrency = toCurrency;

                switch (toCurrency.ToUpper())
                {
                    case Currency.DominicanPeso:
                        query.Rate = currencyResponse.Dop.Rate;
                        break;
                    case Currency.MexicanPeso:
                        query.Rate = currencyResponse.Mxn.Rate;
                        break;
                    case Currency.UnitedStatesDollar:
                        query.Rate = currencyResponse.Usd.Rate;
                        break;
                    default:
                        query.ModelState.HttpStatusCode = HttpStatusCode.Forbidden;
                        query.ModelState.UserMessage = "Invalid target code";
                        return query;
                }

                query.ModelState.HttpStatusCode = HttpStatusCode.OK;
                query.ModelState.UserMessage = UserMessage.Success;
                return query;
            }
            catch (Exception ex)
            {
                query.ModelState.HttpStatusCode = HttpStatusCode.InternalServerError;
                query.ModelState.UserMessage = "Unable to convert currency";
                query.ModelState.LogMessage = string.Format("Error converting currency: {0}", ex);
                return query;
            }
        }
    }
}