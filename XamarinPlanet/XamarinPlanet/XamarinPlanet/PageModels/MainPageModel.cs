using MvvmCross.ViewModels;

namespace XamarinPlanet
{
    public class MainPageModel : BasePageModel
    {
        private string _text;

        public MainPageModel()
        {
            Text = "<p><a href=\"https://www.syncfusion.com/blogs/post/lets-replicate-an-online-store-ui-in-xamarin-forms.aspx\"><img width=\"672\" height=\"372\" src=\"https://www.syncfusion.com/blogs/wp-content/uploads/2022/06/Lets-Replicate-an-Online-Store-UI-in-Xamarin.Forms_-672x372.png\" class=\"attachment-post-thumbnail size-post-thumbnail wp-post-image\" alt=\"Let&#039;s Replicate an Online Store UI in Xamarin.Forms\" /></a></p>Howdy! In this blog, we’ll replicate an online store UI based on this Dribbble design. We are going to develop...";
        }

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
    }
}