using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.DeleteRaffle
{
    public interface IDeleteRaffleOutputPort : IFileValidation
    {

        Task PresentRaffleNotFoundAsync(int raffleId, CancellationToken cancellationToken);

        Task PresentRaffleDeletedAsync(CancellationToken cancellationToken);

    }
}
