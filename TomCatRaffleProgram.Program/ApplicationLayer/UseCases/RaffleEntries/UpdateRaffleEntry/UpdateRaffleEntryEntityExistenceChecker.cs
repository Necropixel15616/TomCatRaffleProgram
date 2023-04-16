using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.UpdateRaffleEntry
{
    public class UpdateRaffleEntryEntityExistenceChecker : IEntityExistenceChecker<UpdateRaffleEntryInputPort, IUpdateRaffleEntryOutputPort>
    {
        private readonly IRaffleRepository RaffleRepository;

        public UpdateRaffleEntryEntityExistenceChecker(IRaffleRepository raffleRepository)
            => RaffleRepository = raffleRepository;

        async Task<bool> IEntityExistenceChecker<UpdateRaffleEntryInputPort, IUpdateRaffleEntryOutputPort>.ValidateEntityExistAsync(
            UpdateRaffleEntryInputPort inputPort,
            IUpdateRaffleEntryOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            if (RaffleRepository.Find<Raffle>(inputPort.RaffleId) == null)
            {
                await outputPort.PresentRaffleNotFoundAsync(inputPort.RaffleId, cancellationToken);
                return false;
            }

            if (RaffleRepository.Find<RaffleEntry>(inputPort.RaffleId, inputPort.RaffleEntryId) == null)
            {
                await outputPort.PresentRaffleEntryNotFoundAsync(inputPort.RaffleEntryId, cancellationToken);
                return false;
            }

            return true;
        }
    }
}
