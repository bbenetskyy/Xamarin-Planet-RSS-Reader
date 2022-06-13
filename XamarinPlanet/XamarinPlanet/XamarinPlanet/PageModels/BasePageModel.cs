using MvvmCross.ViewModels;

namespace XamarinPlanet
{
    public class BasePageModel : MvxViewModel
    {
        protected readonly ILogger Logger;

        public BasePageModel(ILogger logger)
        {
            Logger = logger;
        }
        
    }
}