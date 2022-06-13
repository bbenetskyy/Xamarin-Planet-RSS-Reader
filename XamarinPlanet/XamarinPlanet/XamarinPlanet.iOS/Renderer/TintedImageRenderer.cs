using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinPlanet.Controls;
using XamarinPlanet.iOS.Renderer;

[assembly: ExportRenderer(typeof(TintedImage), typeof(TintedImageRenderer))]
namespace XamarinPlanet.iOS.Renderer
{
    public class TintedImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            SetTint();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            SetTint();
        }

        void SetTint()
        {
            if (Control?.Image == null || Element == null)
                return;
            Control.Image = Control.Image.ImageWithRenderingMode(UIKit.UIImageRenderingMode.AlwaysTemplate);
            Control.TintColor = ((TintedImage)Element).TintColor.ToUIColor();
        }
    }
}
