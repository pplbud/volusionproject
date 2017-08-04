using Volusion.Core.Data.Queries;

namespace Volusion.CurrencyProvider.Queries
{
    public class CurrencyExchangeQuery : StandardQuery
    {
        public string Message { get; set; }
        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public decimal Rate { get; set; }
    }
}