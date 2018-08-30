using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace IrlFfLeague.Web.Helpers
{
    public static class Functions
    {
        public static string GetPopulateAttributeName(ViewDataDictionary viewData)
        {
            var containerType = viewData.ModelMetadata.ContainerType;
            var propertyName = viewData.ModelMetadata.PropertyName;
            var name = containerType.GetProperty(propertyName).GetCustomAttributes(false).Select(a => a.GetType().Name).First(n => n.StartsWith("Populate"));

            return name;
        }
    }
}
