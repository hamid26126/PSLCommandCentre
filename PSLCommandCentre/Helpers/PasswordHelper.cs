using System;
using System.Security.Cryptography;
using System.Text;

namespace PSLCommandCentre.Helpers
{
    public static class PasswordHelper
    {
        public static string Hash(string plainText)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                var sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));   // lowercase hex, matches our DB insert
                return sb.ToString();
            }
        }

        public static bool Verify(string plainText, string storedHash)
        {
            return Hash(plainText) == storedHash;
        }
    }
}