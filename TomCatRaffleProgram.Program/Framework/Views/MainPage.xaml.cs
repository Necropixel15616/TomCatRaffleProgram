using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.DeleteRaffle;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.GetRaffles;
using TomCatRaffleProgram.Program.Framework.Presentation.Raffle.DeleteRaffle;
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
        private readonly IRaffleRepository m_RaffleRepository;
        private readonly IServiceProvider m_ServiceProvider;

        private List<RaffleDto> m_Raffles;

        public MainPage(RaffleController raffleController, IRaffleRepository raffleRepository, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            m_RaffleController = raffleController ?? throw new ArgumentNullException(nameof(raffleController));
            m_RaffleRepository = raffleRepository ?? throw new ArgumentNullException(nameof(raffleRepository));
            this.m_ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            this.SetDataContext().GetAwaiter().GetResult();
        }

        public async Task SetDataContext()
        {
            var _GetRafflesPresenter = new GetRafflesPresenter();
            await this.m_RaffleController.GetRafflesAsync(new GetRafflesInputPort(), _GetRafflesPresenter, CancellationToken.None);

            if (_GetRafflesPresenter.Errors.Any())
                MessageBox.Show($"Unable to load Raffles. Encountered the following error(s): {string.Join(',', _GetRafflesPresenter.Errors.Select(e => "\n\"" + e + "\""))}", "Unable to load Raffles.", MessageBoxButton.OK);
            else
            {
                this.m_Raffles = _GetRafflesPresenter.Result.ToList();
                dg_raffle.ItemsSource = this.m_Raffles.ToList();
            }
        }

        private async void dg_raffle_btnDeleteRaffle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Raffle?", "Delete Raffle?", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                var _DeleteRaffleInputPort = new DeleteRaffleInputPort() { RaffleId = ((RaffleDto)((Button)e.Source).DataContext).RaffleId };
                var _DeleteRafflePresenter = new DeleteRafflePresenter(this.m_RaffleRepository);
                await this.m_RaffleController.DeleteRaffleAsync(_DeleteRaffleInputPort, _DeleteRafflePresenter, CancellationToken.None);

                if (_DeleteRafflePresenter.Errors.Any())
                    MessageBox.Show($"Raffle was unable to be deleted. Encountered the following error(s): {string.Join(',', _DeleteRafflePresenter.Errors.Select(e => "\n\"" + e + "\""))}", "Raffle was not deleted.", MessageBoxButton.OK);

                this.m_Raffles.Remove(((RaffleDto)((Button)e.Source).DataContext));
                dg_raffle.ItemsSource = this.m_Raffles.ToList();
            }
        }

        private void dg_raffle_btnEditRaffle_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void btn_CreateRaffle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(this.m_ServiceProvider.GetService(typeof(CreateRaffle)));
        }
    }
}
