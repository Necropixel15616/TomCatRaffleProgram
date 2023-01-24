using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.CreateRaffleEntry;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;

namespace TomCatRaffleProgram.Program.Framework.Presentation.CreateRaffleEntry
{
    class CreateRaffleEntryPresenter : BasePresenter<RaffleEntryViewModel>, ICreateRaffleEntryOutputPort
    {
        Task ICreateRaffleEntryOutputPort.PresentRaffleEntryAsync(RaffleEntryDto entry)
            => SetResult(new RaffleEntryViewModel(entry));

        Task ICreateRaffleEntryOutputPort.PresentRaffleNotFoundAsync(int raffleId)
            => SetErrors(new List<string>() { $"A Raffle with the Id {raffleId} was not found." });

        Task ICreateRaffleEntryOutputPort.PresentValidationFailureAsync(List<string> failures)
            => SetErrors(failures);
    }
}
