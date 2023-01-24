using System.Collections.Generic;
using System.Linq;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.CreateRaffle
{
    class CreateRaffleInputPortValidator : IInputPortValidatorPipe<CreateRaffleInputPort, ICreateRaffleOutputPort>
    {
        public CreateRaffleInputPortValidator() { }

        bool IInputPortValidatorPipe<CreateRaffleInputPort, ICreateRaffleOutputPort>.ValidateAsync(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
        {
            List<string> validationFailures = new List<string>();
            if (inputPort.RaffleName.IsNullOrWhitespaceOrEmpty())
                validationFailures.Add("Raffle Names must not be empty.");

            if (validationFailures.Any())
            {
                outputPort.PresentValidationFailureAsync(validationFailures);
                return false;
            }

            return true;
        }
    }
}
