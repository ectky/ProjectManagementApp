using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace PetShelter.Shared.Security
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            byte[] salt = GetSalt();

            var hash = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, 10000, 32);

            byte[] hashPassword = new byte[48];

            Buffer.BlockCopy(salt, 0, hashPassword, 0, 16);
            Buffer.BlockCopy(hash, 0, hashPassword, 16, 32);

            return Convert.ToBase64String(hashPassword);
        }

        private static byte[] GetSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(hashedPassword))
            {
                return false;
            }

            byte[] hashedPasswordInBytes = Convert.FromBase64String(hashedPassword);

            byte[] salt = new byte[16];
            Buffer.BlockCopy(hashedPasswordInBytes, 0, salt, 0, 16);

            var hash = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, 10000, 32);

            var hashBytes = new byte[32];
            Buffer.BlockCopy(hashedPasswordInBytes, 16, hashBytes, 0, 32);

            return hash.SequenceEqual<byte>(hashBytes);
        }
    }

}
