using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle;
using TomCatRaffleProgram.Program.Framework.Presentation.CreateRaffle;
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
            var presenter = new CreateRafflePresenter();
            raffleController.CreateRaffleAsync(new CreateRaffleInputPort { RaffleName = "Test6" }, presenter).Wait();
            var result = presenter.Result.Result;
            InitializeComponent();
        }
    }
}
