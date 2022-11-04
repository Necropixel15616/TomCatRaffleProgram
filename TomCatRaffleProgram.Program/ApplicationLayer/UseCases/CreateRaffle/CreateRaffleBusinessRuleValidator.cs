using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle
{
    class CreateRaffleBusinessRuleValidator
    {

        public StringServices StringServices;

        public CreateRaffleEntityExistenceChecker EntityExistenceChecker = new CreateRaffleEntityExistenceChecker();

        public CreateRaffleBusinessRuleValidator(StringServices stringServices)
            => this.StringServices = stringServices ?? new StringServices();

        public async Task ValidateAsync(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
        {
            if (this.StringServices.IsNullOrWhitespaceOrEmpty(inputPort.RaffleName))
                await outputPort.ValidationFailure();

            await this.EntityExistenceChecker.ValidateAsync(inputPort, outputPort);
        }

    }
}
