using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DeleteRaffleEntry
{
    interface IDeleteRaffleEntryOutputPort : IFileValidation
    {

        Task PresentRaffleNotFound(int raffleId, CancellationToken cancellationToken);

        Task PresentRaffleEntryNotFound(int raffleEntryId, int raffleId, CancellationToken cancellationToken);

        Task PresentRaffleEntryDeleted(CancellationToken cancellationToken);

    }
}
