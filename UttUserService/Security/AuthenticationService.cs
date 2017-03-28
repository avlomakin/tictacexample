using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UttUserService.DB;
using UttUserService.DB.Entities;

namespace UttUserService.Security
{
    public class AuthenticationService : IAuthenticationService
    {
        public User AuthenticateUser(string username, string textPassword)
        {
            //AuthContext authContext = new AuthContext();
            //User user = authContext.Users.FirstOrDefault(u => u.Username == username);
            User user = _users.FirstOrDefault(u => u.Username == username);


            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            //Password userPassword = authContext.Passwords.FirstOrDefault(p => p.User.Id == user.Id);
            Password userPassword = user.Password;

            if (userPassword == null)
            {
                throw new UnauthorizedAccessException();
            }

            string hashPassword = CalculateHash(textPassword, userPassword.Salt);

            if (hashPassword == userPassword.Hash)
            {
                return user;
            }
            throw new UnauthorizedAccessException();
        }

        private string CalculateHash(string textPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(textPassword + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }

        #region NeedDelete

        private static readonly List<User> _users = new List<User>()
        {
            new User()
            {
                Id = 1,
                Roles = new List<Role>()
                {
                    Role.User,
                    Role.Adminsitrator
                },
                Username = "Admin",
                Password = new Password()
                {
                    Id = 1,
                    Hash = "xwTbOsdKA0KO76NurjcxBTZPDtohnWAVwO8ui0BWwfU=",
                    Salt = "123"
                }
            }
        };

        #endregion
    }
}