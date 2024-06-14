using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Register_and_login_test
{
    public class CCryptography
    {
        public static byte[] GetSaltBytes(string saltString)
        {
            return Encoding.UTF8.GetBytes(saltString);
        }

        //temp funtion  //生成带盐的哈希值
        static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        
        public static string HashPasswordWithSalt(string password, byte[] salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                //string saltString = "gugubird";
                //byte[] saltBytes = GetSaltBytes(saltString);
                byte[] saltedPassword = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
                byte[] hash = sha256.ComputeHash(saltedPassword);
                return Convert.ToBase64String(hash);
            }
        }

        public static string HashPasswordWithSalt(string password) 
        {
            string saltString = "gugubird";
            byte[] saltBytes = GetSaltBytes(saltString);
            return HashPasswordWithSalt(password, saltBytes);
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, string saltString)
        {
            byte[] saltBytes = GetSaltBytes(saltString);
            string hashOfEnteredPassword = HashPasswordWithSalt(enteredPassword, saltBytes);
            return hashOfEnteredPassword == storedHash;
        }

        

    }
}
