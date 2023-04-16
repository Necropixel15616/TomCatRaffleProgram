using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.UpdateRaffle
{
    public interface IUpdateRaffleOutputPort :
        IFileValidation
    {

        Task PresentRaffleUpdatedAsync(RaffleDto raffle, CancellationToken cancellationToken);

        Task PresentRaffleNotFoundAsync(int raffleId, CancellationToken cancellationToken);

        Task PresentValidationFailuresAsync(List<string> failures, CancellationToken cancellationToken);

    }
}
