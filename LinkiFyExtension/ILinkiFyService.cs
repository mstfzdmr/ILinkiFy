using System.Collections.Generic;
using LinkiFyExtension.Models;

namespace LinkiFyExtension
{
    public interface ILinkiFyService
    {
        string GetLinkifyContent(string content, List<LinkiFyDataModel> valueToLinks);
    }
}
