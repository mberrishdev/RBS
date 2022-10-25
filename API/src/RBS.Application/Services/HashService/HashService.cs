using System.Security.Cryptography;
using System.Text;

namespace RBS.Application.Services.HashService
{
    public class HashService : IHashService
    {
        public string Hash(string password)
        {
            using MD5 mD5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = mD5.ComputeHash(bytes);

            StringBuilder sb = new();
            foreach (var t in hashBytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
