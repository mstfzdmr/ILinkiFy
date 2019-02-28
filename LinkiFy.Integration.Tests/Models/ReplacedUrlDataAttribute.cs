using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace LinkiFy.Integration.Tests.Models
{
    public class ReplacedUrlDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new Dictionary<string, string> {
                    { "https://github.githubassets.com", "https://github.githubassets.new2.com" },
                    { "https://avatars0.githubusercontent.com", "https://avatars0.githubusercontent.new2.com" },
                    { "https://avatars1.githubusercontent.com", "https://avatars1.githubusercontent.new2.com" },
                    { "https://avatars2.githubusercontent.com", "https://avatars2.githubusercontent.new2.com" },
                    { "https://avatars3.githubusercontent.com", "https://avatars3.githubusercontent.new2.com" },
                    { "https://github-cloud.s3.amazonaws.com", "https://github-cloud.s3.amazonaws.new2.com" },
                    { "https://user-images.githubusercontent.com", "https://user-images.githubusercontent.new2.com" },
                    { "/opensearch.xml", "/opensearch.new2.xml" },
                    { "https://github.githubassets.com/", "https://github.githubassets.new2.com/" },
                    { "wss://live.github.com/_sockets/VjI6MjU3OTcwMTU3OjQwMDkxNmJhOWViYTU3YzA1MzNlZjZiNzMwNDNiODQ3YWRkM2RlZWYyN2I2YTFjMjQ5NjY2YWNkNzlkMDU2YjM=--c8cc0a280a7271e6ea66ae286f74fe0de0cf1304", "wss://live.new2.github.com/_sockets/VjI6MjU3OTcwMTU3OjQwMDkxNmJhOWViYTU3YzA1MzNlZjZiNzMwNDNiODQ3YWRkM2RlZWYyN2I2YTFjMjQ5NjY2YWNkNzlkMDU2YjM=--c8cc0a280a7271e6ea66ae286f74fe0de0cf1304" },
                    { "https://github.githubassets.com/pinned-octocat.svg", "https://github.new2.githubassets.com/pinned-octocat.svg" },
                    { "https://github.githubassets.com/favicon.ico", "https://github.githubassets.com/favicon.new2.ico" },
                    { "/manifest.json", "/manifest.new2.json" }
                }
            };
        }
    }
}
