using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.DeleteRaffle;

namespace TomCatRaffleProgram.Program.Framework.Presentation.Raffle.DeleteRaffle
{
    class DeleteRafflePresenter : BasePresenter<RaffleDto>, IDeleteRaffleOutputPort
    {
        Task IDeleteRaffleOutputPort.PresentRaffleDeletedAsync(CancellationToken cancellationToken)
            => SetResultAsync(null, cancellationToken);

        Task IDeleteRaffleOutputPort.PresentRaffleNotFoundAsync(int raffleId, CancellationToken cancellationToken)
            => SetErrorsAsync(new List<string> { $"A Raffle with the Id {raffleId} could not be found," }, cancellationToken);
    }
}
