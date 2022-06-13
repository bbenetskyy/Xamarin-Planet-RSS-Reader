using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.IoC;
using XamarinPlanet.Droid.Services;

namespace XamarinPlanet.Droid
{
    public class Setup: MvxFormsAndroidSetup<CoreApp, App>
    {
        protected override IMvxIoCProvider InitializeIoC()
        {
            var ioc = base.InitializeIoC();

            //register platform dependencies
            ioc.LazyConstructAndRegisterSingleton<IApplicationInfo, AndroidApplicationInfo>();
            ioc.LazyConstructAndRegisterSingleton<ILocationService, AndroidLocationService>();
            
            return ioc;
        }
    }
}