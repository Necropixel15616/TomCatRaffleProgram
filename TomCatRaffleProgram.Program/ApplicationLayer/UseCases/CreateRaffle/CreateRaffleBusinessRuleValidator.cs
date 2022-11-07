using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle
{
    class CreateRaffleBusinessRuleValidator
    {
        private readonly IPersistenceContext PersistenceContext;
        public CreateRaffleEntityExistenceChecker EntityExistenceChecker;

        public CreateRaffleBusinessRuleValidator(IPersistenceContext persistenceContext)
        {
            this.PersistenceContext = persistenceContext;
            this.EntityExistenceChecker = new CreateRaffleEntityExistenceChecker(this.PersistenceContext);
        }

        public async Task<IViewModel> ValidateAsync(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
        {
            List<string> validationFailures = new List<string>();
            if (inputPort.RaffleName.IsNullOrWhitespaceOrEmpty())
                validationFailures.Add("Raffle Names must not be empty.");

            if (validationFailures.Any())
                return await outputPort.PresentValidationFailureAsync(validationFailures);

            return await this.EntityExistenceChecker.ValidateAsync(inputPort, outputPort);
        }

    }
}
