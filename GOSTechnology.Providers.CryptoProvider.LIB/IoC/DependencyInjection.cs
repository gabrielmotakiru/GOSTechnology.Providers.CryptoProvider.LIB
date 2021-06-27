using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GOSTechnology.Providers.CryptoProvider.LIB
{
    /// <summary>
    /// DependencyInjection.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// AddCryptoProvider.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IServiceCollection AddCryptoProvider(this IServiceCollection builder)
        {
            builder.AddScoped<ICryptoProvider, CryptoProvider>();
            return builder;
        }
    }
}
