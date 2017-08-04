using System;

namespace Volusion.CurrencyProvider.Tests.Fixie.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class SkipAttribute : Attribute { }
}
