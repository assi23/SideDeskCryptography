using Cryptography.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography.Service.Services
{
    public class DecryptService : CryptographyBase, IDecryptService
    {
        public string? Decrypt(string decryptString)
        {
            try
            {
                if (string.IsNullOrEmpty(decryptString))
                    return null;

                var publicPrivateKey = GetKey();

                var memoryStream = new MemoryStream();

                var inputByteArray = new byte[decryptString.Replace(" ", "+").Length];

                inputByteArray = Convert.FromBase64String(decryptString.Replace(" ", "+"));

                var des = new DESCryptoServiceProvider();

                var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(publicPrivateKey.PublicKey, publicPrivateKey.PrivateKey), CryptoStreamMode.Write);

                cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                cryptoStream.FlushFinalBlock();
                var encoding = Encoding.UTF8;
                return encoding.GetString(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Decrypt data error:" + ex);
            }
        }
    }
}
