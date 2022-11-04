using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle;

namespace TomCatRaffleProgram.Program.Framework.Presentation.CreateRaffle
{
    class CreateRafflePresenter : ICreateRaffleOutputPort
    {
        Task ICreateRaffleOutputPort.FileNotFound()
            => Task.CompletedTask;

        Task ICreateRaffleOutputPort.RaffleCreated(RaffleDto raffle)
            => Task.CompletedTask;

        Task ICreateRaffleOutputPort.RaffleExists(string name)
            => Task.CompletedTask;
    }
}
