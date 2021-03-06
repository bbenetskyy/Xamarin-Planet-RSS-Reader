using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.IoC;
using MvvmCross.Logging.LogProviders;
using MvvmCross.ViewModels;

namespace XamarinPlanet
{
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MainPageModel>();
            
            //initialise IoC Dependencies
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ILogger, GlobalLogger>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IRssClient, RssClient>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IResourceManager, ResourceManager>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IMvxCommandHelper, MvxStrongCommandHelper>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IGeocodingService, GeocodingService>();
        }
    }
}