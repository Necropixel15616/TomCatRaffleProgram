using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffleEntry
{
    class CreateRaffleEntryBusinessRuleValidator
    {
        private readonly CreateRaffleEntryEntityExistenceChecker EntityExistencePipeline;

        private readonly IRaffleRepository PersistenceContext;

        public CreateRaffleEntryBusinessRuleValidator(IRaffleRepository persistenceContext)
        {
            this.PersistenceContext = persistenceContext;
            this.EntityExistencePipeline = new CreateRaffleEntryEntityExistenceChecker(this.PersistenceContext);
        }

        public async Task<IViewModel> ValidateAsync(CreateRaffleEntryInputPort inputPort, ICreateRaffleEntryOutputPort outputPort)
        {
            List<string> validationFailures = new List<string>();
            if (inputPort.FirstName.IsNullOrWhitespaceOrEmpty())
                validationFailures.Add("The First Name of a customer cannot be empty.");
            if (inputPort.LastName.IsNullOrWhitespaceOrEmpty())
                validationFailures.Add("The Last Name of a customer cannot be empty.");

            if (validationFailures.Any())
                return await outputPort.PresentValidationFailureAsync(validationFailures);

            return await EntityExistencePipeline.ValidateAsync(inputPort, outputPort);
        }

    }
}
