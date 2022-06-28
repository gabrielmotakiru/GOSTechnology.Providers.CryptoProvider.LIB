using FluentAssertions;
using GOSTechnology.Providers.CryptoProvider.LIB;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace GOSTechnology.Providers.CryptoProvider.Tests
{
    /// <summary>
    /// CryptoProviderTest.
    /// </summary>
    [TestFixture]
    public class CryptoProviderTest
    {
        #region "ENCRYPT TESTS"

        /// <summary>
        /// ShouldFailEncryptAES.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.EMPTY, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_2, ConstantsCryptoProvider.EMPTY, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_3, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.EMPTY)]
        public void ShouldFailEncryptAES(String text, String key, String iv)
        {
            Action comparison = () => LIB.CryptoProvider.EncryptAES(text, key, iv);
            comparison.Should().Throw<Exception>();
        }

        /// <summary>
        /// ShouldFailEncryptAESWithTextArgumentNull.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.EMPTY, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        public void ShouldFailEncryptAESWithTextArgumentNull(String text, String key, String iv)
        {
            Action comparison = () => LIB.CryptoProvider.EncryptAES(text, key, iv);
            comparison.Should().Throw<ArgumentNullException>().WithMessage($"{ConstantsCryptoProvider.MESSAGE_TEXT_ARGUMENT_NULL}{String.Format(ConstantsCryptoProvider.MESSAGE_PARAMETER_X, ConstantsCryptoProvider.PARAM_TEXT)}");
        }

        /// <summary>
        /// ShouldFailEncryptAESWithKeyArgumentNull.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_2, ConstantsCryptoProvider.EMPTY, ConstantsCryptoProvider.IV_DEFAULT)]
        public void ShouldFailEncryptAESWithKeyArgumentNull(String text, String key, String iv)
        {
            Action comparison = () => LIB.CryptoProvider.EncryptAES(text, key, iv);
            comparison.Should().Throw<ArgumentNullException>().WithMessage($"{ConstantsCryptoProvider.MESSAGE_KEY_ARGUMENT_NULL}{String.Format(ConstantsCryptoProvider.MESSAGE_PARAMETER_X, ConstantsCryptoProvider.PARAM_KEY)}");
        }

        /// <summary>
        /// ShouldFailEncryptAESWithIVArgumentNull.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_3, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.EMPTY)]
        public void ShouldFailEncryptAESWithIVArgumentNull(String text, String key, String iv)
        {
            Action comparison = () => LIB.CryptoProvider.EncryptAES(text, key, iv);
            comparison.Should().Throw<ArgumentNullException>().WithMessage($"{ConstantsCryptoProvider.MESSAGE_IV_ARGUMENT_NULL}{String.Format(ConstantsCryptoProvider.MESSAGE_PARAMETER_X, ConstantsCryptoProvider.PARAM_IV)}");
        }

        /// <summary>
        /// ShouldFailEncryptAESWithKeyArgumentOutOfRange.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_2, ConstantsCryptoProvider.KEY_DEFAULT_OUT_OF_RANGE, ConstantsCryptoProvider.IV_DEFAULT)]
        public void ShouldFailEncryptAESWithKeyArgumentOutOfRange(String text, String key, String iv)
        {
            Action comparison = () => LIB.CryptoProvider.EncryptAES(text, key, iv);
            comparison.Should().Throw<ArgumentOutOfRangeException>().WithMessage($"{ConstantsCryptoProvider.MESSAGE_KEY_ARGUMENT_OUT_OF_RANGE}{String.Format(ConstantsCryptoProvider.MESSAGE_PARAMETER_X, ConstantsCryptoProvider.PARAM_KEY)}");
        }

        /// <summary>
        /// ShouldFailEncryptAESWithIVArgumentOutOfRange.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_2, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT_OUT_OF_RANGE)]
        public void ShouldFailEncryptAESWithKIVArgumentOutOfRange(String text, String key, String iv)
        {
            Action comparison = () => LIB.CryptoProvider.EncryptAES(text, key, iv);
            comparison.Should().Throw<ArgumentOutOfRangeException>().WithMessage($"{ConstantsCryptoProvider.MESSAGE_IV_ARGUMENT_OUT_OF_RANGE}{String.Format(ConstantsCryptoProvider.MESSAGE_PARAMETER_X, ConstantsCryptoProvider.PARAM_IV)}");
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
            var encrypt = LIB.CryptoProvider.EncryptAES(text, key, iv);
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
        [TestCase(ConstantsCryptoProvider.EMPTY, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_2_CRYPTO, ConstantsCryptoProvider.EMPTY, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_3_CRYPTO, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.EMPTY)]
        public void ShouldFailDecryptAES(String cipherText, String key, String iv)
        {
            Action comparison = () => LIB.CryptoProvider.DecryptAES(cipherText, key, iv);
            comparison.Should().Throw<Exception>();
        }

        /// <summary>
        /// ShouldFailDecryptAESWithTextArgumentNull.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.EMPTY, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        public void ShouldFailDecryptAESWithTextArgumentNull(String cipherText, String key, String iv)
        {
            Action comparison = () => LIB.CryptoProvider.DecryptAES(cipherText, key, iv);
            comparison.Should().Throw<ArgumentNullException>().WithMessage($"{ConstantsCryptoProvider.MESSAGE_CIPHER_TEXT_ARGUMENT_NULL}{String.Format(ConstantsCryptoProvider.MESSAGE_PARAMETER_X, ConstantsCryptoProvider.PARAM_CIPHER_TEXT)}");
        }

        /// <summary>
        /// ShouldFailDecryptAESWithKeyArgumentNull.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_2, ConstantsCryptoProvider.EMPTY, ConstantsCryptoProvider.IV_DEFAULT)]
        public void ShouldFailDecryptAESWithKeyArgumentNull(String cipherText, String key, String iv)
        {
            Action comparison = () => LIB.CryptoProvider.DecryptAES(cipherText, key, iv);
            comparison.Should().Throw<ArgumentNullException>().WithMessage($"{ConstantsCryptoProvider.MESSAGE_KEY_ARGUMENT_NULL}{String.Format(ConstantsCryptoProvider.MESSAGE_PARAMETER_X, ConstantsCryptoProvider.PARAM_KEY)}");
        }

        /// <summary>
        /// ShouldFailDecryptAESWithIVArgumentNull.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_3, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.EMPTY)]
        public void ShouldFailDecryptAESWithIVArgumentNull(String cipherText, String key, String iv)
        {
            Action comparison = () => LIB.CryptoProvider.DecryptAES(cipherText, key, iv);
            comparison.Should().Throw<ArgumentNullException>().WithMessage($"{ConstantsCryptoProvider.MESSAGE_IV_ARGUMENT_NULL}{String.Format(ConstantsCryptoProvider.MESSAGE_PARAMETER_X, ConstantsCryptoProvider.PARAM_IV)}");
        }

        /// <summary>
        /// ShouldFailDecryptAESWithKeyArgumentOutOfRange.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_2, ConstantsCryptoProvider.KEY_DEFAULT_OUT_OF_RANGE, ConstantsCryptoProvider.IV_DEFAULT)]
        public void ShouldFailDecryptAESWithKeyArgumentOutOfRange(String cipherText, String key, String iv)
        {
            Action comparison = () => LIB.CryptoProvider.DecryptAES(cipherText, key, iv);
            comparison.Should().Throw<ArgumentOutOfRangeException>().WithMessage($"{ConstantsCryptoProvider.MESSAGE_KEY_ARGUMENT_OUT_OF_RANGE}{String.Format(ConstantsCryptoProvider.MESSAGE_PARAMETER_X, ConstantsCryptoProvider.PARAM_KEY)}");
        }

        /// <summary>
        /// ShouldFailDecryptAESWithIVArgumentOutOfRange.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_2, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT_OUT_OF_RANGE)]
        public void ShouldFailDecryptAESWithKIVArgumentOutOfRange(String cipherText, String key, String iv)
        {
            Action comparison = () => LIB.CryptoProvider.DecryptAES(cipherText, key, iv);
            comparison.Should().Throw<ArgumentOutOfRangeException>().WithMessage($"{ConstantsCryptoProvider.MESSAGE_IV_ARGUMENT_OUT_OF_RANGE}{String.Format(ConstantsCryptoProvider.MESSAGE_PARAMETER_X, ConstantsCryptoProvider.PARAM_IV)}");
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
            var decrypt = LIB.CryptoProvider.DecryptAES(cipherText, key, iv);
            decrypt.Should().NotBeNullOrWhiteSpace();
        }

        #endregion

        #region "SET PASSWORD TESTS"

        /// <summary>
        /// ShouldFailSetPasswordWithPasswordArgumentNull.
        /// </summary>
        /// <param name="password"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.EMPTY)]
        public void ShouldFailSetPasswordWithPasswordArgumentNull(String password)
        {
            Action comparison = () => LIB.CryptoProvider.SetPasswordHash(password);
            comparison.Should().Throw<ArgumentNullException>().WithMessage($"{ConstantsCryptoProvider.MESSAGE_PASSWORD_ARGUMENT_NULL}{String.Format(ConstantsCryptoProvider.MESSAGE_PARAMETER_X, ConstantsCryptoProvider.PARAM_PASSWORD)}");
        }

        /// <summary>
        /// ShouldSuccessEncryptAES.
        /// </summary>
        /// <param name="password"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_PASSWORD)]
        public void ShouldSuccessSetPassword(String password)
        {
            var encrypt = LIB.CryptoProvider.SetPasswordHash(password);
            encrypt.Should().NotBeNullOrWhiteSpace();
        }

        #endregion

        #region "GET PASSWORD TESTS"

        /// <summary>
        /// ShouldFailGetPasswordWithCipherPasswordArgumentNull.
        /// </summary>
        /// <param name="cipherPassword"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.EMPTY)]
        public void ShouldFailGetPasswordWithCipherPasswordArgumentNull(String cipherPassword) 
        {
            Action comparison = () => LIB.CryptoProvider.GetPasswordHash(cipherPassword);
            comparison.Should().Throw<ArgumentNullException>().WithMessage($"{ConstantsCryptoProvider.MESSAGE_CIPHER_PASSWORD_ARGUMENT_NULL}{String.Format(ConstantsCryptoProvider.MESSAGE_PARAMETER_X, ConstantsCryptoProvider.PARAM_CIPHER_PASSWORD)}");
        }

        /// <summary>
        /// ShouldSuccessGetPassword.
        /// </summary>
        /// <param name="cipherPassword"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_CIPHER_PASSWORD)]
        public void ShouldSuccessGetPassword(String cipherPassword)
        {
            var encrypt = LIB.CryptoProvider.GetPasswordHash(cipherPassword);
            encrypt.Should().NotBeNullOrWhiteSpace();
        }

        #endregion
    }
}
