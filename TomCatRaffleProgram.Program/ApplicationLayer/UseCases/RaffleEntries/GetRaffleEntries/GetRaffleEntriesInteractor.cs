using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.GetRaffleEntries
{
    class GetRaffleEntriesInteractor : IInteractorPipe<GetRaffleEntriesInputPort, IGetRaffleEntriesOutputPort>
    {
        private readonly IRaffleRepository PersistenceContext;

        public GetRaffleEntriesInteractor(IRaffleRepository persistenceContext)
            => PersistenceContext = persistenceContext;

        Task IInteractorPipe<GetRaffleEntriesInputPort, IGetRaffleEntriesOutputPort>.HandleAsync(GetRaffleEntriesInputPort inputPort, IGetRaffleEntriesOutputPort outputPort)
        {
            var raffle = (Raffle)PersistenceContext.Find(inputPort.RaffleId);

            var raffleEntryDtos = new List<RaffleEntryDto>();
            raffle.Entries.ForEach(e => raffleEntryDtos.Add(new RaffleEntryDto(e)));

            return outputPort.PresentRaffleEntriesAsync(raffleEntryDtos);
        }
    }
}
