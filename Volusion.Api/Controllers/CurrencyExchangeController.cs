using System.Net;
using System.Net.Http;
using System.Web.Http;
using Volusion.Api.Models.Responses;
using Volusion.Core.Api.Helpers;
using Volusion.Core.Api.Responses;
using Volusion.CurrencyProvider;

namespace Volusion.Api.Controllers
{
    public class CurrencyExchangeController : ApiController
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyExchangeController(ICurrencyService currencyService) {
            _currencyService = currencyService;
        }

        [Route("api/v1/currencyExchange"), HttpGet]
        public HttpResponseMessage GetCurrencyExchange([FromUri] string source = "", string target = "")
        {
            var query = _currencyService.GetCurrencyExchange(source, target);
            if (query.ModelState.HttpStatusCode != HttpStatusCode.OK)
                return ResponseHelper.HttpResponseMessage(this, new StandardResponse(), query.ModelState);

            var response = new CurrencyExchangeResponse
            {
                CurrencyExchange =
                {
                    Source = query.SourceCurrency,
                    Target = query.TargetCurrency,
                    Rate = query.Rate
                }
            };

            return ResponseHelper.HttpResponseMessage(this, response, query.ModelState);
        }
    }
}