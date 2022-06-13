using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinPlanet
{
    public interface IGeocodingService
    {
        Task<string> GetLocationDescription(Location location);
    }
}