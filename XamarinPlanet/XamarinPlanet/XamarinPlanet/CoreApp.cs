using MvvmCross.ViewModels;

namespace XamarinPlanet
{
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MainPageModel>();
            //initialise IoC Dependencies
        }
    }
}