using System.ComponentModel;
using Xamarin.Forms;

namespace XamarinPlanet
{
    public class EmptyTextToVisibilityBehaviour : Behavior<Label>
    {
        public bool IsVisible
        {
            get => (bool)GetValue(IsVisibleProperty);
            set => SetValue(IsVisibleProperty, value);
        }
        
        public static readonly BindableProperty IsVisibleProperty = BindableProperty.Create(
            propertyName: nameof(IsVisible),
            returnType: typeof(bool),
            declaringType: typeof(EmptyTextToVisibilityBehaviour),
            defaultBindingMode: BindingMode.OneWayToSource);
        
        protected override void OnAttachedTo(Label bindable)
        {
            bindable.PropertyChanged += BindableOnPropertyChanged;
        }

        protected override void OnDetachingFrom(Label bindable)
        {
            bindable.PropertyChanged -= BindableOnPropertyChanged;
        }
        
        private void BindableOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Label.Text) && sender is Label label)
            {
                IsVisible = !string.IsNullOrWhiteSpace(label.Text);
            }
        }
    }
}