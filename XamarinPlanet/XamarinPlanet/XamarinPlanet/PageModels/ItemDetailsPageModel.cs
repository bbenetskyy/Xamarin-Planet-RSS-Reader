using MvvmCross.Navigation;
using XamarinPlanet.Models;

namespace XamarinPlanet.PageModels
{
    public class ItemDetailsPageModel : BasePageModel<Item>
    {
        private Item _model;

        public ItemDetailsPageModel(ILogger logger,
                                    IMvxNavigationService mvxNavigationService) : base(logger, mvxNavigationService)
        {
        }
        public Item Model
        {
            get => _model;
            set => SetProperty(ref _model, value);
        }

        public override void Prepare(Item parameter)
        {
            Model = parameter;
        }
    }
}
