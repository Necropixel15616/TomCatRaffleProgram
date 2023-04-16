using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DeleteRaffleEntry
{
    class DeleteRaffleEntryInteractor : IInteractor<DeleteRaffleEntryInputPort, IDeleteRaffleEntryOutputPort>
    {

        private readonly IRaffleRepository RaffleRepository;

        public DeleteRaffleEntryInteractor(IRaffleRepository raffleRepository)
            => RaffleRepository = raffleRepository;

        Task IInteractor<DeleteRaffleEntryInputPort, IDeleteRaffleEntryOutputPort>.HandleAsync(
            DeleteRaffleEntryInputPort inputPort,
            IDeleteRaffleEntryOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            var raffle = RaffleRepository.Find<Raffle>(inputPort.RaffleId);

            raffle.Entries.Remove(raffle.Entries.Where(re => re.Id == inputPort.RaffleEntryId).SingleOrDefault());
            return outputPort.PresentRaffleEntryDeletedAsync(cancellationToken);
        }
    }
}
