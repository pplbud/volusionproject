using System.Configuration;

namespace Volusion.CurrencyProvider
{
    public interface ICurrencySettings
    {
        string FloatRatesDomain { get; }
    }

    public class CurrencySettings : ICurrencySettings
    {
        public string FloatRatesDomain
        {
            get { return ConfigurationManager.AppSettings["FloatRatesDomain"]; }
        }
    }
}