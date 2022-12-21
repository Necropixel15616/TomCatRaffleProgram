using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.GetRaffleEntries
{
    interface IGetRaffleEntriesOutputPort
    {

        Task PresentRaffleEntriesAsync(List<RaffleEntryDto> entries);

        Task PresentFileNotFoundAsync();

        Task PresentRaffleNotFound(int raffleId);

    }
}
