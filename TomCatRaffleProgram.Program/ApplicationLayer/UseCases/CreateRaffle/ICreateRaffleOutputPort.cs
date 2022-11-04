using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle
{
    interface ICreateRaffleOutputPort
    {
        Task ValidationFailure();

        Task FileNotFound();

        Task RaffleExists(string name);

        Task RaffleCreated(RaffleDto raffle);

    }
}
