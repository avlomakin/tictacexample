
namespace UttUserService.Security
{
    public class Password
    {
        public int Id { get; set; } 

        public string Hash { get; set; }

        public string Salt { get; set; }

        public User User { get; set; }
    }
}