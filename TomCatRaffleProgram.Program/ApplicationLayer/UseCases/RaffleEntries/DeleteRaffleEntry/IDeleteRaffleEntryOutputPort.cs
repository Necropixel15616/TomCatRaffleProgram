using System.Threading.Tasks;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DeleteRaffleEntry
{
    interface IDeleteRaffleEntryOutputPort : IFileValidation
    {

        Task PresentRaffleNotFound(int raffleId);

        Task PresentRaffleEntryNotFound(int raffleEntryId, int raffleId);

        Task PresentRaffleEntryDeleted();

    }
}
