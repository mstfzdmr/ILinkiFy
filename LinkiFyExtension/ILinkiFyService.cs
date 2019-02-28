using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using LinkiFyExtension.Models;

namespace LinkiFyExtension
{
    public interface ILinkiFyService
    {
        string GetLinkifyContent(string content, List<LinkiFyDataModel> valueToLinks);
        string UrlReplacement(string htmlContent, Dictionary<string, string> replaceKeys);
        T ToQueryStringValue<T>(NameValueCollection queryStringNameValueCollection, string queryStringKey);
        IEnumerable<KeyValuePair<string, string>> ParseQueryString(Uri uri);
        string ExtendQuery(string url, Dictionary<string, string> queryStringParameters);
    }
}
