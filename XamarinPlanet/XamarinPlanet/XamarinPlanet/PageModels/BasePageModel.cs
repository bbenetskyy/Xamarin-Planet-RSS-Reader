using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace XamarinPlanet
{
    public class BasePageModel : MvxViewModel
    {
        protected readonly ILogger Logger;
        protected readonly IMvxNavigationService MvxNavigationService;
        
        private bool _isBusy;

        public BasePageModel(ILogger logger, IMvxNavigationService mvxNavigationService)
        {
            Logger = logger;
            MvxNavigationService = mvxNavigationService;
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
    }
}