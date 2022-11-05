using System;
using System.Collections.Generic;
using System.Text;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Dtos
{
    class RaffleDto
    {
        public RaffleDto() { }

        public RaffleDto(Raffle _raffle)
        {
            this.Name = _raffle.Name;
            this.RaffleId = _raffle.Id;
        }

        public string Name { get; set; }

        public int RaffleId { get; set; }

    }
}
