using System.Collections.Generic;


namespace UttUserService.Security
{
    public class User
    {
        public int Id { get; set; }

        public Password Password { get; set; }

        public string Username { get; set; }

        public List<Role> Roles { get; set; }  
    }
}