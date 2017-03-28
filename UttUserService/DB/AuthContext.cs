using System.Data.Entity;
using UttUserService.DB.Entities;

namespace UttUserService.DB
{
    public class AuthContext : DbContext
    {
        // Имя будущей базы данных можно указать через
        // вызов конструктора базового класса
        public AuthContext() : base("LoginDb")
        { }

        // Отражение таблиц базы данных на свойства с типом DbSet
        public DbSet<User> Users { get; set; }
        internal DbSet<Password> Passwords { get; set; }
    }
}