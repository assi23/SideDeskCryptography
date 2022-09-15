using Cryptography.Domain.Interfaces;
using Cryptography.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cryptography.WindosForm
{
    internal static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var serviceProvider = host.Services;

            ApplicationConfiguration.Initialize();
            Application.Run(serviceProvider.GetRequiredService<SideDeskCryptographyForm>());
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                    .ConfigureServices((hostcontext, services) =>
                    {
                        services.AddSingleton<SideDeskCryptographyForm>();

                        services.AddScoped<IEncryptService, EncryptService>();
                        services.AddScoped<IDecryptService, DecryptService>();
                    });
    }
}