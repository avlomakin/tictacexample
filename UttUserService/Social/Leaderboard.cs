using System;
using System.Collections.Generic;
using System.Linq;

namespace UttUserService.Social
{
    public class Leaderboard
    {
        public List<User> GetUsers()
        {
            return UserStorage();
        }

        public User GetUserAndStatistics()
        {
            return new User("Admin", 999)
            {
                Statistics = new Statistics(99.2, 100, 76.3, 1234)
            };
        }


        #region Mock

        private static List<User> UserStorage()
        {
            var rnd = new Random();
            return new List<User>(Enumerable.Repeat<User>(new User("Loser", 1234), 100));
        }

        #endregion
    }
}