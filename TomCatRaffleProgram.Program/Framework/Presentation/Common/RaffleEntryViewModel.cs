using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;

namespace TomCatRaffleProgram.Program.Framework.Presentation.Common
{
    class RaffleEntryViewModel
    {
        public RaffleEntryViewModel(RaffleEntryDto raffleEntryDto)
        {
            FirstName = raffleEntryDto.FirstName;
            LastName = raffleEntryDto.LastName;
            Tickets = raffleEntryDto.Tickets;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Tickets { get; set; }
    }
}
