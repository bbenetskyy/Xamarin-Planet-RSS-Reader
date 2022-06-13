using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Newtonsoft.Json;
using XamarinPlanet.Models;
using Formatting = Newtonsoft.Json.Formatting;

namespace XamarinPlanet
{
    public class MainPageModel : BasePageModel
    {
        public MainPageModel(ILogger logger, IMvxNavigationService mvxNavigationService) : base(logger, mvxNavigationService)
        {
            OpenContributorsCommand = new MvxAsyncCommand(ExecuteOpenContributorsCommand);
            OpenItemsCommand = new MvxAsyncCommand(ExecuteOpenItemsCommand);
            OpenAboutCommand = new MvxAsyncCommand(ExecuteOpenAboutCommand);
        }

        public IMvxCommand OpenContributorsCommand { get; }
        public IMvxCommand OpenItemsCommand { get; }
        public IMvxCommand OpenAboutCommand { get; }

        private Task ExecuteOpenContributorsCommand() => MvxNavigationService.Navigate<ContributorsPageModel>();
        private Task ExecuteOpenItemsCommand() => MvxNavigationService.Navigate<ItemsPageModel>();
        private Task ExecuteOpenAboutCommand() => MvxNavigationService.Navigate<AboutPageModel>();
    }
}