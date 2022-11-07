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

        private readonly StringServices StringServices;
        private readonly IPersistenceContext PersistenceContext;

        public CreateRaffleEntryBusinessRuleValidator(StringServices stringServices, IPersistenceContext persistenceContext)
        {
            StringServices = stringServices ?? new StringServices();
            this.PersistenceContext = persistenceContext;
            this.EntityExistencePipeline = new CreateRaffleEntryEntityExistenceChecker(this.PersistenceContext);
        }

        public async Task<IViewModel> ValidateAsync(CreateRaffleEntryInputPort inputPort, ICreateRaffleEntryOutputPort outputPort)
        {
            List<string> validationFailures = new List<string>();
            if (this.StringServices.IsNullOrWhitespaceOrEmpty(inputPort.FirstName))
                validationFailures.Add("The First Name of a customer cannot be empty.");
            if (this.StringServices.IsNullOrWhitespaceOrEmpty(inputPort.LastName))
                validationFailures.Add("The Last Name of a customer cannot be empty.");

            if (validationFailures.Any())
                return await outputPort.PresentValidationFailureAsync(validationFailures);

            return await EntityExistencePipeline.ValidateAsync(inputPort, outputPort);
        }

    }
}
