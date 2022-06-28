using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GOSTechnology.Providers.CryptoProvider.LIB
{
    /// <summary>
    /// CryptoProvider.
    /// </summary>
    public static class CryptoProvider
    {
        /// <summary>
        /// EncryptAES.
        /// </summary>
        /// <param name="text">Text for crypto in AES.</param>
        /// <param name="key">Key for crypto in AES.</param>
        /// <param name="iv">Iv for crypto in AES.</param>
        /// <returns></returns>
        public static String EncryptAES(String text, String key, String iv)
        {
            String result = default(String);

            if (String.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(ConstantsCryptoProvider.PARAM_TEXT, ConstantsCryptoProvider.MESSAGE_TEXT_ARGUMENT_NULL);
            }
            else if (String.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(ConstantsCryptoProvider.PARAM_KEY, ConstantsCryptoProvider.MESSAGE_KEY_ARGUMENT_NULL);
            }
            else if (String.IsNullOrWhiteSpace(iv))
            {
                throw new ArgumentNullException(ConstantsCryptoProvider.PARAM_IV, ConstantsCryptoProvider.MESSAGE_IV_ARGUMENT_NULL);
            }
            else if (32 < key?.Length)
            {
                throw new ArgumentOutOfRangeException(ConstantsCryptoProvider.PARAM_KEY, ConstantsCryptoProvider.MESSAGE_KEY_ARGUMENT_OUT_OF_RANGE);
            }
            else if (16 < iv?.Length)
            {
                throw new ArgumentOutOfRangeException(ConstantsCryptoProvider.PARAM_IV, ConstantsCryptoProvider.MESSAGE_IV_ARGUMENT_OUT_OF_RANGE);
            }

            result = CryptoExtension.EncryptAES(text, key, iv);

            return result;
        }

        /// <summary>
        /// DecryptAES.
        /// </summary>
        /// <param name="cipherText">Text for decrypto in AES.</param>
        /// <param name="key">Key for decrypto in AES.</param>
        /// <param name="iv">Iv for decrypto in AES.</param>
        /// <returns></returns>
        public static String DecryptAES(String cipherText, String key, String iv)
        {
            String result = default(String);

            if (String.IsNullOrWhiteSpace(cipherText))
            {
                throw new ArgumentNullException(ConstantsCryptoProvider.PARAM_CIPHER_TEXT, ConstantsCryptoProvider.MESSAGE_CIPHER_TEXT_ARGUMENT_NULL);
            }
            else if (String.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(ConstantsCryptoProvider.PARAM_KEY, ConstantsCryptoProvider.MESSAGE_KEY_ARGUMENT_NULL);
            }
            else if (String.IsNullOrWhiteSpace(iv))
            {
                throw new ArgumentNullException(ConstantsCryptoProvider.PARAM_IV, ConstantsCryptoProvider.MESSAGE_IV_ARGUMENT_NULL);
            }
            else if (32 < key?.Length)
            {
                throw new ArgumentOutOfRangeException(ConstantsCryptoProvider.PARAM_KEY, ConstantsCryptoProvider.MESSAGE_KEY_ARGUMENT_OUT_OF_RANGE);
            }
            else if (16 < iv?.Length)
            {
                throw new ArgumentOutOfRangeException(ConstantsCryptoProvider.PARAM_IV, ConstantsCryptoProvider.MESSAGE_IV_ARGUMENT_OUT_OF_RANGE);
            }

            result = CryptoExtension.DecryptAES(cipherText, key, iv);

            return result;
        }

        /// <summary>
        /// SetPasswordHash.
        /// </summary>
        /// <param name="password">Password for crypto in AES.</param>
        /// <returns></returns>
        public static String SetPasswordHash(String password)
        {
            String result = default(String);

            if (String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(ConstantsCryptoProvider.PARAM_PASSWORD, ConstantsCryptoProvider.MESSAGE_PASSWORD_ARGUMENT_NULL);
            }

            result = CryptoExtension.EncryptAES(password, ConstantsCryptoProvider.KEY_PASSWORD, ConstantsCryptoProvider.IV_PASSWORD);

            return result;
        }

        /// <summary>
        /// GetPasswordHash.
        /// </summary>
        /// <param name="cipherPassword ">Cipher password for decrypto in AES.</param>
        /// <returns></returns>
        public static String GetPasswordHash(String cipherPassword)
        {
            String result = default(String);

            if (String.IsNullOrWhiteSpace(cipherPassword))
            {
                throw new ArgumentNullException(ConstantsCryptoProvider.PARAM_CIPHER_PASSWORD, ConstantsCryptoProvider.MESSAGE_CIPHER_PASSWORD_ARGUMENT_NULL);
            }

            result = CryptoExtension.DecryptAES(cipherPassword, ConstantsCryptoProvider.KEY_PASSWORD, ConstantsCryptoProvider.IV_PASSWORD);

            return result;
        }
    }
}
