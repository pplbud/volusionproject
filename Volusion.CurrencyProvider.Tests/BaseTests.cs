namespace Volusion.CurrencyProvider.Tests
{
    public class BaseTests
    {
        public readonly ICurrencySettings CurrencySettings;

        public BaseTests()
        {
            CurrencySettings = new CurrencySettings();
        }
    }
}