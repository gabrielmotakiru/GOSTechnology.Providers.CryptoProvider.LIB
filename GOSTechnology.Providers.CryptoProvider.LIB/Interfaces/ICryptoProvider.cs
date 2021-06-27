using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GOSTechnology.Providers.CryptoProvider.LIB
{
    /// <summary>
    /// ICryptoProvider.
    /// </summary>
    public interface ICryptoProvider
    {
        /// <summary>
        /// EncryptAES.
        /// </summary>
        /// <param name="text">Text for crypto in AES.</param>
        /// <param name="key">Key for crypto in AES.</param>
        /// <param name="iv">Iv for crypto in AES.</param>
        /// <returns></returns>
        String EncryptAES(String text, String key, String iv);

        /// <summary>
        /// EncryptAESAsync.
        /// </summary>
        /// <param name="text">Text for crypto in AES.</param>
        /// <param name="key">Key for crypto in AES.</param>
        /// <param name="iv">Iv for crypto in AES.</param>
        /// <returns></returns>
        Task<String> EncryptAESAsync(String text, String key, String iv);

        /// <summary>
        /// DecryptAES.
        /// </summary>
        /// <param name="cipherText">Text for decrypto in AES.</param>
        /// <param name="key">Key for decrypto in AES.</param>
        /// <param name="iv">Iv for decrypto in AES.</param>
        /// <returns></returns>
        String DecryptAES(String cipherText, String key, String iv);

        /// <summary>
        /// DecryptAESAsync.
        /// </summary>
        /// <param name="cipherText">Text for decrypto in AES.</param>
        /// <param name="key">Key for decrypto in AES.</param>
        /// <param name="iv">Iv for decrypto in AES.</param>
        /// <returns></returns>
        Task<String> DecryptAESAsync(String cipherText, String key, String iv);
    }
}
