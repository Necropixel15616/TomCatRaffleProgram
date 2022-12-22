using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Framework.Infrastructure;

namespace TomCatRaffleProgram.Program
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; set; }
        public IConfiguration Configuration { get; set; }

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            // Set up the Service Provider for Dependancy Injection
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            Configuration = builder.Build();
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            this.ServiceProvider = serviceCollection.BuildServiceProvider();

            var persistenceContext = new RaffleRepository();
            persistenceContext.LoadFile();
            var mainWindow = this.ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRaffleRepository, RaffleRepository>();
            services.AddScoped<IFileServices, FileServices>();

            services.AddTransient(typeof(MainWindow));
        }

    }
}
