using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle
{
    interface ICreateRaffleOutputPort
    {
        Task<RaffleViewModel> PresentValidationFailureAsync(List<string> failures);

        Task<RaffleViewModel> PresentFileNotFoundAsync();

        Task<RaffleViewModel> PresentRaffleExistsAsync(string name);

        Task<RaffleViewModel> PresentRaffleCreatedAsync(RaffleDto raffle);

    }
}
