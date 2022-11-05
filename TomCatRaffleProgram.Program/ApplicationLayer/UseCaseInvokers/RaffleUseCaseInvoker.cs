using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCaseInvokers
{
    class RaffleUseCaseInvoker
    {
        private CreateRaffleBusinessRuleValidator BusinessRuleValidator = new CreateRaffleBusinessRuleValidator(new StringServices());

        public async Task<IViewModel> InvokeCreateRaffle(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
            => await this.BusinessRuleValidator.ValidateAsync(inputPort, outputPort);
    }
}
