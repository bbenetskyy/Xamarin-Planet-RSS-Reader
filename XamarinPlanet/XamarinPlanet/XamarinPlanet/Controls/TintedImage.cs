using System;
using Xamarin.Forms;

namespace XamarinPlanet.Controls
{
    public class TintedImage : Image
    {
        public static readonly BindableProperty TintColorProperty = BindableProperty.Create(
            propertyName: nameof(TintColor),
            returnType: typeof(Color),
            declaringType: typeof(TintedImage),
            defaultValue: default,
            defaultBindingMode: BindingMode.TwoWay);

        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }
    }
}
