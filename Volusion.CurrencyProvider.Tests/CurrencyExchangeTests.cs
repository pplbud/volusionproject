using System.Net;
using Volusion.CurrencyProvider.Enums;
using Shouldly;

namespace Volusion.CurrencyProvider.Tests
{
    public class CurrencyExchangeTests : BaseTests
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyExchangeTests()
        {
            _currencyService = new CurrencyService(CurrencySettings);
        }

        public class GetCurrencyExchangeTests : CurrencyExchangeTests
        {
            public void ShouldReturn200ResponseWhenConvertingFromDopToMxn()
            {
                var query = _currencyService.GetCurrencyExchange(Currency.DominicanPeso, Currency.MexicanPeso);
                query.ModelState.HttpStatusCode.ShouldBe(HttpStatusCode.OK, query.ModelState.LogMessage);
            }

            public void ShouldReturn200ResponseWhenConvertingFromDopToUsd()
            {
                var query = _currencyService.GetCurrencyExchange(Currency.DominicanPeso, Currency.UnitedStatesDollar);
                query.ModelState.HttpStatusCode.ShouldBe(HttpStatusCode.OK, query.ModelState.LogMessage);
            }

            public void ShouldReturn200ResponseWhenConvertingFromMxnToDop()
            {
                var query = _currencyService.GetCurrencyExchange(Currency.MexicanPeso, Currency.DominicanPeso);
                query.ModelState.HttpStatusCode.ShouldBe(HttpStatusCode.OK, query.ModelState.LogMessage);
            }

            public void ShouldReturn200ResponseWhenConvertingFromMxnToUsd()
            {
                var query = _currencyService.GetCurrencyExchange(Currency.MexicanPeso, Currency.UnitedStatesDollar);
                query.ModelState.HttpStatusCode.ShouldBe(HttpStatusCode.OK, query.ModelState.LogMessage);
            }

            public void ShouldReturn200ResponseWhenConvertingFromUsdToDop()
            {
                var query = _currencyService.GetCurrencyExchange(Currency.UnitedStatesDollar, Currency.DominicanPeso);
                query.ModelState.HttpStatusCode.ShouldBe(HttpStatusCode.OK, query.ModelState.LogMessage);
            }

            public void ShouldReturn200ResponseWhenConvertingFromUsdToMxn()
            {
                var query = _currencyService.GetCurrencyExchange(Currency.UnitedStatesDollar, Currency.MexicanPeso);
                query.ModelState.HttpStatusCode.ShouldBe(HttpStatusCode.OK, query.ModelState.LogMessage);
            }

            public void ShouldReturn400ResponseWhenSourceAndTargetCodesEqual()
            {
                var query = _currencyService.GetCurrencyExchange(Currency.UnitedStatesDollar, Currency.UnitedStatesDollar);
                query.ModelState.HttpStatusCode.ShouldBe(HttpStatusCode.BadRequest, query.ModelState.LogMessage);
            }

            public void ShouldReturn403ResponseWhenSourceCodeInvalid()
            {
                var query = _currencyService.GetCurrencyExchange(string.Empty, Currency.UnitedStatesDollar);
                query.ModelState.HttpStatusCode.ShouldBe(HttpStatusCode.Forbidden, query.ModelState.LogMessage);
            }

            public void ShouldReturn403ResponseWhenTargetCodeInvalid()
            {
                var query = _currencyService.GetCurrencyExchange(Currency.UnitedStatesDollar, string.Empty);
                query.ModelState.HttpStatusCode.ShouldBe(HttpStatusCode.Forbidden, query.ModelState.LogMessage);
            }
        }
    }
}