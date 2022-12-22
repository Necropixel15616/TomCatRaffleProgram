using System.Collections.Generic;
using System.Linq;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffleEntry
{
    class CreateRaffleEntryInputPortValidator : IInputPortValidatorPipe<CreateRaffleEntryInputPort, ICreateRaffleEntryOutputPort>
    {
        public CreateRaffleEntryInputPortValidator() { }

        bool IInputPortValidatorPipe<CreateRaffleEntryInputPort, ICreateRaffleEntryOutputPort>.ValidateAsync(CreateRaffleEntryInputPort inputPort, ICreateRaffleEntryOutputPort outputPort)
        {
            List<string> validationFailures = new List<string>();
            if (inputPort.FirstName.IsNullOrWhitespaceOrEmpty())
                validationFailures.Add("The First Name of a customer cannot be empty.");
            if (inputPort.LastName.IsNullOrWhitespaceOrEmpty())
                validationFailures.Add("The Last Name of a customer cannot be empty.");

            if (validationFailures.Any())
            {
                outputPort.PresentValidationFailureAsync(validationFailures);
                return false;
            }


            return true;
        }
    }
}
