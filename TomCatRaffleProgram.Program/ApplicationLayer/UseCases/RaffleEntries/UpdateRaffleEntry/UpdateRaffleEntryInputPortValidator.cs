using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.UpdateRaffleEntry
{
    public class UpdateRaffleEntryInputPortValidator : IInputPortValidator<UpdateRaffleEntryInputPort, IUpdateRaffleEntryOutputPort>
    {
        async Task<bool> IInputPortValidator<UpdateRaffleEntryInputPort, IUpdateRaffleEntryOutputPort>.ValidateAsync(
            UpdateRaffleEntryInputPort inputPort,
            IUpdateRaffleEntryOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            var validationFailures = new List<string>();

            if (inputPort.FirstName.IsNullOrWhitespaceOrEmpty())
                validationFailures.Add("The First Name of a customer cannot be empty.");
            if (inputPort.LastName.IsNullOrWhitespaceOrEmpty())
                validationFailures.Add("The Last Name of a customer cannot be empty.");
            if (inputPort.Tickets <= 0)
                validationFailures.Add("Ticket count cannot be less than or equal to 0");

            if (validationFailures.Any())
            {
                await outputPort.PresentValidationFailuresAsync(validationFailures, cancellationToken);
                return false;
            }

            return true;
        }
    }
}
