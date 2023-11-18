using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.CreateRaffle
{
    public interface ICreateRaffleOutputPort : IFileValidation
    {
        Task PresentValidationFailureAsync(List<string> failures, CancellationToken cancellationToken);

        Task PresentRaffleExistsAsync(string name, CancellationToken cancellationToken);

        Task PresentRaffleCreatedAsync(RaffleDto raffle, CancellationToken cancellationToken);

    }
}
