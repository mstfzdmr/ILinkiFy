using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace LinkiFy.Integration.Tests.Models
{
    public class ReplacedUrlNonDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new Dictionary<string, string> {
                    { "https://github.com/open-source", "https://github.com/opensource" },
                    { "https://github.com/business", "https://github.com/work-business" },
                    { "https://github.com/mstfzdmr", "https://github.com/mustafaozdemir" },
                    { "https://github.com/mstfzdmr/ILinkiFy", "https://github.com/mustafaozdemir/ILinkiFy" },
                    { "https://github.com/explore", "https://github.com/preview" },
                }
            };
        }
    }
}
