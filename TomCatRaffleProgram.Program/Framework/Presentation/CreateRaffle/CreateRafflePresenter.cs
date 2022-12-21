using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;

namespace TomCatRaffleProgram.Program.Framework.Presentation.CreateRaffle
{
    class CreateRafflePresenter : ICreateRaffleOutputPort, IOutputPortPresenter<RaffleViewModel>
    {
        public Task<RaffleViewModel> Result { get; set; }
        public bool PresentedSuccessfully { get; set; }

        public Task PresentFileNotFoundAsync()
        {
            this.PresentedSuccessfully = false;
            this.Result = Task.FromResult(new RaffleViewModel { Errors = "The File was not found." });
            return this.Result;
        }

        Task ICreateRaffleOutputPort.PresentRaffleCreatedAsync(RaffleDto raffle)
        {
            this.PresentedSuccessfully = true;
            this.Result = Task.FromResult(new RaffleViewModel(raffle));
            return this.Result;
        }

        Task ICreateRaffleOutputPort.PresentRaffleExistsAsync(string name)
        {
            this.PresentedSuccessfully = false;
            this.Result = Task.FromResult(new RaffleViewModel { Errors = $"A Raffle with the name {name} already exists." });
            return this.Result;
        }

        Task ICreateRaffleOutputPort.PresentValidationFailureAsync(List<string> failures)
        {
            this.PresentedSuccessfully = false;
            var errorMessages = string.Empty;
            failures.ForEach(f => errorMessages += $"{f}\n");
            this.Result = Task.FromResult(new RaffleViewModel { Errors = errorMessages });
            return this.Result;
        }

    }
}
