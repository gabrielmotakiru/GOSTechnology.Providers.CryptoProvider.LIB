using FluentAssertions;
using GOSTechnology.Providers.CryptoProvider.LIB;
using NUnit.Framework;
using System;

namespace GOSTechnology.Providers.CryptoProvider.Tests
{
    /// <summary>
    /// CryptoExtensionTest.
    /// </summary>
    [TestFixture]
    public class CryptoExtensionTest
    {
        #region "ENCRYPT TESTS"

        /// <summary>
        /// ShouldFailEncryptAES.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.NULL, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_2, ConstantsCryptoProvider.EMPTY, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_3, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.EMPTY)]
        public void ShouldFailEncryptAES(String text, String key, String iv)
        {
            Action comparison = () => CryptoExtension.EncryptAES(text, key, iv);
            comparison.Should().Throw<Exception>();
        }

        /// <summary>
        /// ShouldSuccessEncryptAES.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_1, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_2, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_3, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        public void ShouldSuccessEncryptAES(String text, String key, String iv)
        {
            var encrypt = CryptoExtension.EncryptAES(text, key, iv);
            encrypt.Should().NotBeNullOrWhiteSpace();
        }

        #endregion

        #region "DECRYPT TESTS"

        /// <summary>
        /// ShouldFailDecryptAES.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.NULL, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_2_CRYPTO, ConstantsCryptoProvider.EMPTY, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_3_CRYPTO, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.EMPTY)]
        public void ShouldFailDecryptAES(String cipherText, String key, String iv)
        {
            Action comparison = () => CryptoExtension.DecryptAES(cipherText, key, iv);
            comparison.Should().Throw<Exception>();
        }

        /// <summary>
        /// ShouldSuccessDecryptAES.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_1_CRYPTO, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_2_CRYPTO, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_3_CRYPTO, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        public void ShouldSuccessDecryptAES(String cipherText, String key, String iv)
        {
            var decrypt = CryptoExtension.DecryptAES(cipherText, key, iv);
            decrypt.Should().NotBeNullOrWhiteSpace();
        }

        /// <summary>
        /// ShouldSuccessEncryptDecryptAES.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_1, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_2, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_3, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        public void ShouldSuccessEncryptDecryptAES(String text, String key, String iv)
        {
            var encrypt = CryptoExtension.EncryptAES(text, key, iv);
            var decrypt = CryptoExtension.DecryptAES(encrypt, key, iv);
            decrypt.Should().Be(text);
        }

        #endregion
    }
}
