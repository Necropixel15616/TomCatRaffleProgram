using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.GetRaffleEntries
{
    interface IGetRaffleEntriesOutputPort : IFileValidation
    {

        Task PresentRaffleEntriesAsync(List<RaffleEntryDto> entries);

        Task PresentRaffleNotFound(int raffleId);

    }
}
