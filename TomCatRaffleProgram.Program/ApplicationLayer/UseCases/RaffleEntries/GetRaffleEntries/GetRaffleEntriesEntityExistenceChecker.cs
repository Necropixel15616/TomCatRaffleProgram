using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.GetRaffleEntries
{
    public class GetRaffleEntriesEntityExistenceChecker : IEntityExistenceChecker<GetRaffleEntriesInputPort, IGetRaffleEntriesOutputPort>
    {

        private readonly IFileServices FileServices;
        private readonly IRaffleRepository PersistenceContext;

        public GetRaffleEntriesEntityExistenceChecker(IFileServices fileServices, IRaffleRepository persistenceContext)
        {
            FileServices = fileServices;
            PersistenceContext = persistenceContext;
        }

        async Task<bool> IEntityExistenceChecker<GetRaffleEntriesInputPort, IGetRaffleEntriesOutputPort>.ValidateEntityExistAsync(
            GetRaffleEntriesInputPort inputPort,
            IGetRaffleEntriesOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            if (this.PersistenceContext.Find<Raffle>(inputPort.RaffleId) == null)
            {
                await outputPort.PresentRaffleNotFoundAsync(inputPort.RaffleId, cancellationToken);
                return false;
            }

            return true;
        }
    }
}
