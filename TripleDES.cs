using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SymmetriskKrypteringOpg
{
    public class TripleDES
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
            var tripleDES = new TripleDESCryptoServiceProvider();

            tripleDES.Mode = CipherMode.CBC;
            tripleDES.Padding = PaddingMode.PKCS7;
            tripleDES.Key = key;
            tripleDES.IV = iv;

            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, tripleDES.CreateEncryptor(), CryptoStreamMode.Write);

            cryptoStream.Write(textToEncrypt, 0, textToEncrypt.Length);
            cryptoStream.FlushFinalBlock();

            return memoryStream.ToArray();
        }

        public byte[] Decrypt(byte[] textToDecrypt, byte[] key, byte[] iv)
        {
            var decrypter = new TripleDESCryptoServiceProvider();

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
