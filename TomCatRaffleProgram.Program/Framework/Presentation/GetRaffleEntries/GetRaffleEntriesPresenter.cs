using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.GetRaffleEntries;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;

namespace TomCatRaffleProgram.Program.Framework.Presentation.GetRaffleEntries
{
    class GetRaffleEntriesPresenter : IOutputPortPresenter<GetRaffleEntriesViewModel>, IGetRaffleEntriesOutputPort
    {
        public Task<GetRaffleEntriesViewModel> Result { get; set; }
        public bool PresentedSuccessfully { get; set; }

        public Task<GetRaffleEntriesViewModel> PresentFileNotFoundAsync()
        {
            this.PresentedSuccessfully = false;
            this.Result = Task.FromResult(new GetRaffleEntriesViewModel { RaffleEntries = new List<RaffleEntryViewModel> { new RaffleEntryViewModel { Errors = "The File was not found." } } });
            return this.Result;
        }

        public Task<GetRaffleEntriesViewModel> PresentRaffleEntriesAsync(List<EntryDto> entries)
        {
            this.PresentedSuccessfully = true;
            List<RaffleEntryViewModel> entriesViewModel = new List<RaffleEntryViewModel>();
            entries.ForEach(re => entriesViewModel.Add(new RaffleEntryViewModel { FirstName = re.FirstName, LastName = re.LastName }));
            this.Result = Task.FromResult(new GetRaffleEntriesViewModel { RaffleEntries = entriesViewModel });
            return this.Result;
        }

        public Task<GetRaffleEntriesViewModel> PresentRaffleNotFound(int raffleId)
        {
            this.PresentedSuccessfully = false;
            this.Result = Task.FromResult(new GetRaffleEntriesViewModel { RaffleEntries = new List<RaffleEntryViewModel> { new RaffleEntryViewModel { Errors = $"A raffle with the Id '{raffleId}' was not found." } } });
            return this.Result;
        }
    }
}
