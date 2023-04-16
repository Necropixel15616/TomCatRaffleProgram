using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.GetRaffleEntries
{
    class GetRaffleEntriesInteractor : IInteractor<GetRaffleEntriesInputPort, IGetRaffleEntriesOutputPort>
    {
        private readonly IRaffleRepository PersistenceContext;

        public GetRaffleEntriesInteractor(IRaffleRepository persistenceContext)
            => PersistenceContext = persistenceContext;

        Task IInteractor<GetRaffleEntriesInputPort, IGetRaffleEntriesOutputPort>.HandleAsync(
            GetRaffleEntriesInputPort inputPort,
            IGetRaffleEntriesOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            var raffle = PersistenceContext.Find<Raffle>(inputPort.RaffleId);

            var raffleEntryDtos = new List<RaffleEntryDto>();
            raffle.Entries.ForEach(e => raffleEntryDtos.Add(new RaffleEntryDto(e)));

            return outputPort.PresentRaffleEntriesAsync(raffleEntryDtos, cancellationToken);
        }
    }
}
