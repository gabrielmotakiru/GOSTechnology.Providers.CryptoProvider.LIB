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
        #region "CONFIGURATION"

        /// <summary>
        /// _logger.
        /// </summary>
        private Mock<ILogger<LIB.CryptoProvider>> _logger;

        /// <summary>
        /// _cryptoProvider.
        /// </summary>
        private ICryptoProvider _cryptoProvider;

        [SetUp]
        public void SetUp()
        {
            this._logger = new Mock<ILogger<LIB.CryptoProvider>>();
            this._cryptoProvider = new LIB.CryptoProvider(this._logger.Object);
        }

        #endregion

        #region "TESTS"

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
            var encrypt = this._cryptoProvider.EncryptAES(text, key, iv);
            encrypt.Should().BeNullOrWhiteSpace();
        }

        /// <summary>
        /// ShouldFailEncryptAESAsync.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.EMPTY, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_2, ConstantsCryptoProvider.EMPTY, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_3, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.EMPTY)]
        public async Task ShouldFailEncryptAESAsync(String text, String key, String iv)
        {
            var encrypt = await this._cryptoProvider.EncryptAESAsync(text, key, iv);
            encrypt.Should().BeNullOrWhiteSpace();
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
            var encrypt = this._cryptoProvider.EncryptAES(text, key, iv);
            encrypt.Should().NotBeNullOrWhiteSpace();
        }

        /// <summary>
        /// ShouldSuccessEncryptAESAsync.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_1, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_2, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_3, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        public async Task ShouldSuccessEncryptAESAsync(String text, String key, String iv)
        {
            var encrypt = await this._cryptoProvider.EncryptAESAsync(text, key, iv);
            encrypt.Should().NotBeNullOrWhiteSpace();
        }

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
            var decrypt = this._cryptoProvider.DecryptAES(cipherText, key, iv);
            decrypt.Should().BeNullOrWhiteSpace();
        }

        /// <summary>
        /// ShouldFailDecryptAESAsync.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.EMPTY, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_2_CRYPTO, ConstantsCryptoProvider.EMPTY, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_3_CRYPTO, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.EMPTY)]
        public async Task ShouldFailDecryptAESAsync(String cipherText, String key, String iv)
        {
            var decrypt = await this._cryptoProvider.DecryptAESAsync(cipherText, key, iv);
            decrypt.Should().BeNullOrWhiteSpace();
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
            var decrypt = this._cryptoProvider.DecryptAES(cipherText, key, iv);
            decrypt.Should().NotBeNullOrWhiteSpace();
        }

        /// <summary>
        /// ShouldSuccessDecryptAESAsync.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_1_CRYPTO, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_2_CRYPTO, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_3_CRYPTO, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        public async Task ShouldSuccessDecryptAESAsync(String cipherText, String key, String iv)
        {
            var decrypt = await this._cryptoProvider.DecryptAESAsync(cipherText, key, iv);
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
            var encrypt = this._cryptoProvider.EncryptAES(text, key, iv);
            var decrypt = this._cryptoProvider.DecryptAES(encrypt, key, iv);
            decrypt.Should().Be(text);
        }

        /// <summary>
        /// ShouldSuccessEncryptDecryptAESAsync.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        [Test]
        [TestCase(ConstantsCryptoProvider.TEST_1, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_2, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        [TestCase(ConstantsCryptoProvider.TEST_3, ConstantsCryptoProvider.KEY_DEFAULT, ConstantsCryptoProvider.IV_DEFAULT)]
        public async Task ShouldSuccessEncryptDecryptAESAsync(String text, String key, String iv)
        {
            var encrypt = await this._cryptoProvider.EncryptAESAsync(text, key, iv);
            var decrypt = await this._cryptoProvider.DecryptAESAsync(encrypt, key, iv);
            decrypt.Should().Be(text);
        }

        #endregion
    }
}
