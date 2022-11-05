using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffleEntry;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.GetRaffleEntries;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCaseInvokers
{
    class RaffleEntryUseCaseInvoker
    {

        private readonly GetRaffleEntriesEntityExistenceChecker GetRaffleEntriesEntityExistenceChecker = new GetRaffleEntriesEntityExistenceChecker();
        private readonly CreateRaffleEntryBusinessRuleValidator CreateRaffleEntryBusinessRuleValidator;

        public RaffleEntryUseCaseInvoker()
            => this.CreateRaffleEntryBusinessRuleValidator = new CreateRaffleEntryBusinessRuleValidator(new StringServices());

        public async Task<IViewModel> InvokeGetRaffleEntriesAsync(GetRaffleEntriesInputPort inputPort, IGetRaffleEntriesOutputPort outputPort)
            => await this.GetRaffleEntriesEntityExistenceChecker.ValidateAsync(inputPort, outputPort);

        public async Task<IViewModel> InvokeCreateRaffleEntryAsync(CreateRaffleEntryInputPort inputPort, ICreateRaffleEntryOutputPort outputPort)
            => await this.CreateRaffleEntryBusinessRuleValidator.ValidateAsync(inputPort, outputPort);

    }
}
