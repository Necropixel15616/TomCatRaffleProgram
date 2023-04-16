using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.CreateRaffleEntry
{
    class CreateRaffleEntryInputPortValidator : IInputPortValidator<CreateRaffleEntryInputPort, ICreateRaffleEntryOutputPort>
    {
        public CreateRaffleEntryInputPortValidator() { }

        async Task<bool> IInputPortValidator<CreateRaffleEntryInputPort, ICreateRaffleEntryOutputPort>.ValidateAsync(
            CreateRaffleEntryInputPort inputPort,
            ICreateRaffleEntryOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            List<string> validationFailures = new List<string>();
            if (inputPort.FirstName.IsNullOrWhitespaceOrEmpty())
                validationFailures.Add("The First Name of a customer cannot be empty.");
            if (inputPort.LastName.IsNullOrWhitespaceOrEmpty())
                validationFailures.Add("The Last Name of a customer cannot be empty.");

            if (validationFailures.Any())
            {
                await outputPort.PresentValidationFailureAsync(validationFailures, cancellationToken);
                return false;
            }

            return true;
        }
    }
}
