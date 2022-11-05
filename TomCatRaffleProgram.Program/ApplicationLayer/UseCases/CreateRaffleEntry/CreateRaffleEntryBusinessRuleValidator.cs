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
        private readonly CreateRaffleEntryEntityExistenceChecker EntityExistencePipeline = new CreateRaffleEntryEntityExistenceChecker();

        private readonly StringServices StringServices;

        public CreateRaffleEntryBusinessRuleValidator(StringServices stringServices)
            => this.StringServices = stringServices ?? new StringServices();

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
