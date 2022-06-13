using System;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xamarin.Forms;
using XamarinPlanet.Models;

namespace XamarinPlanet
{
    public class ItemsPageModel : BasePageModel
    {
        private readonly IRssClient _rssClient;

        public ItemsPageModel(
            ILogger logger,
            IMvxNavigationService mvxNavigationService,
            IRssClient rssClient) : base(logger, mvxNavigationService)
        {
            _rssClient = rssClient;
            Items = new MvxObservableCollection<Item>();
        }

        public MvxObservableCollection<Item> Items { get; }

        public override async Task Initialize()
        {
            try
            {
                IsBusy = true;
                var contributors = await _rssClient.DownloadItems<Item>(RssClientConstants.ITEM_RSS_KEY);
                await Device.InvokeOnMainThreadAsync(() =>
                {
                    Items.AddRange(contributors);
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}