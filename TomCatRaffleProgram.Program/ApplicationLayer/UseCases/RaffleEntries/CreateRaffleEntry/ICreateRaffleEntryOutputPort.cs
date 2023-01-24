using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.CreateRaffleEntry
{
    interface ICreateRaffleEntryOutputPort : IFileValidation
    {
        Task PresentRaffleEntryAsync(RaffleEntryDto entry);

        Task PresentRaffleNotFoundAsync(int raffleId);

        Task PresentValidationFailureAsync(List<string> failures);
    }
}
