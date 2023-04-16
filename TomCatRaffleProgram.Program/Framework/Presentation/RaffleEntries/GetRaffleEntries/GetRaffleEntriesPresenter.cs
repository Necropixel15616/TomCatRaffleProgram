using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.GetRaffleEntries;

namespace TomCatRaffleProgram.Program.Framework.Presentation.RaffleEntries.GetRaffleEntries
{
    class GetRaffleEntriesPresenter : BasePresenter<List<RaffleEntryDto>>, IGetRaffleEntriesOutputPort
    {
        Task IGetRaffleEntriesOutputPort.PresentRaffleEntriesAsync(List<RaffleEntryDto> entries, CancellationToken cancellationToken)
            => SetResultAsync(entries, cancellationToken);

        Task IGetRaffleEntriesOutputPort.PresentRaffleNotFoundAsync(int raffleId, CancellationToken cancellationToken)
            => SetErrorsAsync(new List<string>() { $"A Raffle with the Id '{raffleId}' was not found." }, cancellationToken);
    }
}
