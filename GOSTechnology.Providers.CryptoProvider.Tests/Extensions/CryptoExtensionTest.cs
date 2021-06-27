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
        #region "TESTS"

        /// <summary>
        /// ShouldFailEncryptAES.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase("", "1234567890123456", "1234567890123456")]
        [TestCase("Teste 2", "", "1234567890123456")]
        [TestCase("Teste 3", "1234567890123456", "")]
        public void ShouldFailEncryptAES(String text, String key, String iv)
        {
            var encrypt = CryptoExtension.EncryptAES(text, key, iv);
            encrypt.Should().BeNullOrWhiteSpace();
        }

        /// <summary>
        /// ShouldSuccessEncryptAES.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase("Teste 1", "1234567890123456", "1234567890123456")]
        [TestCase("Teste 2", "1234567890123456", "1234567890123456")]
        [TestCase("Teste 3", "1234567890123456", "1234567890123456")]
        public void ShouldSuccessEncryptAES(String text, String key, String iv)
        {
            var encrypt = CryptoExtension.EncryptAES(text, key, iv);
            encrypt.Should().NotBeNullOrWhiteSpace();
        }

        /// <summary>
        /// ShouldFailDecryptAES.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase("", "1234567890123456", "1234567890123456")]
        [TestCase("2Df7wrrt+5s5omedkhAm5Q==", "", "1234567890123456")]
        [TestCase("dbGSj2ze9LiOjkWH1EXq9Q==", "1234567890123456", "")]
        public void ShouldFailDecryptAES(String cipherText, String key, String iv)
        {
            var decrypt = CryptoExtension.DecryptAES(cipherText, key, iv);
            decrypt.Should().BeNullOrWhiteSpace();
        }

        /// <summary>
        /// ShouldSuccessDecryptAES.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase("3DwRxK7jYU4o13/ySZKL2w==", "1234567890123456", "1234567890123456")]
        [TestCase("2Df7wrrt+5s5omedkhAm5Q==", "1234567890123456", "1234567890123456")]
        [TestCase("dbGSj2ze9LiOjkWH1EXq9Q==", "1234567890123456", "1234567890123456")]
        public void ShouldSuccessDecryptAES(String cipherText, String key, String iv)
        {
            var decrypt = CryptoExtension.DecryptAES(cipherText, key, iv);
            decrypt.Should().NotBeNullOrWhiteSpace();
        }

        /// <summary>
        /// ShouldSuccessDecryptAES.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase("Teste 1", "1234567890123456", "1234567890123456")]
        [TestCase("Teste 2", "1234567890123456", "1234567890123456")]
        [TestCase("Teste 3", "1234567890123456", "1234567890123456")]
        public void ShouldSuccessEncryptDecryptAES(String text, String key, String iv)
        {
            var encrypt = CryptoExtension.EncryptAES(text, key, iv);
            var decrypt = CryptoExtension.DecryptAES(encrypt, key, iv);
            decrypt.Should().Be(text);
        }

        #endregion
    }
}
