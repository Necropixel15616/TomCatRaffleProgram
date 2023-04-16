using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;
using TomCatRaffleProgram.Program.ApplicationLayer.Infrastructure;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Framework.Infrastructure;

namespace TomCatRaffleProgram.Program
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IServiceProvider ServiceProvider { get; set; }
        private IConfiguration Configuration { get; set; }

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            // Set up the Service Provider for Dependancy Injection
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).Build();
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var persistenceContext = new RaffleRepository();
            persistenceContext.LoadFile();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRaffleRepository, RaffleRepository>();
            services.AddScoped<IFileServices, FileServices>();
            services.AddScoped(typeof(IFileValidator<>), typeof(FileValidator<>));

            services.Scan(scan
                => scan.FromAssemblies(AssemblyUtility.GetAssembly())
                .AddClasses(c => c.AssignableTo(typeof(IInteractor<,>))).AsImplementedInterfaces()
                .AddClasses(c => c.AssignableTo(typeof(IEntityExistenceChecker<,>))).AsImplementedInterfaces()
                .AddClasses(c => c.AssignableTo(typeof(IBusinessRuleValidator<,>))).AsImplementedInterfaces()
                .AddClasses(c => c.AssignableTo(typeof(IInputPortValidator<,>))).AsImplementedInterfaces());

            services.AddTransient<MainWindow>();
        }

        public static IServiceProvider GetServiceProvider()
            => ServiceProvider;

    }
}
