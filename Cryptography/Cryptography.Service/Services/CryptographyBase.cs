using Cryptography.Domain.Dto;
using System.Text;

namespace Cryptography.Service.Services
{
    public abstract class CryptographyBase
    {
       protected CryptographyKeyDto GetKey()
        {
            var publickey = "sidedesk";
            var secretkey = "sdD9=111";

            var publicKeyByte = Encoding.UTF8.GetBytes(publickey);
            var secretKeyByte = Encoding.UTF8.GetBytes(secretkey);

            return new CryptographyKeyDto(publicKeyByte, secretKeyByte);
        }
    }
}
