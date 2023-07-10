using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utilities.PasswordHelper
{
    internal class PasswordHelper
    {
        public static void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSlat)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSlat = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }
        public static bool VerifyPassword(string password, byte[] hashedPassword, byte[] saltPassword)
        {
            using (var hmac = new HMACSHA512(saltPassword))
            {
                var computetHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computetHash.SequenceEqual(hashedPassword);
            }
        }
    }
}
