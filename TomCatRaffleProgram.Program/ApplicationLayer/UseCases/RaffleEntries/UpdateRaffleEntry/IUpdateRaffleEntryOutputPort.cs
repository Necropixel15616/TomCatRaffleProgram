using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.UpdateRaffleEntry
{
    interface IUpdateRaffleEntryOutputPort :
        IFileValidation
    {

        Task PresentRaffleEntryUpdatedAsync(RaffleEntryDto raffleEntry, CancellationToken cancellationToken);

        Task PresentRaffleNotFoundAsync(int raffleId, CancellationToken cancellationToken);

        Task PresentRaffleEntryNotFoundAsync(int raffleEntryId, CancellationToken cancellationToken);

        Task PresentValidationFailuresAsync(List<string> failures, CancellationToken cancellationToken);

    }
}
