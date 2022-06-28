using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GOSTechnology.Providers.CryptoProvider.LIB
{
    /// <summary>
    /// CryptoExtension.
    /// </summary>
    public static class CryptoExtension
    {
        /// <summary>
        /// EncryptAES.
        /// </summary>
        /// <param name="text">Text in string for crypto in AES.</param>
        /// <param name="key">Key for crypto in AES.</param>
        /// <param name="iv">Iv for crypto in AES.</param>
        /// <returns></returns>
        public static String EncryptAES(String text, String key, String iv)
        {
            String result = default(String);

            Byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            Byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            Byte[] toEncrypt = Encoding.ASCII.GetBytes(text);

            result = EncryptAESFromBytes(toEncrypt, keyBytes, ivBytes);

            return result;
        }

        /// <summary>
        /// DecryptAES.
        /// </summary>
        /// <param name="cipherText">Text in string for decrypto in AES.</param>
        /// <param name="key">Key for decrypto in AES.</param>
        /// <param name="iv">Iv for decrypto in AES.</param>
        /// <returns></returns>
        public static String DecryptAES(String cipherText, String key, String iv)
        {
            String result = default(String);

            Byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            Byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            Byte[] toDecrypt = Convert.FromBase64String(cipherText);

            result = DecryptAESFromBytes(toDecrypt, keyBytes, ivBytes);

            return result;
        }

        /// <summary>
        /// EncryptAESFromBytes.
        /// </summary>
        /// <param name="text">Text in bytes for crypto in AES.</param>
        /// <param name="key">Key for crypto in AES.</param>
        /// <param name="iv">Iv for crypto in AES.</param>
        /// <returns></returns>
        private static String EncryptAESFromBytes(Byte[] text, Byte[] key, Byte[] iv)
        {
            String result = default(String);

            using (var rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.Mode = CipherMode.CBC;
                rijndaelManaged.Padding = PaddingMode.PKCS7;
                rijndaelManaged.FeedbackSize = 128;
                rijndaelManaged.KeySize = 256;
                rijndaelManaged.BlockSize = 128;
                rijndaelManaged.Key = key;
                rijndaelManaged.IV = iv;

                ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(text, 0, text.Length);
                        cryptoStream.FlushFinalBlock();
                        result = (Convert.ToBase64String(memoryStream.ToArray()));
                    }
                }
            };

            return result;
        }

        /// <summary>
        /// DecryptAESFromBytes.
        /// </summary>
        /// <param name="cipherText">Text in bytes for decrypto in AES.</param>
        /// <param name="key">Key for decrypto in AES.</param>
        /// <param name="iv">Iv for decrypto in AES.</param>
        /// <returns></returns>
        private static String DecryptAESFromBytes(Byte[] cipherText, Byte[] key, Byte[] iv)
        {
            String result = null;

            using (var rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.Mode = CipherMode.CBC;
                rijndaelManaged.Padding = PaddingMode.PKCS7;
                rijndaelManaged.FeedbackSize = 128;
                rijndaelManaged.KeySize = 256;
                rijndaelManaged.BlockSize = 128;
                rijndaelManaged.Key = key;
                rijndaelManaged.IV = iv;

                ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);

                using (var memoryStream = new MemoryStream(cipherText))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            result = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return result;
        }
    }
}
