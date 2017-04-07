using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace UttUserService.Security
{
    public class AuthenticationService : IAuthenticationService
    {

        public User AuthenticateUser(string username, string textPassword)
        {
            User user = Users.FirstOrDefault(u => u.Username == username);


            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

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

        private static readonly List<User> Users = new List<User>()
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