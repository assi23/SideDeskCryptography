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
            CreateHostBuilder(args).Build();

            ApplicationConfiguration.Initialize();
            Application.Run(new SideDeskCryptography(new EncryptService(), new DecryptService()));
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                    .ConfigureServices((hostcontext, services) =>
                    {
                        services.AddScoped<IEncryptService, EncryptService>();
                        services.AddScoped<IDecryptService, DecryptService>();
                    });

    }
}