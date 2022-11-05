using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffleEntry
{
    interface ICreateRaffleEntryOutputPort
    {
        Task<RaffleEntryViewModel> PresentFileNotFoundAsync();

        Task<RaffleEntryViewModel> PresentRaffleEntryAsync(EntryDto entry);

        Task<RaffleEntryViewModel> PresentRaffleNotFoundAsync(int raffleId);

        Task<RaffleEntryViewModel> PresentValidationFailureAsync(List<string> failures);
    }
}
