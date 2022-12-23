using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.CreateRaffle
{
    interface ICreateRaffleOutputPort
    {
        Task PresentValidationFailureAsync(List<string> failures);

        Task PresentFileNotFoundAsync();

        Task PresentRaffleExistsAsync(string name);

        Task PresentRaffleCreatedAsync(RaffleDto raffle);

    }
}
