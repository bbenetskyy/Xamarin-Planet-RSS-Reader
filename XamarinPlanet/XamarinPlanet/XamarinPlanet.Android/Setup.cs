using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.IoC;

namespace XamarinPlanet.Droid
{
    public class Setup: MvxFormsAndroidSetup<CoreApp, App>
    {
        protected override IMvxIoCProvider InitializeIoC()
        {
            var ioc = base.InitializeIoC();

            //register platform dependencies
            
            return ioc;
        }
    }
}