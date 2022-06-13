using System.Threading.Tasks;
using Android.Content;
using Android.Locations;
using Xamarin.Essentials;
using Location = Xamarin.Essentials.Location;

namespace XamarinPlanet.Droid.Services
{
    public class AndroidLocationService : ILocationService
    {
        public bool IsServiceEnabled()
        {
            var locationManager = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);
            return locationManager.IsProviderEnabled(LocationManager.GpsProvider);
        }

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