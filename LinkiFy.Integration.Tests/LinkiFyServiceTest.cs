using LinkiFy.Integration.Tests.Models;
using LinkiFyExtension;
using LinkiFyExtension.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Xunit;

namespace LinkiFy.Integration.Tests
{
    public class LinkiFyServiceTest
    {
        private readonly ILinkiFyService _linkiFyService;
        private readonly string _content;
        private readonly string _htmlContent;
        public LinkiFyServiceTest()
        {
            _linkiFyService = new LinkiFyService();
            _content = "GitHub is a development platform inspired by the way you work. From open source to business, you can host and review code, manage projects, and build software alongside millions of other developers.";
            _htmlContent = "<head><meta charset=\"utf-8\"><link rel=\"dns-prefetch\" href=\"https://github.githubassets.com\"><link rel=\"dns-prefetch\" href=\"https://avatars0.githubusercontent.com\"><link rel=\"dns-prefetch\" href=\"https://avatars1.githubusercontent.com\"><link rel=\"dns-prefetch\" href=\"https://avatars2.githubusercontent.com\"><link rel=\"dns-prefetch\" href=\"https://avatars3.githubusercontent.com\"><link rel=\"dns-prefetch\" href=\"https://github-cloud.s3.amazonaws.com\"><link rel=\"dns-prefetch\" href=\"https://user-images.githubusercontent.com/\"><meta name=\"viewport\" content=\"width=device-width\"><title>GitHub</title><meta name=\"description\" content=\"GitHub is where people build software. More than 31 million people use GitHub to discover, fork, and contribute to over 100 million projects.\"><link rel=\"search\" type=\"application/opensearchdescription+xml\" href=\"/opensearch.xml\" title=\"GitHub\"><meta property=\"og:url\" content=\"https://github.com\"><meta property=\"og:site_name\" content=\"GitHub\"><meta property=\"og:title\" content=\"Build software better, together\"><meta property=\"og:description\" content=\"GitHub is where people build software. More than 31 million people use GitHub to discover, fork, and contribute to over 100 million projects.\"><meta property=\"og:image\" content=\"https://github.githubassets.com/images/modules/open_graph/github-logo.png\"><meta property=\"og:image:type\" content=\"image/png\"><meta property=\"og:image:width\" content=\"1200\"><meta property=\"og:image:height\" content=\"1200\"><meta property=\"og:image\" content=\"https://github.githubassets.com/images/modules/open_graph/github-mark.png\"><meta property=\"og:image:type\" content=\"image/png\"><meta property=\"og:image:width\" content=\"1200\"><meta property=\"og:image:height\" content=\"620\"><meta property=\"og:image\" content=\"https://github.githubassets.com/images/modules/open_graph/github-octocat.png\"><meta property=\"og:image:type\" content=\"image/png\"><meta property=\"og:image:width\" content=\"1200\"><meta property=\"og:image:height\" content=\"620\"><link rel=\"assets\" href=\"https://github.githubassets.com/\"><link rel=\"web-socket\" href=\"wss://live.github.com/_sockets/VjI6MjU3OTcwMTU3OjQwMDkxNmJhOWViYTU3YzA1MzNlZjZiNzMwNDNiODQ3YWRkM2RlZWYyN2I2YTFjMjQ5NjY2YWNkNzlkMDU2YjM=--c8cc0a280a7271e6ea66ae286f74fe0de0cf1304\"><meta name=\"hostname\" content=\"github.com\"><meta name=\"user-login\" content=\"mstfzdmr\"><meta name=\"expected-hostname\" content=\"github.com\"><meta name=\"js-proxy-site-detection-payload\" content=\"ZTg2ZDlhYzI5ZGE4ZWU1OWVjNTgxZmQ2ZTk2ZDYwODQ2YTIxYzA5MGM4MzAzY2E4ZGZhOTg5ZjMyZWFmODdiNHx7InJlbW90ZV9hZGRyZXNzIjoiMjEyLjI1Mi4xOTMuMTIyIiwicmVxdWVzdF9pZCI6IjU2NkQ6NUUyMzo1NjQ5MEM6QTM0RjRCOjVDNzc3QkRGIiwidGltZXN0YW1wIjoxNTUxMzM0MzY4LCJob3N0IjoiZ2l0aHViLmNvbSJ9\"><meta name=\"enabled-features\" content=\"UNIVERSE_BANNER,MARKETPLACE_SOCIAL_PROOF,MARKETPLACE_PLAN_RESTRICTION_EDITOR,NOTIFY_ON_BLOCK,RELATED_ISSUES,MARKETPLACE_BROWSING_V2\"><meta name=\"html-safe-nonce\" content=\"6afe02f9d9fccc0dbcad6cc6d3676b7250cea560\"><meta http-equiv=\"x-pjax-version\" content=\"51633f82d41fbb109c08bc27389aacb1\"><meta name=\"browser-stats-url\" content=\"https://api.github.com/_private/browser/stats\"><meta name=\"browser-errors-url\" content=\"https://api.github.com/_private/browser/errors\"><link rel=\"mask-icon\" href=\"https://github.githubassets.com/pinned-octocat.svg\" color=\"#000000\"><link rel=\"icon\" type=\"image/x-icon\" class=\"js-site-favicon\" href=\"https://github.githubassets.com/favicon.ico\"><meta name=\"theme-color\" content=\"#1e2327\"><meta name=\"u2f-support\" content=\"true\"><link rel=\"manifest\" href=\"/manifest.json\" crossorigin=\"use-credentials\"></head>";
        }

        [Theory, LinkiFyData]
        public void GetLinkifyContent_LinkiFyDataModels_ShouldAssertSuccess(List<LinkiFyDataModel> valueToLinks)
        {
            var result = _linkiFyService.GetLinkifyContent(_content, valueToLinks);

            Assert.NotNull(result);

            Assert.NotEqual(result, _content);
        }

        [Theory, LinkiFyNonData]
        public void GetLinkifyContent_LinkiFyDataModelsIsNonData_ShouldAssertSuccess(List<LinkiFyDataModel> valueToLinks)
        {
            var result = _linkiFyService.GetLinkifyContent(_content, valueToLinks);

            Assert.NotNull(result);

            Assert.Equal(result, _content);
        }

        [Theory, LinkiFyData]
        public void GetLinkifyContent_ContentIsStringEmpty_ShouldAssertSuccess(List<LinkiFyDataModel> valueToLinks)
        {
            var result = _linkiFyService.GetLinkifyContent(string.Empty, valueToLinks);

            Assert.Equal(result, string.Empty);
        }

        [Theory, ReplacedUrlData]
        public void UrlReplacement_ReplacedUrlDictionaries_ShouldAssertSuccess(Dictionary<string, string> replaceKeys)
        {
            var result = _linkiFyService.UrlReplacement(_htmlContent, replaceKeys);

            Assert.NotNull(result);

            Assert.NotEqual(result, _htmlContent);
        }

        [Theory, ReplacedUrlNonData]
        public void UrlReplacement_ReplacedUrlDictionariesIsNonData_ShouldAssertSuccess(Dictionary<string, string> replaceKeys)
        {
            var result = _linkiFyService.UrlReplacement(_htmlContent, replaceKeys);

            Assert.NotNull(result);

            Assert.Equal(result, _htmlContent);
        }

        [Theory, ReplacedUrlData]
        public void UrlReplacement_HtmlContentIsStringEmpty_ShouldAssertSuccess(Dictionary<string, string> replaceKeys)
        {
            var result = _linkiFyService.UrlReplacement(string.Empty, replaceKeys);

            Assert.Equal(result, string.Empty);
        }

        [Fact]
        public void ToQueryStringValue()
        {
            string result = _linkiFyService.ToQueryStringValue<string>(new NameValueCollection { { "queryStringKey", "queryStringValue" } }, "queryStringKey");

            Assert.Equal(result, "queryStringValue");
        }

        [Fact]
        public void ParseQueryString()
        {
            var uri = new Uri("https://docs.microsoft.com/tr-tr/azure/devops/repos/git/git-config?tabs=visual-studio&view=azure-devops&viewFallbackFrom=vsts", UriKind.Absolute);

            IEnumerable<KeyValuePair<string, string>> keyValuePairs = _linkiFyService.ParseQueryString(uri);

            var result = keyValuePairs.ToList();

            Assert.Equal(result[0].Key, "tabs");
            Assert.Equal(result[0].Value, "visual-studio");

            Assert.Equal(result[1].Key, "view");
            Assert.Equal(result[1].Value, "azure-devops");

            Assert.Equal(result[2].Key, "viewFallbackFrom");
            Assert.Equal(result[2].Value, "vsts");
        }

        [Fact]
        public void ExtendQuery()
        {
            var result = _linkiFyService.ExtendQuery("https://docs.microsoft.com/tr-tr/azure/devops/repos/git/git-config", new Dictionary<string, string> { { "tabs", "visual-studio" }, { "view", "azure-devops" }, { "viewFallbackFrom", "vsts" } });

            Assert.Equal(result, "https://docs.microsoft.com/tr-tr/azure/devops/repos/git/git-config?tabs=visual-studio&view=azure-devops&viewFallbackFrom=vsts");
        }

        [Fact]
        public void GetFirstSlice()
        {
            var result = _linkiFyService.GetFirstSlice("ILinkiFy", 5);

            Assert.Equal(result, "ILink");
        }

        [Fact]
        public void GetLastSlice()
        {
            var result = _linkiFyService.GetLastSlice("ILinkiFy", 2);

            Assert.Equal(result, "Fy");
        }

        [Fact]
        public void CapitalizeFirst()
        {
            var result = _linkiFyService.CapitalizeFirst("there is no reason to worry about this code. move on to bigger problems!");

            Assert.Equal(result, "There is no reason to worry about this code. Move on to bigger problems!");
        }
    }
}
