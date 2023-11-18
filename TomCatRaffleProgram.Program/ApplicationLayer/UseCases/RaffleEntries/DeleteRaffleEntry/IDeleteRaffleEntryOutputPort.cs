using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DeleteRaffleEntry
{
    public interface IDeleteRaffleEntryOutputPort : IFileValidation
    {

        Task PresentRaffleNotFoundAsync(int raffleId, CancellationToken cancellationToken);

        Task PresentRaffleEntryNotFoundAsync(int raffleEntryId, int raffleId, CancellationToken cancellationToken);

        Task PresentRaffleEntryDeletedAsync(CancellationToken cancellationToken);

    }
}
