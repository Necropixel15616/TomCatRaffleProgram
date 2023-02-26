using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DeleteRaffleEntry;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;

namespace TomCatRaffleProgram.Program.Framework.Presentation.RaffleEntry.DeleteRaffleEntries
{
    class DeleteRaffleEntryPresenter : BasePresenter<NoContentViewModel>, IDeleteRaffleEntryOutputPort
    {
        Task IDeleteRaffleEntryOutputPort.PresentRaffleEntryDeletedAsync(CancellationToken cancellationToken)
            => this.SetResultAsync(null, cancellationToken);

        Task IDeleteRaffleEntryOutputPort.PresentRaffleEntryNotFoundAsync(int raffleEntryId, int raffleId, CancellationToken cancellationToken)
            => this.SetErrorsAsync(new List<string>() { $"The Raffle with the Id '{raffleId}' did not contain a Raffle Entry with the Id '{raffleEntryId}'." }, cancellationToken);

        Task IDeleteRaffleEntryOutputPort.PresentRaffleNotFoundAsync(int raffleId, CancellationToken cancellationToken)
            => this.SetErrorsAsync(new List<string>() { $"The Raffle with the Id '{raffleId}' was not found." }, cancellationToken);
    }
}
