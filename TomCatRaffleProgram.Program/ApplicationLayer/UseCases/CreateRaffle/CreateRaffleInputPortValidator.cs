using System.Collections.Generic;
using System.Linq;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle
{
    class CreateRaffleInputPortValidator : IInputPortValidatorPipe<CreateRaffleInputPort, ICreateRaffleOutputPort>
    {
        private readonly IRaffleRepository PersistenceContext;
        public CreateRaffleEntityExistenceChecker EntityExistenceChecker;

        public CreateRaffleInputPortValidator(IRaffleRepository persistenceContext)
        {
            this.PersistenceContext = persistenceContext;
            this.EntityExistenceChecker = new CreateRaffleEntityExistenceChecker(this.PersistenceContext);
        }

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
