namespace XamarinPlanet
{
    public interface IResourceManager
    {
        T GetResource<T>(string key) where T : class;
        T GetStructResource<T>(string key) where T : struct;
    }
}