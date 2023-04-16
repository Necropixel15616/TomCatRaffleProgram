using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DrawRaffleEntry;

namespace TomCatRaffleProgram.Program.Framework.Presentation.RaffleEntries.DrawRaffleEntry
{
    public class DrawRaffleEntryPresenter : BasePresenter<RaffleEntryDto>, IDrawRaffleEntryOutputPort
    {
        Task IDrawRaffleEntryOutputPort.PresentRaffleNotFoundAsyc(int raffleId, CancellationToken cancellationToken)
            => SetErrorsAsync(new[] { $"The Raffle with the Id '{raffleId}' could not be found." }.ToList(), cancellationToken);

        Task IDrawRaffleEntryOutputPort.PresentRaffleWinnerAsync(RaffleEntryDto raffleEntry, CancellationToken cancellationToken)
            => SetResultAsync(raffleEntry, cancellationToken);
    }
}
