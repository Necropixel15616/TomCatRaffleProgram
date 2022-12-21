using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffleEntry
{
    interface ICreateRaffleEntryOutputPort
    {
        Task PresentFileNotFoundAsync();

        Task PresentRaffleEntryAsync(RaffleEntryDto entry);

        Task PresentRaffleNotFoundAsync(int raffleId);

        Task PresentValidationFailureAsync(List<string> failures);
    }
}
