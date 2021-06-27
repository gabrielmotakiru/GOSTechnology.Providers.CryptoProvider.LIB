using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GOSTechnology.Providers.CryptoProvider.LIB
{
    /// <summary>
    /// CryptoProvider.
    /// </summary>
    public class CryptoProvider : ICryptoProvider
    {
        /// <summary>
        /// _logger.
        /// </summary>
        private readonly ILogger<CryptoProvider> _logger;

        /// <summary>
        /// CryptoProvider.
        /// </summary>
        /// <param name="logger"></param>
        public CryptoProvider(ILogger<CryptoProvider> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// EncryptAES.
        /// </summary>
        /// <param name="text">Text for crypto in AES.</param>
        /// <param name="key">Key for crypto in AES.</param>
        /// <param name="iv">Iv for crypto in AES.</param>
        /// <returns></returns>
        public String EncryptAES(String text, String key, String iv)
        {
            String result = default(String);

            try
            {
                result = CryptoExtension.EncryptAES(text, key, iv);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex?.ToString());
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// EncryptAESAsync.
        /// </summary>
        /// <param name="text">Text for crypto in AES.</param>
        /// <param name="key">Key for crypto in AES.</param>
        /// <param name="iv">Iv for crypto in AES.</param>
        /// <returns></returns>
        public async Task<String> EncryptAESAsync(String text, String key, String iv)
        {
            String result = default(String);

            try
            {
                await Task.Run(() => { result = CryptoExtension.EncryptAES(text, key, iv); });
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex?.ToString());
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// DecryptAES.
        /// </summary>
        /// <param name="cipherText">Text for decrypto in AES.</param>
        /// <param name="key">Key for decrypto in AES.</param>
        /// <param name="iv">Iv for decrypto in AES.</param>
        /// <returns></returns>
        public String DecryptAES(String cipherText, String key, String iv)
        {
            String result = default(String);

            try
            {
                result = CryptoExtension.DecryptAES(cipherText, key, iv);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex?.ToString());
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// DecryptAESAsync.
        /// </summary>
        /// <param name="cipherText">Text for decrypto in AES.</param>
        /// <param name="key">Key for decrypto in AES.</param>
        /// <param name="iv">Iv for decrypto in AES.</param>
        /// <returns></returns>
        public async Task<String> DecryptAESAsync(String cipherText, String key, String iv)
        {
            String result = default(String);

            try
            {
                await Task.Run(() => { result = CryptoExtension.DecryptAES(cipherText, key, iv); });
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex?.ToString());
                throw ex;
            }

            return result;
        }
    }
}
