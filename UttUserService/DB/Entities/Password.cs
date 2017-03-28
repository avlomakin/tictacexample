using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UttUserService.DB.Entities
{
    [Table("password")]
    public class Password
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; } 

        public string Hash { get; set; }

        public string Salt { get; set; }

        public User User { get; set; }
    }
}