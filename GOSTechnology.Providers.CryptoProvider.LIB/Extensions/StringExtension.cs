using System;
using System.Linq;

namespace GOSTechnology.Providers.CryptoProvider.LIB
{
    /// <summary>
    /// StringExtension.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// random.
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// RandomString.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static String RandomString(Int32 length)
        {
            return new String(Enumerable.Repeat(ConstantsCryptoProvider.CHARS, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
