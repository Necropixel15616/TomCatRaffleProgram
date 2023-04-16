using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DrawRaffleEntry
{
    public interface IDrawRaffleEntryOutputPort :
        IFileValidation
    {

        Task PresentRaffleNotFoundAsyc(int raffleId, CancellationToken cancellationToken);

        Task PresentRaffleWinnerAsync(RaffleEntryDto raffleEntry, CancellationToken cancellationToken);

    }
}
