using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinPlanet.Droid.Effects;

[assembly:ResolutionGroupName ("XamarinPlanet")]
[assembly:ExportEffect (typeof(TransparentEntryAndroidEffect), "TransparentEntry")]

namespace XamarinPlanet.Droid.Effects
{
    public class TransparentEntryAndroidEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if(Control is EditText editText)
            {
                editText.SetBackgroundColor(Color.Transparent.ToAndroid());
            }
        }

        protected override void OnDetached()
        {
        }
    }
}