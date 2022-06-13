using MvvmCross;
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
        }
    }
}