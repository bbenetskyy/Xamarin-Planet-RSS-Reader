using Xamarin.Forms;

namespace XamarinPlanet
{
    public class ResourceManager : IResourceManager
    {
        public T GetResource<T>(string key) where T : class => 
            Application.Current.Resources.TryGetValue(key, out var value)
                ? value as T
                : default;
        
        public T GetStructResource<T>(string key) where T : struct => 
            Application.Current.Resources.TryGetValue(key, out var value)
                ? value is T 
                    ? (T) value
                    : default
                : default;
    }
}