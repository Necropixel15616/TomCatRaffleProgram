using System.Windows;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffleEntry;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.GetRaffleEntries;
using TomCatRaffleProgram.Program.Framework.Presentation.CreateRaffle;
using TomCatRaffleProgram.Program.Framework.Presentation.CreateRaffleEntry;
using TomCatRaffleProgram.Program.Framework.Presentation.GetRaffleEntries;
using TomCatRaffleProgram.Program.InterfaceAdapters.Controllers;

namespace TomCatRaffleProgram.Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IPersistenceContext persistenceContext)
        {
            var raffleController = new RaffleController(persistenceContext);
            var rafflePresenter = new CreateRafflePresenter();
            raffleController.CreateRaffleAsync(new CreateRaffleInputPort { RaffleName = "Test1" }, rafflePresenter).Wait();

            var raffleEntryController = new RaffleEntryController(persistenceContext);
            var CreateEntryPresenter = new CreateRaffleEntryPresenter();
            raffleEntryController.CreateRaffleEntryAsync(new CreateRaffleEntryInputPort { FirstName = "Test", LastName = "Name", RaffleId = 1, Tickets = 5 }, CreateEntryPresenter).Wait();

            var GetPresenter = new GetRaffleEntriesPresenter();
            raffleEntryController.GetRaffleEntriesAsync(new GetRaffleEntriesInputPort { RaffleId = 1 }, GetPresenter).Wait();

            var result = GetPresenter.Result.Result;
            InitializeComponent();
        }
    }
}
