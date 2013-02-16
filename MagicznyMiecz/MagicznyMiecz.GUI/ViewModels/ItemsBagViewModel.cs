using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;

namespace MagicznyMiecz.GUI.ViewModels
{
    public class ItemsBagViewModel : ViewModelBase
    {
        public IBag<IItem> Items
        {
            get { return this._playerViewModel.Character.Items; }
        }

        private readonly PlayerViewModel _playerViewModel;

        public ItemsBagViewModel(PlayerViewModel playerViewModel)
        {
            this._playerViewModel = playerViewModel;
        }
    }
}