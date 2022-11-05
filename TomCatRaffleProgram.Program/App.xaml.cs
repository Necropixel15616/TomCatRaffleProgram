using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffleEntry;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.GetRaffleEntries;
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
        
        private async Task<IViewModel> Test()
        {
            var raffleController = new RaffleEntryController();
            var presenter = new GetRaffleEntriesPresenter();
            await raffleController.CreateRaffleEntryAsync(new CreateRaffleEntryInputPort { FirstName = "Test", LastName = "Test2", Tickets = 4, RaffleId = 4 }, new CreateRaffleEntryPresenter());
            await raffleController.GetRaffleEntriesAsync(new GetRaffleEntriesInputPort { RaffleId = 4 }, presenter);
            return presenter.Result.Result;
        }
    }
}
