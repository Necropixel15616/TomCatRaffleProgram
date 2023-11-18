using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.CreateRaffle;

namespace TomCatRaffleProgram.Program.Framework.Presentation.Raffle.CreateRaffle
{
    public class CreateRafflePresenter : BasePresenter<RaffleDto>, ICreateRaffleOutputPort
    {
        Task ICreateRaffleOutputPort.PresentRaffleCreatedAsync(RaffleDto raffle, CancellationToken cancellationToken)
            => SetResultAsync(raffle, cancellationToken);

        Task ICreateRaffleOutputPort.PresentRaffleExistsAsync(string name, CancellationToken cancellationToken)
            => SetErrorsAsync(new List<string>() { $"A Raffle with the Name '{name}' already exists." }, cancellationToken);

        Task ICreateRaffleOutputPort.PresentValidationFailureAsync(List<string> failures, CancellationToken cancellationToken)
            => SetErrorsAsync(failures, cancellationToken);
    }
}
