using Cryptography.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography.Service.Services
{
    public class EncryptService : CryptographyBase, IEncryptService
    {
        public string? Encrypt(string encryptString)
        {
            try
            {
                if (string.IsNullOrEmpty(encryptString))
                    return null;

                var publicPrivateKey = GetKey();

                var memoryStream = new MemoryStream();

                var inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                var des = new DESCryptoServiceProvider();

                var cryptStream = new CryptoStream(memoryStream, des.CreateEncryptor(publicPrivateKey.PublicKey, publicPrivateKey.PrivateKey), CryptoStreamMode.Write);
                cryptStream.Write(inputByteArray, 0, inputByteArray.Length);
                cryptStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Encrypt data error:" + ex);
            }
        }
    }
}
