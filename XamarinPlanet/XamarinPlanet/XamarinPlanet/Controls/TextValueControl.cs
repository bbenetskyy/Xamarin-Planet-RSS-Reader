using MvvmCross;
using Xamarin.Forms;

namespace XamarinPlanet
{
    public class TextValueControl : Grid
    {
        public TextValueControl()
        {
            var resourceManager = Mvx.IoCProvider.Resolve<IResourceManager>();

            var visibilityBehaviour = new EmptyTextToVisibilityBehaviour();
            var leftLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.End,
                Style = resourceManager.GetResource<Style>("WhiteLabel")
            };
            var rightLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                Style = resourceManager.GetResource<Style>("WhiteLabel")
            };
            
            visibilityBehaviour.SetBinding(EmptyTextToVisibilityBehaviour.IsVisibleProperty, new Binding(nameof(IsVisible), source: this));
            leftLabel.SetBinding(Label.TextProperty, new Binding(nameof(Text), source: this, stringFormat: "{0}: "));
            rightLabel.SetBinding(Label.TextProperty, new Binding(nameof(Value), source: this));

            SetColumnDefinition();
            SetColumn(rightLabel, 1);

            rightLabel.Behaviors.Add(visibilityBehaviour);

            Children.Add(leftLabel);
            Children.Add(rightLabel);
        }

        private void SetColumnDefinition()
        {
            var columnDefinition = new ColumnDefinitionCollection();
            columnDefinition.Add(new ColumnDefinition
            {
                Width = GridLength.Auto
            });
            columnDefinition.Add(new ColumnDefinition
            {
                Width = GridLength.Star
            });

            ColumnDefinitions = columnDefinition;
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(TextValueControl));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            propertyName: nameof(Value),
            returnType: typeof(string),
            declaringType: typeof(TextValueControl));

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

    }
}