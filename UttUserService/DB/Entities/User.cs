using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UttUserService.DB.Entities
{
    [Table("user")]
    public class User
    {

        [Key]
        public int Id { get; set; }

        public Password Password { get; set; }

        [Required]
        public string Username { get; set; }

        public int Score { get; set; }

        public List<Role> Roles { get; set; }  
    }
}