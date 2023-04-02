using Blazorise;
using Blazorise.Providers;
using JGLB.Website.BlazoriseExt;
using System.Reflection;

namespace JGLB.Website
{
    public static class Config
    {
        public static IServiceCollection AddMyIcons(this IServiceCollection serviceCollection)
        {
            //反射创建内部类实例
            MyIconProvider.MaterialIconProvider = Assembly.Load("Blazorise.Icons.Material").CreateInstance("Blazorise.Icons.Material.MaterialIconProvider") as BaseIconProvider;
            //Transient
            serviceCollection.AddTransient<IIconProvider, MyIconProvider>();
            //Icon
            serviceCollection.AddTransient<Blazorise.Icon, MyIcon>();

            return serviceCollection;
        }
    }
}
