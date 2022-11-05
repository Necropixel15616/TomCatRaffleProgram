using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;
using TomCatRaffleProgram.Program.Framework.Presentation.CreateRaffle;
using TomCatRaffleProgram.Program.InterfaceAdapters.Controllers;

namespace TomCatRaffleProgram.Program
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string FilePath = $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"TomCatRaffle\")}RaffleData.xml";

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            this.CreateFileOnStartup();
            this.Test().Wait();
            Window mainWindow = new MainWindow();
            mainWindow.Show();
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
        
        private async Task<IViewModel> Test()
        {
            var raffleController = new RaffleController();
            var presenter = new CreateRafflePresenter();
            await raffleController.CreateRaffleAsync(new CreateRaffleInputPort {RaffleName = "Test1"}, presenter);
            return presenter.Result.Result;
        }
    }
}
