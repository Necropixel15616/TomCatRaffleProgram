using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.CreateRaffleEntry;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.CreateRaffle;
using TomCatRaffleProgram.Program.Framework.Presentation.Raffle.CreateRaffle;
using TomCatRaffleProgram.Program.Framework.Presentation.RaffleEntries.CreateRaffleEntry;
using TomCatRaffleProgram.Program.InterfaceAdapters.Controllers;

namespace TomCatRaffleProgram.Program.Framework.Views
{
    /// <summary>
    /// Interaction logic for CreateRaffle.xaml
    /// </summary>
    public partial class CreateRaffle : Page
    {
        private List<RaffleEntryDto> m_RaffleEntries = new List<RaffleEntryDto>();
        private readonly IRaffleRepository m_RaffleRepository;
        private readonly IServiceProvider m_ServiceProvider;
        private readonly RaffleController m_RaffleController;
        private readonly RaffleEntryController m_RaffleEntryController;

        public CreateRaffle(IRaffleRepository raffleRepository, IServiceProvider serviceProvider, RaffleController raffleController, RaffleEntryController raffleEntryController)
        {
            InitializeComponent();
            this.m_RaffleRepository = raffleRepository ?? throw new ArgumentNullException(nameof(raffleRepository));
            this.m_ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            this.m_RaffleController = raffleController ?? throw new ArgumentNullException(nameof(raffleController));
            this.m_RaffleEntryController = raffleEntryController ?? throw new ArgumentNullException(nameof(raffleEntryController));

            dgRaffleEntries.ItemsSource = this.m_RaffleEntries;
        }

        public string RaffleName { get; set; }

        private void dgbtRaffleEntries_Delete_Click(object sender, RoutedEventArgs e)
        {
            this.m_RaffleEntries.Remove((RaffleEntryDto)((Button)e.Source).DataContext);
            dgRaffleEntries.ItemsSource = this.m_RaffleEntries.ToList();
        }

        private void btnAddRaffleEntry_Click(object sender, RoutedEventArgs e)
        {
            this.m_RaffleEntries.Add(new RaffleEntryDto());
            dgRaffleEntries.ItemsSource = this.m_RaffleEntries.ToList();
        }

        private void dgtbRaffleEntries_Tickets_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private async void btnCreateRaffle_Click(object sender, RoutedEventArgs e)
        {
            var _CreateRaffleInputPort = new CreateRaffleInputPort() { RaffleName = this.RaffleName };
            var _CreateRafflePresenter = new CreateRafflePresenter();
            var _CancellationToken = CancellationToken.None;

            await this.m_RaffleController.CreateRaffleAsync(_CreateRaffleInputPort, _CreateRafflePresenter, _CancellationToken);

            if (_CreateRafflePresenter.Errors.Any())
            {
                MessageBox.Show($"Raffle was unable to be created. Encountered the following error(s): {string.Join(',', _CreateRafflePresenter.Errors.Select(e => "\n\"" + e + "\""))}", "Unable to create Raffle", MessageBoxButton.OK);
                return;
            }

            foreach (var _RaffleEntry in this.m_RaffleEntries)
            {
                var _CreateRaffleEntryInputPort = new CreateRaffleEntryInputPort()
                {
                    FirstName = _RaffleEntry.FirstName,
                    LastName = _RaffleEntry.LastName,
                    Tickets = _RaffleEntry.Tickets,
                    RaffleId = _CreateRafflePresenter.Result.RaffleId
                };
                var _CreateRaffleEntryPresenter = new CreateRaffleEntryPresenter();
                await this.m_RaffleEntryController.CreateRaffleEntryAsync(_CreateRaffleEntryInputPort, _CreateRaffleEntryPresenter, _CancellationToken);

                if (_CreateRaffleEntryPresenter.Errors.Any())
                {
                    MessageBox.Show($"Raffle was unable to be created. Encountered the following error(s): {string.Join(',', _CreateRaffleEntryPresenter.Errors.Select(e => "\n\"" + e + "\""))}", "Unable to create Raffle", MessageBoxButton.OK);
                    this.m_RaffleRepository.RemoveRaffle(_CreateRafflePresenter.Result.RaffleId); //Remove the Raffle from the Persistence so that it does not get added to the Main Page DataGrid
                    return;
                }
            }

            this.m_RaffleRepository.Save();
            MessageBox.Show("Successfully Created Raffle", "Success", MessageBoxButton.OK);
            NavigationService.Navigate(this.m_ServiceProvider.GetService(typeof(MainPage)));
        }

        private void btnReturnToMenu_Click(object sender, RoutedEventArgs e)
            => NavigationService.Navigate(this.m_ServiceProvider.GetService(typeof(MainPage)));

        private void txbxRaffleName_TextChanged(object sender, TextChangedEventArgs e)
            => this.RaffleName = ((TextBox)e.Source).Text;
    }
}
