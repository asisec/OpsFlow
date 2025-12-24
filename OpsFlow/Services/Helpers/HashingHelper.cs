using System;
using System.Security.Cryptography;
using System.Text;

namespace OpsFlow.Services.Helpers
{
    public static class HashingHelper
    {
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return string.Empty;

            using (var sha256 = SHA256.Create())
            {
                byte[] saltBytes = new byte[16];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(saltBytes);
                }

                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] combinedBytes = new byte[saltBytes.Length + passwordBytes.Length];

                Buffer.BlockCopy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
                Buffer.BlockCopy(passwordBytes, 0, combinedBytes, saltBytes.Length, passwordBytes.Length);

                byte[] hashBytes = sha256.ComputeHash(combinedBytes);

                string saltString = Convert.ToBase64String(saltBytes);
                string hashString = Convert.ToBase64String(hashBytes);

                return $"{saltString}:{hashString}";
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            if (string.IsNullOrEmpty(enteredPassword) || string.IsNullOrEmpty(storedHash))
                return false;

            var parts = storedHash.Split(':');
            if (parts.Length != 2) return false;

            string saltString = parts[0];
            string storedHashString = parts[1];

            byte[] saltBytes = Convert.FromBase64String(saltString);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(enteredPassword);
            byte[] combinedBytes = new byte[saltBytes.Length + passwordBytes.Length];

            Buffer.BlockCopy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, combinedBytes, saltBytes.Length, passwordBytes.Length);

            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                string computedHashString = Convert.ToBase64String(hashBytes);

                return storedHashString == computedHashString;
            }
        }
    }
}