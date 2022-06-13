using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace XamarinPlanet
{
    public class BasePageModel : MvxViewModel
    {
        protected readonly ILogger Logger;
        protected readonly IMvxNavigationService MvxNavigationService;

        public BasePageModel(ILogger logger, IMvxNavigationService mvxNavigationService)
        {
            Logger = logger;
            MvxNavigationService = mvxNavigationService;
        }
        
    }
}