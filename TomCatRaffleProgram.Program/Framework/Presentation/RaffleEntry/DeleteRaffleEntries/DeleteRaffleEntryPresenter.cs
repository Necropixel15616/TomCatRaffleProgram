using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DeleteRaffleEntry;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;

namespace TomCatRaffleProgram.Program.Framework.Presentation.RaffleEntry.DeleteRaffleEntries
{
    class DeleteRaffleEntryPresenter : BasePresenter<NoContentViewModel>, IDeleteRaffleEntryOutputPort
    {
        Task IDeleteRaffleEntryOutputPort.PresentRaffleEntryDeleted(CancellationToken cancellationToken)
            => this.SetResult(null, cancellationToken);

        Task IDeleteRaffleEntryOutputPort.PresentRaffleEntryNotFound(int raffleEntryId, int raffleId, CancellationToken cancellationToken)
            => this.SetErrors(new List<string>() { $"The Raffle with the Id '{raffleId}' did not contain a Raffle Entry with the Id '{raffleEntryId}'." }, cancellationToken);

        Task IDeleteRaffleEntryOutputPort.PresentRaffleNotFound(int raffleId, CancellationToken cancellationToken)
            => this.SetErrors(new List<string>() { $"The Raffle with the Id '{raffleId}' was not found." }, cancellationToken);
    }
}
