using Foundation;

namespace XamarinPlanet.iOS.Services
{
    public class iOSApplicationInfo : IApplicationInfo
    {
        public iOSApplicationInfo()
        {
            Name = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleDisplayName").ToString();
            Version= NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();
        }
        
        public string Name { get; }
        public string Version { get; }
    }
}