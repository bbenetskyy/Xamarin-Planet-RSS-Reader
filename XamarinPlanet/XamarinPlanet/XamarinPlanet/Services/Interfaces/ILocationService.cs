using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinPlanet
{
    public interface ILocationService
    {
        bool IsServiceEnabled();
        Task<Location> GetLocation();
    }
}