using FluentAssertions;
using GOSTechnology.Providers.CryptoProvider.LIB;
using NUnit.Framework;
using System;

namespace GOSTechnology.Providers.CryptoProvider.Tests
{
    /// <summary>
    /// StringExtensionTest.
    /// </summary>
    [TestFixture]
    public class StringExtensionTest
    {
        #region "RANDOM STRING TESTS"

        /// <summary>
        /// ShouldFailRandomString.
        /// </summary>
        /// <param name="length"></param>
        [Test]
        [TestCase(-1)]
        [TestCase(-16)]
        [TestCase(-32)]
        [TestCase(-64)]
        [TestCase(-128)]
        [TestCase(-256)]
        public void ShouldFailRandomString(Int32 length)
        {
            Action comparison = () => StringExtension.RandomString(length);
            comparison.Should().Throw<Exception>();
        }

        /// <summary>
        /// ShouldSuccessRandomString.
        /// </summary>
        /// <param name="length"></param>
        [Test]
        [TestCase(1)]
        [TestCase(16)]
        [TestCase(32)]
        [TestCase(64)]
        [TestCase(128)]
        [TestCase(256)]
        public void ShouldSuccessRandomString(Int32 length)
        {
            var encrypt = StringExtension.RandomString(length);
            encrypt.Should().NotBeNullOrWhiteSpace();
        }

        #endregion
    }
}
