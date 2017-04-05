using System.Collections.Generic;
using UttUserService.Social;

namespace UltraTT.ViewModel.Social
{
    public class UserPageViewModel : BaseViewModel
    {

        public UserPageViewModel()
        {
            User = new Leaderboard().GetUserAndStatistics();
            Statistics = User.Statistics;
        }

        private User _user;
        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;

                OnPropertyChanged();
            }
        }


        private Statistics _statistics;
        public Statistics Statistics
        {
            get
            {
                return _statistics;
            }
            set
            {
                _statistics = value;

                OnPropertyChanged();
            }
        }

    }
}