using UltraTT.Command;
using UltraTT.View;
using UltraTT.View.Game;
using UltraTT.View.Social;
using UltraTT.ViewModel.Social;

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
        public HotSeatPageView HotSeat => new HotSeatPageView();

        public LeaderboardPageView LeaderBoard => new LeaderboardPageView();

        public UserPageView UserPage => new UserPageView();
    }
}