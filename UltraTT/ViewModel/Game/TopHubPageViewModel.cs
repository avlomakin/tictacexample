using UltraTT.Command;
using UltraTT.View;
using UltraTT.View.Game;

namespace UltraTT.ViewModel.Game
{
    public class TopHubPageViewModel : BaseViewModel
    {

        public TopHubPageViewModel()
        {
            _showCommand = new RelayCommand(Navigator.GetInstance().Show);
        }

        private RelayCommand _showCommand;
        public RelayCommand ShowCommand
        {
            get
            {
                return _showCommand;
            }
            set
            {
                _showCommand = value;

                OnPropertyChanged();
            }
        }
        public object HotSeat => new HotSeatPageView();
    }
}