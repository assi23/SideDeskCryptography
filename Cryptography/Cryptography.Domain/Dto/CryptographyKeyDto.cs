namespace Cryptography.Domain.Dto
{
    public class CryptographyKeyDto
    {
        public byte[]? PublicKey { get; private set; }
        public byte[]? PrivateKey { get; private set; }

        public CryptographyKeyDto(byte[]? publicKey, byte[]? privateKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }
    }
}
