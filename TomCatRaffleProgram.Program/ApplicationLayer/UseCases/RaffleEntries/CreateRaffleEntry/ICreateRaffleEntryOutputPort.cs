using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.CreateRaffleEntry
{
    public interface ICreateRaffleEntryOutputPort : IFileValidation
    {
        Task PresentRaffleEntryAsync(RaffleEntryDto entry, CancellationToken cancellationToken);

        Task PresentRaffleNotFoundAsync(int raffleId, CancellationToken cancellationToken);

        Task PresentValidationFailureAsync(List<string> failures, CancellationToken cancellationToken);
    }
}
