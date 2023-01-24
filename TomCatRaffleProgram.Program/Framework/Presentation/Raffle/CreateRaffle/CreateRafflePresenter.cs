﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.CreateRaffle;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;

namespace TomCatRaffleProgram.Program.Framework.Presentation.Raffle.CreateRaffle
{
    class CreateRafflePresenter : BasePresenter<RaffleViewModel>, ICreateRaffleOutputPort
    {
        Task ICreateRaffleOutputPort.PresentRaffleCreatedAsync(RaffleDto raffle)
            => SetResult(new RaffleViewModel(raffle));

        Task ICreateRaffleOutputPort.PresentRaffleExistsAsync(string name)
            => SetErrors(new List<string>() { $"A Raffle with the Name '{name}' already exists." });

        Task ICreateRaffleOutputPort.PresentValidationFailureAsync(List<string> failures)
            => SetErrors(failures);
    }
}