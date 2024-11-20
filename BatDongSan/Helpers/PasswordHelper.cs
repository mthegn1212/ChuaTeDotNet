using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace BatDongSan.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            // Generate a salt
            var salt = new byte[16];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt); // Fill the salt with random bytes
            }

            // Hash the password using PBKDF2
            var hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            // Store the salt + hash (you may also choose to store salt and hash separately)
            return Convert.ToBase64String(salt) + ":" + hashedPassword;
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            var parts = storedHash.Split(':');
            if (parts.Length != 2)
            {
                throw new ArgumentException("Invalid stored password format.");
            }

            var salt = Convert.FromBase64String(parts[0]);
            var storedHashValue = parts[1];

            var enteredHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return storedHashValue == enteredHash;
        }
    }
}