using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymmetriskKrypteringOpg
{
    public class AES
    {
        public byte[] GenerateRandomNumber(int length)
        {
            var rng = RandomNumberGenerator.Create();
            byte[] randomNumberOfBytes = new byte[length];

            rng.GetBytes(randomNumberOfBytes);

            return randomNumberOfBytes;
        }

        public byte[] Encrypt(byte[] textToEncrypt, byte[] key, byte[] iv)
        {
            var aes = new AesCryptoServiceProvider();

            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = key;
            aes.IV = iv;

            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

            cryptoStream.Write(textToEncrypt, 0, textToEncrypt.Length);
            cryptoStream.FlushFinalBlock();

            return memoryStream.ToArray();
        }

        public byte[] Decrypt(byte[] textToDecrypt, byte[] key, byte[] iv)
        {
            var decrypter = new AesCryptoServiceProvider();

            decrypter.Mode = CipherMode.CBC;
            decrypter.Padding = PaddingMode.PKCS7;
            decrypter.Key = key;
            decrypter.IV = iv;

            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, decrypter.CreateDecryptor(), CryptoStreamMode.Write);

            cryptoStream.Write(textToDecrypt, 0, textToDecrypt.Length);
            cryptoStream.FlushFinalBlockAsync();

            var decryptedBytes = memoryStream.ToArray();

            return decryptedBytes;
        }
    }
}
