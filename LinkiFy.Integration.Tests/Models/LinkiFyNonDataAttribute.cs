using LinkiFyExtension.Models;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace LinkiFy.Integration.Tests.Models
{
    public class LinkiFyNonDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] {
                new List<LinkiFyDataModel> {
                    new LinkiFyDataModel { Text = "microsoft", Value = "https://www.microsoft.com" } }
                };
        }
    }
}
