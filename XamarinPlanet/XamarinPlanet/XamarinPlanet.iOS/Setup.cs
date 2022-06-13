using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.IoC;

namespace XamarinPlanet.iOS
{
    public class Setup : MvxFormsIosSetup<CoreApp, App>
    {
        protected override IMvxIoCProvider InitializeIoC()
        {
            var ioc = base.InitializeIoC();

            // setup ios dependencies

            return ioc;
        }
    }
}