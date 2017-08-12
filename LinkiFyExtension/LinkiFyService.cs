using System.Collections.Generic;
using System.Text.RegularExpressions;
using LinkiFyExtension.Models;

namespace LinkiFyExtension
{
    public class LinkiFyService : ILinkiFyService
    {
        public string GetLinkifyContent(string content, List<LinkiFyDataModel> valueToLinks)
        {
            if (string.IsNullOrEmpty(content))
            {
                return string.Empty;
            }

            var replacedLinkiFyMaxLinkCount = 0;
            var replacedContent = content;

            foreach (var item in valueToLinks)
            {
                var pattern = item.Text;
                replacedContent = FindAndConcat(content, pattern, item.Value, 1);
                replacedLinkiFyMaxLinkCount += string.CompareOrdinal(content, replacedContent) != 0 ? 1 : 0;
                content = replacedContent;
                if (replacedLinkiFyMaxLinkCount >= 20)
                {
                    break;
                }
            }

            return replacedContent;
        }

        private string FindAndConcat(string content, string word, string link, int replaceCount)
        {
            var result = content ?? string.Empty;
            var patternWord = string.Concat(@"\b", word, @"\b");
            var pattern = string.Concat(@"(<a\shref=""(?:.*?)"">(?<anchortext>.*?)</a>)|(?<targetmatch>", patternWord, @")");
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var matches = regex.Matches(result);

            var replacementCounter = 0;
            foreach (Match match in matches)
            {
                if (match.Groups["targetmatch"].Value.Length <= 0)
                {
                    continue;
                }

                var firstPart = result.Substring(0, match.Groups["targetmatch"].Index);
                var secondPart = result.Substring(match.Groups["targetmatch"].Index + match.Groups["targetmatch"].Length);
                var replacement = string.Concat(@"<a href=""", link, @""">" + match.Groups["targetmatch"].Value + "</a>");
                if (replacementCounter++ >= replaceCount)
                {
                    break;
                }

                result = firstPart + replacement + secondPart;
            }

            return result;
        }
    }
}
