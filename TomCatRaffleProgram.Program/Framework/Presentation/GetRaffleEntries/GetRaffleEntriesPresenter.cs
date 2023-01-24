using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.GetRaffleEntries;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;

namespace TomCatRaffleProgram.Program.Framework.Presentation.GetRaffleEntries
{
    class GetRaffleEntriesPresenter : BasePresenter<List<RaffleEntryViewModel>>, IGetRaffleEntriesOutputPort
    {
        Task IGetRaffleEntriesOutputPort.PresentRaffleEntriesAsync(List<RaffleEntryDto> entries)
        {
            var viewModels = new List<RaffleEntryViewModel>();
            entries.ForEach(e => viewModels.Add(new RaffleEntryViewModel(e)));
            return SetResult(viewModels);
        }

        Task IGetRaffleEntriesOutputPort.PresentRaffleNotFound(int raffleId)
            => SetErrors(new List<string>() { $"A Raffle with the Id '{raffleId}' was not found." });
    }
}
