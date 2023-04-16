using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.UpdateRaffleEntry;

namespace TomCatRaffleProgram.Program.Framework.Presentation.RaffleEntries.UpdateRaffleEntry
{
    public class UpdateRaffleEntryPresenter : BasePresenter<RaffleEntryDto>, IUpdateRaffleEntryOutputPort
    {
        Task IUpdateRaffleEntryOutputPort.PresentRaffleEntryNotFoundAsync(int raffleEntryId, CancellationToken cancellationToken)
            => SetErrorsAsync(new List<string>() { $"A Raffle Entry with the Id '{raffleEntryId}' was not found." }, cancellationToken);

        Task IUpdateRaffleEntryOutputPort.PresentRaffleEntryUpdatedAsync(RaffleEntryDto raffleEntry, CancellationToken cancellationToken)
            => SetResultAsync(raffleEntry, cancellationToken);

        Task IUpdateRaffleEntryOutputPort.PresentRaffleNotFoundAsync(int raffleId, CancellationToken cancellationToken)
            => SetErrorsAsync(new List<string>() { $"A Raffle with the Id '{raffleId}' was not found." }, cancellationToken);

        Task IUpdateRaffleEntryOutputPort.PresentValidationFailuresAsync(List<string> failures, CancellationToken cancellationToken)
            => SetErrorsAsync(failures, cancellationToken);
    }
}
