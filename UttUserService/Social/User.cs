using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UttUserService.Social
{
    public class User
    {
        public User(string username, int score, ImageSource avatar)
        {
            Username = username;
            Score = score;
            Avatar = avatar;
        }

        public User(string username, int score)
        {
            Username = username;
            Score = score;
            Avatar = null;
        }

        public string Username { get; }

        public int Score { get; }

        public ImageSource Avatar { get; }

        public Statistics Statistics { get; set; }
    }
}