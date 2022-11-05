using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffleEntry;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;

namespace TomCatRaffleProgram.Program.Framework.Presentation.CreateRaffleEntry
{
    class CreateRaffleEntryPresenter : IOutputPortPresenter<RaffleEntryViewModel>, ICreateRaffleEntryOutputPort
    {
        public Task<RaffleEntryViewModel> Result { get; set; }

        public bool PresentedSuccessfully { get; set; }

        Task<RaffleEntryViewModel> ICreateRaffleEntryOutputPort.PresentFileNotFoundAsync()
        {
            this.PresentedSuccessfully = false;
            this.Result = Task.FromResult(new RaffleEntryViewModel { Errors = "The File was not found." });
            return this.Result;
        }

        Task<RaffleEntryViewModel> ICreateRaffleEntryOutputPort.PresentRaffleEntryAsync(EntryDto entry)
        {
            this.PresentedSuccessfully = true;
            this.Result = Task.FromResult(new RaffleEntryViewModel { FirstName = entry.FirstName, LastName = entry.LastName });
            return this.Result;
        }

        Task<RaffleEntryViewModel> ICreateRaffleEntryOutputPort.PresentRaffleNotFoundAsync(int raffleId)
        {
            this.PresentedSuccessfully = false;
            this.Result = Task.FromResult(new RaffleEntryViewModel { Errors = $"A raffle with the Id '{raffleId} was not found." });
            return this.Result;
        }

        Task<RaffleEntryViewModel> ICreateRaffleEntryOutputPort.PresentValidationFailureAsync(List<string> failures)
        {
            this.PresentedSuccessfully = false;
            var errorMessages = string.Empty;
            failures.ForEach(f => errorMessages += $"{f}\n");
            this.Result = Task.FromResult(new RaffleEntryViewModel { Errors = errorMessages });
            return this.Result;
        }
    }
}
