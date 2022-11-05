using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCaseInvokers;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.InterfaceAdapters.Controllers
{
    class RaffleController
    {
        public readonly RaffleUseCaseInvoker RaffleUseCaseInvoker = new RaffleUseCaseInvoker();

        public async Task<IViewModel> CreateRaffleAsync(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
            => await this.RaffleUseCaseInvoker.InvokeCreateRaffle(inputPort, outputPort);
    }
}
