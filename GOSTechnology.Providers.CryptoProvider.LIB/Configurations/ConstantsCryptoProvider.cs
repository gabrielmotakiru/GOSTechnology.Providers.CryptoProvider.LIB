using System;
using System.Collections.Generic;
using System.Text;

namespace GOSTechnology.Providers.CryptoProvider.LIB
{
    /// <summary>
    /// ConstantsCryptoProvider.
    /// </summary>
    public static class ConstantsCryptoProvider
    {
        #region "PARAMS"

        public const String PARAM_CIPHER_TEXT = "cipherText";
        public const String PARAM_TEXT = "text";
        public const String PARAM_KEY = "key";
        public const String PARAM_IV = "iv";
        public const String PARAM_PASSWORD = "password";
        public const String PARAM_CIPHER_PASSWORD = "cipherPassword";

        #endregion

        #region "MESSAGES"

        public const String MESSAGE_KEY_ARGUMENT_OUT_OF_RANGE = "CryptoProvider: chave deve ter no máximo 32 caracteres string (256 bits / 8 bytes).";
        public const String MESSAGE_IV_ARGUMENT_OUT_OF_RANGE = "CryptoProvider: bloco (IV) deve ter no máximo 16 caracteres (128 bits / 8 bytes).";
        public const String MESSAGE_PASSWORD_ARGUMENT_NULL = "CryptoProvider: senha é obrigatória.";
        public const String MESSAGE_CIPHER_PASSWORD_ARGUMENT_NULL = "CryptoProvider: senha criptografada é obrigatória.";
        public const String MESSAGE_TEXT_ARGUMENT_NULL = "CryptoProvider: texto é obrigatório.";
        public const String MESSAGE_CIPHER_TEXT_ARGUMENT_NULL = "CryptoProvider: texto criptografado é obrigatório.";
        public const String MESSAGE_KEY_ARGUMENT_NULL = "CryptoProvider: chave é obrigatória.";
        public const String MESSAGE_IV_ARGUMENT_NULL = "CryptoProvider: bloco (IV) é obrigatório.";
        public const String MESSAGE_PARAMETER_X = " (Parameter '{0}')";

        #endregion

        #region "TESTS"

        public const String EMPTY = "";
        public const String NULL = null;
        public const String KEY_DEFAULT = "12345678901234567890123456789012";
        public const String KEY_DEFAULT_OUT_OF_RANGE = "123456789012345678901234567890120000000000";
        public const String IV_DEFAULT = "1234567890123456";
        public const String IV_DEFAULT_OUT_OF_RANGE = "12345678901234560000000000";
        public const String TEST_1 = "Teste 1";
        public const String TEST_2 = "Teste 2";
        public const String TEST_3 = "Teste 3";
        public const String TEST_1_CRYPTO = "cNYfEsY2OjqmoyiSN6tZIA==";
        public const String TEST_2_CRYPTO = "OSkMR0t2V3GJjfZfJbciXA==";
        public const String TEST_3_CRYPTO = "Exgmv9yn6IVRT3kRAYsqXA==";
        public const String TEST_PASSWORD = "748596";
        public const String TEST_CIPHER_PASSWORD = "hfGePuNUfVpNWXptURqXbg==";

        #endregion

        #region "CRYPTO"

        public const String CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public const String KEY_PASSWORD = "";
        public const String IV_PASSWORD = "";

        #endregion
    }
}
