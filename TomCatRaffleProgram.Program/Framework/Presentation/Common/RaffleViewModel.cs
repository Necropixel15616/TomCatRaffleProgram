using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;

namespace TomCatRaffleProgram.Program.Framework.Presentation.Common
{
    class RaffleViewModel
    {
        public RaffleViewModel() { }

        public RaffleViewModel(RaffleDto raffle)
            => this.RaffleName = raffle.Name;

        public string RaffleName { get; set; }

        public string Errors { get; set; }
    }
}
