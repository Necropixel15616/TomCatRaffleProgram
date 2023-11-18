using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.GetRaffles;
using TomCatRaffleProgram.Program.Framework.Presentation.Raffle.GetRaffles;
using TomCatRaffleProgram.Program.InterfaceAdapters.Controllers;

namespace TomCatRaffleProgram.Program.Framework.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly RaffleController m_RaffleController;

        public MainPage(RaffleController raffleController)
        {
            InitializeComponent();
            m_RaffleController = raffleController ?? throw new ArgumentNullException(nameof(raffleController));

            this.SetDataContext().GetAwaiter().GetResult();
        }

        public async Task SetDataContext()
        {
            var _GetRafflesPresenter = new GetRafflesPresenter();
            await this.m_RaffleController.GetRafflesAsync(new GetRafflesInputPort(), _GetRafflesPresenter, CancellationToken.None);

            dg_raffle.ItemsSource = _GetRafflesPresenter.Result.ToArray();
        }

        private void dg_raffle_btnDeleteRaffle_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void dg_raffle_btnEditRaffle_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void btn_CreateRaffle_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
