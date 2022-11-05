using System;
using System.Collections.Generic;
using System.Text;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.Framework.Presentation.Common
{
    class RaffleViewModel : IViewModel
    {
        public RaffleViewModel() { }

        public RaffleViewModel(RaffleDto raffle)
            => this.RaffleName = raffle.Name;

        public string RaffleName { get; set; }

        public string Errors { get; set; }
    }
}
