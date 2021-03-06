﻿using System;
using WebOptimizer;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods for <see cref="IAssetPipeline"/>.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds WebOptimizer to the <see cref="IApplicationBuilder"/> request execution pipeline
        /// </summary>
        public static void UseWebOptimizer(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (app.ApplicationServices.GetService(typeof(IAssetPipeline)) == null)
            {
                string msg = "Unable to find the required services. Please add all the required services by calling 'IServiceCollection.AddWebOptimizer' inside the call to 'ConfigureServices(...)' in the application startup code.";
                throw new InvalidOperationException(msg);
            }

            app.UseMiddleware<AssetMiddleware>();
        }
    }
}
