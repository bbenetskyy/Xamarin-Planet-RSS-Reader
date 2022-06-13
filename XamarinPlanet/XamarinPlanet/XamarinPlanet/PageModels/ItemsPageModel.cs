using System;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xamarin.Forms;
using XamarinPlanet.Models;

namespace XamarinPlanet
{
    public class ItemsPageModel : BasePageModel
    {
        const string PUB_DATE_DESC = "Publication date descending";
        const string PUB_DATE_ASC = "Publication date ascending";

        private readonly IRssClient _rssClient;
        private string _sortBy;

        public ItemsPageModel(
            ILogger logger,
            IMvxNavigationService mvxNavigationService,
            IRssClient rssClient) : base(logger, mvxNavigationService)
        {
            _rssClient = rssClient;
            Items = new MvxObservableCollection<Item>();
            ChooseItemCommand = new MvxAsyncCommand<Item>(ExecuteChooseItemCommand);
            _sortBy = PUB_DATE_DESC;
        }

        public string[] SortBySource => new string[] { PUB_DATE_DESC, PUB_DATE_ASC };
        public string SortBy
        {
            get => _sortBy;
            set => SetProperty(ref _sortBy, value, () =>
            {
                var items = Items?.ToArray();
                Items.Clear();
                Items.AddRange(OrderBy(_sortBy, items));
            });
        }

        public MvxObservableCollection<Item> Items { get; }

        public IMvxAsyncCommand<Item> ChooseItemCommand { get; }

        public override async Task Initialize()
        {
            try
            {
                IsBusy = true;
                var contributors = await _rssClient.DownloadItems<Item>(RssClientConstants.ITEM_RSS_KEY);
                await Device.InvokeOnMainThreadAsync(() =>
                {
                    Items.AddRange(OrderBy(SortBy, contributors?.ToArray()));
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

        private Task ExecuteChooseItemCommand(Item item)
        {
            return MvxNavigationService.Navigate<ItemDetailsPageModel, Item>(item);
        }


        private Item[] OrderBy(string orderBy, Item[] items)
        {
            switch (orderBy)
            {
                case PUB_DATE_DESC:
                    return items?.OrderByDescending(x => x.PubDate)?.ToArray();
                case PUB_DATE_ASC:
                default:
                    return items?.OrderBy(x => x.PubDate)?.ToArray();
            }
        }

    }
}