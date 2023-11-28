using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;
using TomCatRaffleProgram.Program.ApplicationLayer.Infrastructure;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Framework.Infrastructure;
using TomCatRaffleProgram.Program.Framework.Views;

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
            // Set up the Service Provider for Dependency Injection
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).Build();
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Register Infrastructure
            services.AddScoped<IRaffleRepository, RaffleRepository>()
                .AddScoped<IFileServices, FileServices>()
                .AddScoped(typeof(IFileValidator<>), typeof(FileValidator<>));

            // Register Pipe Services
            services.Scan(scan
                => scan.FromAssemblies(AssemblyUtility.GetAssembly())
                .AddClasses(c => c.AssignableTo(typeof(IInteractor<,>))).AsImplementedInterfaces().WithScopedLifetime()
                .AddClasses(c => c.AssignableTo(typeof(IEntityExistenceChecker<,>))).AsImplementedInterfaces().WithScopedLifetime()
                .AddClasses(c => c.AssignableTo(typeof(IBusinessRuleValidator<,>))).AsImplementedInterfaces().WithScopedLifetime()
                .AddClasses(c => c.AssignableTo(typeof(IInputPortValidator<,>))).AsImplementedInterfaces().WithScopedLifetime()
                .AddClasses(c => c.Where(e => e.Name.EndsWith("Controller"))));

            // Register Windows and Pages
            services.AddTransient<MainWindow>()
                .AddTransient<MainPage>()
                .AddTransient<CreateRaffle>();
        }

        public static IServiceProvider GetServiceProvider()
            => ServiceProvider;

    }
}
