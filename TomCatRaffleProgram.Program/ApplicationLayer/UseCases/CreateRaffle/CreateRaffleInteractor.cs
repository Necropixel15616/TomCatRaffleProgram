using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle
{
    class CreateRaffleInteractor : IInteractorPipe<CreateRaffleInputPort, ICreateRaffleOutputPort>
    {

        public readonly IPersistenceContext PersistenceContext;

        public CreateRaffleInteractor(IPersistenceContext persistenceContext)
            => PersistenceContext = persistenceContext;

        async Task<IViewModel> IInteractorPipe<CreateRaffleInputPort, ICreateRaffleOutputPort>.HandleAsync(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
        {
            List<Raffle> raffles = this.PersistenceContext.GetEntities<Raffle>();
            var id = 0;
            foreach (var r in raffles)
                if (id < r.Id)
                    id = r.Id;
            id++;

            var raffle = new Raffle(inputPort.RaffleName, id);
            this.PersistenceContext.Add(raffle);
            this.PersistenceContext.Save();
            return await outputPort.PresentRaffleCreatedAsync(new RaffleDto(raffle));
        }
    }
}
