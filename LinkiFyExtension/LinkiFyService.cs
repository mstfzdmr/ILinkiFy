using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using LinkiFyExtension.Models;

namespace LinkiFyExtension
{
    public class LinkiFyService : ILinkiFyService
    {
        public string GetLinkifyContent(string content, List<LinkiFyDataModel> valueToLinks)
        {
            if (string.IsNullOrEmpty(content))
                return string.Empty;

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
        public string UrlReplacement(string htmlContent, Dictionary<string, string> replaceKeys)
        {
            if (string.IsNullOrEmpty(htmlContent))
                return string.Empty;

            var pattern = string.Concat(@"\b", "(href=\"([^\"]*))", @"\b");
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var matches = regex.Matches(htmlContent);
            foreach (Match match in matches)
            {
                var matchValue = match?.Groups[2].Value;
                if (!replaceKeys.TryGetValue(matchValue, out string replacement))
                    continue;

                htmlContent = htmlContent.Replace(match.Value, $"{replacement}");
            }

            return htmlContent;
        }
        public T ToQueryStringValue<T>(NameValueCollection queryStringNameValueCollection, string queryStringKey)
        {
            if (queryStringNameValueCollection[queryStringKey] != null)
            {
                return (T)Convert.ChangeType(queryStringNameValueCollection[queryStringKey], typeof(T));
            }

            return (T)Convert.ChangeType(default(T), typeof(T));
        }
        public IEnumerable<KeyValuePair<string, string>> ParseQueryString(Uri uri)
        {
            if (uri == null)
                throw new ArgumentException("uri");

            var queryStringRegex = new Regex(@"[\?&](?<name>[^&=]+)=(?<value>[^&=]+)");
            var matches = queryStringRegex.Matches(uri.OriginalString);
            for (var i = 0; i < matches.Count; i++)
            {
                var match = matches[i];
                yield return new KeyValuePair<string, string>(match.Groups["name"].Value, match.Groups["value"].Value);
            }
        }
        public string ExtendQuery(string url, Dictionary<string, string> queryStringParameters)
        {
            foreach (var parameter in queryStringParameters)
            {
                url = url.IndexOf('?') == 0 ? $"{url}?{parameter.Key}={parameter.Value}" : $"{url}&{parameter.Key}={parameter.Value}";
            }

            return url;
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
        private string GetLast(string source, int tailLength)
        {
            if (tailLength >= source.Length)
                return source;

            return source.Substring(source.Length - tailLength);
        }
    }
}
