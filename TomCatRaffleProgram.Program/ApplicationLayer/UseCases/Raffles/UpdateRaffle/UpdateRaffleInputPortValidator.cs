using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.UpdateRaffle
{
    public class UpdateRaffleInputPortValidator : IInputPortValidator<UpdateRaffleInputPort, IUpdateRaffleOutputPort>
    {
        async Task<bool> IInputPortValidator<UpdateRaffleInputPort, IUpdateRaffleOutputPort>.ValidateAsync(
            UpdateRaffleInputPort inputPort,
            IUpdateRaffleOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            var validationFailures = new List<string>();

            if (inputPort.Name.IsNullOrWhitespaceOrEmpty())
                validationFailures.Add("The Raffle Name cannot be empty.");

            if (validationFailures.Any())
            {
                await outputPort.PresentValidationFailuresAsync(validationFailures, cancellationToken);
                return false;
            }

            return true;
        }
    }
}
