using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.CreateRaffleEntry;

namespace TomCatRaffleProgram.Program.Framework.Presentation.RaffleEntry.CreateRaffleEntry
{
    class CreateRaffleEntryPresenter : BasePresenter<RaffleEntryDto>, ICreateRaffleEntryOutputPort
    {
        Task ICreateRaffleEntryOutputPort.PresentRaffleEntryAsync(RaffleEntryDto entry, CancellationToken cancellationToken)
            => SetResultAsync(entry, cancellationToken);

        Task ICreateRaffleEntryOutputPort.PresentRaffleNotFoundAsync(int raffleId, CancellationToken cancellationToken)
            => SetErrorsAsync(new List<string>() { $"A Raffle with the Id {raffleId} was not found." }, cancellationToken);

        Task ICreateRaffleEntryOutputPort.PresentValidationFailureAsync(List<string> failures, CancellationToken cancellationToken)
            => SetErrorsAsync(failures, cancellationToken);
    }
}
