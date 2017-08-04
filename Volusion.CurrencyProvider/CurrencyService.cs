using System;
using System.Net;
using Volusion.CurrencyProvider.FloatRates;
using Volusion.CurrencyProvider.Queries;

namespace Volusion.CurrencyProvider
{
    public interface ICurrencyService
    {
        CurrencyExchangeQuery GetCurrencyExchange(string fromCurrency, string toCurrency);
    }

    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencySettings _currencySettings;

        public CurrencyService(ICurrencySettings currencySettings)
        {
            _currencySettings = currencySettings;
        }

        public CurrencyExchangeQuery GetCurrencyExchange(string fromCurrency, string toCurrency)
        {
            if (string.Equals(fromCurrency, toCurrency, StringComparison.OrdinalIgnoreCase))
            {
                return new CurrencyExchangeQuery
                {
                    ModelState =
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                        UserMessage = "Source and Target currency codes cannot be the same",
                        LogMessage = string.Format("Source={0} : Target={1}", fromCurrency, toCurrency)
                    }
                };
            }

            var provider = new FloatRatesProvider(_currencySettings);
            return provider.GetCurrencyExchange(fromCurrency, toCurrency);
        }
    }
}