using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.IoC;
using XamarinPlanet.iOS.Services;

namespace XamarinPlanet.iOS
{
    public class Setup : MvxFormsIosSetup<CoreApp, App>
    {
        protected override IMvxIoCProvider InitializeIoC()
        {
            var ioc = base.InitializeIoC();

            // setup ios dependencies
            ioc.LazyConstructAndRegisterSingleton<IApplicationInfo, iOSApplicationInfo>();
            ioc.LazyConstructAndRegisterSingleton<ILocationService, iOSLocationService>();

            return ioc;
        }
    }
}