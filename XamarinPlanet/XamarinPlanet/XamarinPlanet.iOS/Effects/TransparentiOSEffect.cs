using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinPlanet.iOS.Effects;

[assembly:ResolutionGroupName ("XamarinPlanet")]
[assembly:ExportEffect (typeof(TransparentEntryiOSEffect), "TransparentEntry")]

namespace XamarinPlanet.iOS.Effects
{
    public class TransparentEntryiOSEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if(Control is UITextField textField)
            {
                textField.BorderStyle = UITextBorderStyle.None;
            }
        }

        protected override void OnDetached()
        {
        }
    }
}