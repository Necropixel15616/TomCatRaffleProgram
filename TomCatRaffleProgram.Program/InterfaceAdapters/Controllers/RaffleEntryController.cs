using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCaseInvokers;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffleEntry;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.GetRaffleEntries;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.InterfaceAdapters.Controllers
{
    class RaffleEntryController
    {

        private readonly RaffleEntryUseCaseInvoker UseCaseInvoker;
        private readonly IRaffleRepository PersistenceContext;

        public RaffleEntryController(IRaffleRepository persistenceContext)
        {
            this.PersistenceContext = persistenceContext;
            this.UseCaseInvoker = new RaffleEntryUseCaseInvoker(this.PersistenceContext);
        }

        public async Task<IViewModel> CreateRaffleEntryAsync(CreateRaffleEntryInputPort inputPort, ICreateRaffleEntryOutputPort outputPort)
            => await this.UseCaseInvoker.InvokeCreateRaffleEntryAsync(inputPort, outputPort);

        public async Task<IViewModel> GetRaffleEntriesAsync(GetRaffleEntriesInputPort inputPort, IGetRaffleEntriesOutputPort outputPort)
            => await this.UseCaseInvoker.InvokeGetRaffleEntriesAsync(inputPort, outputPort);

    }
}
