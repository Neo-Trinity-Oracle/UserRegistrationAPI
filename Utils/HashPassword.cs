using System.Security.Cryptography;
using System.Text;

namespace UserRegistrationApi.Utils
{
    public class HashPassword
    {
        public string Hash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public bool VerifyPassword(string hashedPassword, string plainPassword)
        {
            var hashOfInput = Hash(plainPassword);
            return hashedPassword == hashOfInput;
        }
    }
}
