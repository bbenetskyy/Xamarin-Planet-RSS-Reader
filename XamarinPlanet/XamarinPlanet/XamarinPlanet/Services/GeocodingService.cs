using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinPlanet
{
    public class GeocodingService : IGeocodingService
    {
        public async Task<string> GetLocationDescription(Location location)
        {
            var placeMarks = await Geocoding.GetPlacemarksAsync(location);
            return placeMarks.FirstOrDefault()?.ToString();
        }
    }
}