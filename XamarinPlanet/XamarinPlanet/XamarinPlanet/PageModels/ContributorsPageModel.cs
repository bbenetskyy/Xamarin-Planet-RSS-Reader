using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xamarin.Forms;
using XamarinPlanet.Models;

namespace XamarinPlanet
{
    public class ContributorsPageModel : BasePageModel
    {
        private readonly IRssClient _rssClient;
        private readonly FilterManager _filterManager;

        private string _searchText;
        private List<Contributor> _contributors = new();

        public ContributorsPageModel(
            ILogger logger, 
            IMvxNavigationService mvxNavigationService,
            IRssClient rssClient) 
            : base(logger, mvxNavigationService)
        {
            _rssClient = rssClient;
            _filterManager = new FilterManager();
            Contributors = new MvxObservableCollection<Contributor>();
        }

        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value, () => _ = FilterItems());
        }

        public MvxObservableCollection<Contributor> Contributors { get; }

        public override async Task Initialize()
        {
            try
            {
                IsBusy = true;
                _contributors = await _rssClient.DownloadItems<Contributor>(RssClientConstants.CONTRIBUTOR_RSS_KEY);
                await Device.InvokeOnMainThreadAsync(() =>
                {
                    Contributors.AddRange(_contributors);
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
        
        private async Task FilterItems()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SearchText))
                {
                    await Device.InvokeOnMainThreadAsync(() =>
                    {
                        Contributors.ReplaceWith(_contributors);
                    });
                    return;
                }

                var filteredContributors = _filterManager.FilterByContributors(_contributors, SearchText);
                await Device.InvokeOnMainThreadAsync(() =>
                {
                    if (filteredContributors.Any())
                    {
                        Contributors.ReplaceWith(filteredContributors);
                    }
                    else
                    {
                        Contributors.Clear();
                    }
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}