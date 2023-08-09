using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymmetriskKrypteringOpg
{
    public class DES
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
            var des = new DESCryptoServiceProvider();

            des.Mode = CipherMode.CBC;
            des.Padding = PaddingMode.PKCS7;
            des.Key = key;
            des.IV = iv;

            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write);

            cryptoStream.Write(textToEncrypt, 0, textToEncrypt.Length);
            cryptoStream.FlushFinalBlock();

            return memoryStream.ToArray();
        }

        public byte[] Decrypt(byte[] textToDecrypt, byte[] key, byte[] iv)
        {
            var decrypter = new DESCryptoServiceProvider();

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
