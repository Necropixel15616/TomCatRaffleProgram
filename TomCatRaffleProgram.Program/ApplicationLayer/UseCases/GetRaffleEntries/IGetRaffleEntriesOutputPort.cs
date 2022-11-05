using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Framework.Presentation.GetRaffleEntries;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.GetRaffleEntries
{
    interface IGetRaffleEntriesOutputPort
    {

        Task<GetRaffleEntriesViewModel> PresentRaffleEntriesAsync(List<EntryDto> entries);

        Task<GetRaffleEntriesViewModel> PresentFileNotFoundAsync();

        Task<GetRaffleEntriesViewModel> PresentRaffleNotFound(int raffleId);

    }
}
