using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.CreateRaffleEntry;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;

namespace TomCatRaffleProgram.Program.Framework.Presentation.RaffleEntry.CreateRaffleEntry
{
    class CreateRaffleEntryPresenter : BasePresenter<RaffleEntryViewModel>, ICreateRaffleEntryOutputPort
    {
        async Task ICreateRaffleEntryOutputPort.PresentRaffleEntryAsync(RaffleEntryDto entry, CancellationToken cancellationToken)
            => await SetResult(new RaffleEntryViewModel(entry), cancellationToken);

        async Task ICreateRaffleEntryOutputPort.PresentRaffleNotFoundAsync(int raffleId, CancellationToken cancellationToken)
            => await SetErrors(new List<string>() { $"A Raffle with the Id {raffleId} was not found." }, cancellationToken);

        async Task ICreateRaffleEntryOutputPort.PresentValidationFailureAsync(List<string> failures, CancellationToken cancellationToken)
            => await SetErrors(failures, cancellationToken);
    }
}
