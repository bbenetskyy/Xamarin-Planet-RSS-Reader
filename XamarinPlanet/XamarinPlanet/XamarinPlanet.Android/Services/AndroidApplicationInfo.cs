using Android.Content.PM;
using Xamarin.Essentials;

namespace XamarinPlanet.Droid.Services
{
    public class AndroidApplicationInfo : IApplicationInfo
    {
        public AndroidApplicationInfo()
        {
            var applicationInfo = Platform.AppContext.ApplicationInfo;
            var packageManager = Platform.AppContext.PackageManager;
            var pm = Platform.AppContext.PackageManager;
            var packageName = Platform.AppContext.PackageName;

            using var info = pm?.GetPackageInfo(packageName, PackageInfoFlags.MetaData);
            
            Name = applicationInfo?.LoadLabel(packageManager);     
            Version = info?.VersionName;
        }
        
        public string Name { get; }
        public string Version { get; }
    }
}