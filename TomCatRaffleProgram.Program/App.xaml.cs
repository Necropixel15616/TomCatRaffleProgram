using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle;
using TomCatRaffleProgram.Program.Framework.Infrastructure;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;
using TomCatRaffleProgram.Program.Framework.Presentation.CreateRaffle;
using TomCatRaffleProgram.Program.Framework.Presentation.CreateRaffleEntry;
using TomCatRaffleProgram.Program.Framework.Presentation.GetRaffleEntries;
using TomCatRaffleProgram.Program.InterfaceAdapters.Controllers;

namespace TomCatRaffleProgram.Program
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private static string FilePath = $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"TomCatRaffle\")}RaffleData.xml";

        public IServiceProvider ServiceProvider { get; set; }
        public IConfiguration Configuration { get; set; }

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            Configuration = builder.Build();
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            this.ServiceProvider = serviceCollection.BuildServiceProvider();

            this.CreateFileOnStartup();
            var mainWindow = this.ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPersistenceContext, PersistenceContext>();

            services.AddTransient(typeof(MainWindow));
        }

        private void CreateFileOnStartup()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filePath = Path.Combine(folder, @"TomCatRaffle\");
            Directory.CreateDirectory(filePath);

            FileInfo file = new FileInfo($"{filePath}RaffleData.xml");
            if (!file.Exists)
            {
                using(var sw = file.CreateText())
                {
                    sw.WriteLine("<Raffles></Raffles>");
                    sw.Close();
                }
            }
        }

        public static string GetFilePath()
            => FilePath;
    }
}
