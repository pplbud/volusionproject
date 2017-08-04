using System;
using Fixie;
using Volusion.CurrencyProvider.Tests.Fixie.Attributes;

namespace Volusion.CurrencyProvider.Tests.Fixie.Conventions
{
    public class CustomConvention : Convention
    {
        public CustomConvention()
        {
            Classes
                .NameEndsWith("Tests");

            Methods
                .Where(method => method.IsVoid());

            CaseExecution
                .Skip(
                      @case => @case.Class.HasOrInherits<SkipAttribute>() ||
                               @case.Class.DeclaringType.HasOrInherits<SkipAttribute>() ||
                               @case.Method.HasOrInherits<SkipAttribute>() ||
                               @case.Method.DeclaringType.HasOrInherits<SkipAttribute>());

            ClassExecution
                //.CreateInstancePerCase()
                .CreateInstancePerClass()
                .SortCases((caseA, caseB) => string.Compare(caseA.Name, caseB.Name, StringComparison.Ordinal));
        }
    }
}