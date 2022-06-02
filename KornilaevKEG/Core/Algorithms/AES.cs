using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace KornilaevKEG.Core.Algorithms
{
    class AES : ISymmetricAlgorithm
    {
        public string Name => "AES";
        Aes aesAlg = Aes.Create();
        public byte[] Decrypt(byte[] message, byte[] key)
        {
            if (message == null || message.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            string plaintext = null;
                aesAlg.Key = key;
                //aesAlg.GenerateIV();
                aesAlg.Padding = PaddingMode.None;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(message))
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            plaintext = srDecrypt.ReadToEnd();
            return Encoding.UTF8.GetBytes(plaintext);
        }

        public byte[] Encrypt(byte[] message, byte[] key)
        {
            if (message == null || message.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;

                aesAlg.Key = key;
                //aesAlg.GenerateIV();
                aesAlg.Padding = PaddingMode.Zeros;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            swEncrypt.Write(message);
                        encrypted = msEncrypt.ToArray();
                    }
            return encrypted;
        }
    }
}
