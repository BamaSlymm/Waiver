using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DPAWaiver.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DPAWaiver
{
    public static class AppConfig
    {
	    public static readonly bool AppVeyor = !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("APPVEYOR"));

	    public static readonly int EfBatchSize = !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("EF_BATCH_SIZE"))
		    ? Convert.ToInt32(Environment.GetEnvironmentVariable("EF_BATCH_SIZE")) : 1;

        public static readonly int EfRetryOnFailure = !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("EF_RETRY_ON_FAILURE"))
		    ? Convert.ToInt32(Environment.GetEnvironmentVariable("EF_RETRY_ON_FAILURE")) : 0;

        public static readonly string EfSchema = !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("EF_SCHEMA"))
            ? Environment.GetEnvironmentVariable("EF_SCHEMA") : null;

        // public static IConfigurationRoot Config => LazyConfig.Value;

        // private static readonly Lazy<IConfigurationRoot> LazyConfig = new Lazy<IConfigurationRoot>(() => new ConfigurationBuilder()
        //     .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
        //     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //     .AddEnvironmentVariables()
        //     .Build());

    }
}
