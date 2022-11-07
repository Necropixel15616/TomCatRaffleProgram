using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCaseInvokers;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.InterfaceAdapters.Controllers
{
    class RaffleController
    {
        private readonly IPersistenceContext PersistenceContext;
        public RaffleUseCaseInvoker RaffleUseCaseInvoker;

        public RaffleController(IPersistenceContext persistenceContext)
        {
            this.PersistenceContext = persistenceContext;
            this.RaffleUseCaseInvoker = new RaffleUseCaseInvoker(this.PersistenceContext);
        }

        public async Task<IViewModel> CreateRaffleAsync(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
            => await this.RaffleUseCaseInvoker.InvokeCreateRaffle(inputPort, outputPort);
    }
}
