using System.Threading.Tasks;
using CoreLocation;
using Xamarin.Essentials;

namespace XamarinPlanet.iOS.Services
{
    public class iOSLocationService : ILocationService
    {
        public bool IsServiceEnabled() => CLLocationManager.LocationServicesEnabled;

        public async Task<Location> GetLocation()
        {
            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                AppInfo.ShowSettingsUI();
                return null;
            }
            
            return await Geolocation.GetLocationAsync();
        }
    }
}