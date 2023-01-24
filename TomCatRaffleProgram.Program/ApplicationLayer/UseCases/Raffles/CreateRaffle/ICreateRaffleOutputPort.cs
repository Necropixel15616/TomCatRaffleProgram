using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.CreateRaffle
{
    interface ICreateRaffleOutputPort : IFileValidation
    {
        Task PresentValidationFailureAsync(List<string> failures);

        Task PresentRaffleExistsAsync(string name);

        Task PresentRaffleCreatedAsync(RaffleDto raffle);

    }
}
