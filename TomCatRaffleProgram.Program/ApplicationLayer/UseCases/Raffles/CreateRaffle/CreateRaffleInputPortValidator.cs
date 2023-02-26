using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.CreateRaffle
{
    class CreateRaffleInputPortValidator : IInputPortValidator<CreateRaffleInputPort, ICreateRaffleOutputPort>
    {
        public CreateRaffleInputPortValidator() { }

        async Task<bool> IInputPortValidator<CreateRaffleInputPort, ICreateRaffleOutputPort>.ValidateAsync(
            CreateRaffleInputPort inputPort,
            ICreateRaffleOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            List<string> validationFailures = new List<string>();
            if (inputPort.RaffleName.IsNullOrWhitespaceOrEmpty())
                validationFailures.Add("Raffle Names must not be empty.");

            if (validationFailures.Any())
            {
                await outputPort.PresentValidationFailureAsync(validationFailures, cancellationToken);
                return false;
            }

            return true;
        }
    }
}
