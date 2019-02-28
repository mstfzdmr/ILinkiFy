using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;
using LinkiFyExtension.Models;

namespace LinkiFy.Integration.Tests.Models
{
    public class LinkiFyDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] {
                new List<LinkiFyDataModel> {
                    new LinkiFyDataModel { Text = "open source", Value = "https://github.com/open-source" },
                    new LinkiFyDataModel { Text = "business", Value = "https://github.com/business" },
                    new LinkiFyDataModel { Text = "developers", Value = "https://github.com/mstfzdmr" } }
                };
        }
    }
}
