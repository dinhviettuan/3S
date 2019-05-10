using System.Reflection;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Resources
{
    public class ResourcesServices
    {
        private readonly IStringLocalizer _localizer;
 
        public ResourcesServices(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResource", assemblyName.Name);
        }
 
        public LocalizedString GetLocalizedHtmlString(string key)
        {
            return _localizer[key];
        }
    }
}