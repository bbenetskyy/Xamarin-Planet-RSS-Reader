using System;
using System.Collections.ObjectModel;
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

        public ContributorsPageModel(
            ILogger logger, 
            IMvxNavigationService mvxNavigationService,
            IRssClient rssClient) 
            : base(logger, mvxNavigationService)
        {
            _rssClient = rssClient;
            Contributors = new MvxObservableCollection<Contributor>();
        }
        
        public MvxObservableCollection<Contributor> Contributors { get; }

        public override async Task Initialize()
        {
            try
            {
                IsBusy = true;
                var contributors = await _rssClient.DownloadItems<Contributor>(RssClientConstants.CONTRIBUTOR_RSS_KEY);
                await Device.InvokeOnMainThreadAsync(() =>
                {
                    Contributors.AddRange(contributors);
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