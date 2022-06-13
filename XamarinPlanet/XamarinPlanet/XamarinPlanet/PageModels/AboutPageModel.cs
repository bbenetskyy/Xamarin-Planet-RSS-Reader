using System;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using Xamarin.Forms;

namespace XamarinPlanet
{
    public class AboutPageModel : BasePageModel
    {
        private readonly IApplicationInfo _applicationInfo;
        private readonly ILocationService _locationService;
        private readonly IGeocodingService _geocodingService;
        
        private string _appName;
        private string _appVersion;
        private string _geolocation;

        public AboutPageModel(
            ILogger logger, 
            IMvxNavigationService mvxNavigationService,
            IApplicationInfo applicationInfo,
            ILocationService locationService,
            IGeocodingService geocodingService) 
            : base(logger, mvxNavigationService)
        {
            _applicationInfo = applicationInfo;
            _locationService = locationService;
            _geocodingService = geocodingService;
        }

        public string AppName
        {
            get => _appName;
            set => SetProperty(ref _appName, value);
        }

        public string AppVersion
        {
            get => _appVersion;
            set => SetProperty(ref _appVersion, value);
        }

        public string Geolocation
        {
            get => _geolocation;
            set => SetProperty(ref _geolocation, value);
        }

        public override async Task Initialize()
        {
            try
            {
                IsBusy = true;
                AppName = _applicationInfo.Name;
                AppVersion = _applicationInfo.Version;

                if (!_locationService.IsServiceEnabled())
                {
                    Geolocation = "Geolocation is not enabled on device";
                    return;
                }

                var location = await _locationService.GetLocation();
                if (location == null)
                {
                    Geolocation = "Can't get location at the moment";
                    return;
                }

                Geolocation = await _geocodingService.GetLocationDescription(location);
            }
            catch (Exception ex)
            {
                Geolocation = ex.Message;
                Logger.LogError(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}