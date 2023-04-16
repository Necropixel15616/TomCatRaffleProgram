using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.UpdateRaffle;

namespace TomCatRaffleProgram.Program.Framework.Presentation.Raffle.UpdateRaffle
{
    public class UpdateRafflePresenter : BasePresenter<RaffleDto>, IUpdateRaffleOutputPort
    {
        Task IUpdateRaffleOutputPort.PresentRaffleNotFoundAsync(int raffleId, CancellationToken cancellationToken)
            => SetErrorsAsync(new[] { $"The Raffle with the Id '{raffleId}' could not be found." }.ToList(), cancellationToken);

        Task IUpdateRaffleOutputPort.PresentRaffleUpdatedAsync(RaffleDto raffle, CancellationToken cancellationToken)
            => SetResultAsync(raffle, cancellationToken);

        Task IUpdateRaffleOutputPort.PresentValidationFailuresAsync(List<string> failures, CancellationToken cancellationToken)
            => SetErrorsAsync(failures, cancellationToken);
    }
}
