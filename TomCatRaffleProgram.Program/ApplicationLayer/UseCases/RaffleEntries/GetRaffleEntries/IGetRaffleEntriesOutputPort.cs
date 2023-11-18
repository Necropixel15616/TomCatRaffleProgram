using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.GetRaffleEntries
{
    public interface IGetRaffleEntriesOutputPort : IFileValidation
    {

        Task PresentRaffleEntriesAsync(List<RaffleEntryDto> entries, CancellationToken cancellationToken);

        Task PresentRaffleNotFoundAsync(int raffleId, CancellationToken cancellationToken);

    }
}
