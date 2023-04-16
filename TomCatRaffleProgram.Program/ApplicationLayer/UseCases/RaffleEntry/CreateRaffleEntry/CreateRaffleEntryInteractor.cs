using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.CreateRaffleEntry
{
    class CreateRaffleEntryInteractor : IInteractor<CreateRaffleEntryInputPort, ICreateRaffleEntryOutputPort>
    {
        private readonly IRaffleRepository PersistenceContext;

        public CreateRaffleEntryInteractor(IRaffleRepository persistenceContext)
            => this.PersistenceContext = persistenceContext;

        async Task IInteractor<CreateRaffleEntryInputPort, ICreateRaffleEntryOutputPort>.HandleAsync(
            CreateRaffleEntryInputPort inputPort,
            ICreateRaffleEntryOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            Raffle raffle = (Raffle)PersistenceContext.Find(inputPort.RaffleId);

            var id = 0;
            raffle?.Entries.ForEach(e =>
            {
                if (e.Id > id)
                    id = e.Id;
            });
            id++;

            var raffleEntry = new RaffleEntry(id, inputPort.FirstName, inputPort.LastName, inputPort.Tickets);
            raffle.Entries.Add(raffleEntry);
            await outputPort.PresentRaffleEntryAsync(new RaffleEntryDto(raffleEntry), cancellationToken);
        }
    }
}
