using System.Collections.Generic;
using UttUserService.Social;

namespace UltraTT.ViewModel.Social
{
    public class LeaderboardPageViewModel : BaseViewModel
    {

        public LeaderboardPageViewModel()
        {
            Users = new Leaderboard().GetUsers();
        }

        private List<User> _users;
        public List<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;

                OnPropertyChanged();
            }
        }

    }
}