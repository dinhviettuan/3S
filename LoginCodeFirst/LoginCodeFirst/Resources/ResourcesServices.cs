using System.Reflection;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Resources
{
    public class ResourcesServices<T>
    {
        private readonly IStringLocalizer _localizer;
 
        public ResourcesServices(IStringLocalizerFactory factory)
        {
            var type = typeof(T);
            var assemblyName = type.GetTypeInfo().Assembly.GetName().Name;
            var typeName = type.Name;
            _localizer = factory.Create(typeName, assemblyName);
        }
 
        public LocalizedString GetLocalizedHtmlString(string key)
        {
            return _localizer[key];
        }
        
        
    }
    public class BrandResources
    {}
    public class CommonResources
    {}
    public class CategoryResources
    {}
    public class LoginResources
    {}
    public class ProductResources
    {}
    public class StockResources
    {}
    public class StoreResources
    {}
    public class UserResources
    {}
}