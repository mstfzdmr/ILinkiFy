using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkiFyExtension;
using LinkiFyExtension.Models;
using System.Collections.Generic;

namespace ILinkiFyTests
{
    [TestClass]
    public class LinkiFyExtensionUnitTest
    {
        private string content;

        private List<LinkiFyDataModel> valueToLinks;

        private ILinkiFyService linkiFyService;

        [TestInitialize]
        public void Initialize()
        {
            content = "GitHub is a development platform inspired by the way you work. From open source to business, you can host and review code, manage projects, and build software alongside millions of other developers.";

            valueToLinks = new List<LinkiFyDataModel>() {
                new LinkiFyDataModel { Text = "open source", Value = "https://github.com/open-source" },
                new LinkiFyDataModel { Text = "business", Value = "https://github.com/business" },
                new LinkiFyDataModel { Text = "developers", Value = "https://github.com/mstfzdmr" }
            };

            linkiFyService = new LinkiFyService();
        }

        [TestMethod]
        public void LinkiFyService_ShouldBeSuccessTest()
        {
            var linkiFyContent = linkiFyService.GetLinkifyContent(content, valueToLinks);
            Assert.IsNotNull(linkiFyContent);
            Assert.AreNotEqual(linkiFyContent, content); 
        }

        [TestMethod]
        public void LinkiFyService_ShouldBeContentNullTest()
        {
            var linkiFyContent = linkiFyService.GetLinkifyContent(content, valueToLinks);
            Assert.IsNull(linkiFyContent);
            Assert.AreEqual(linkiFyContent, content);
        }
    }
}
