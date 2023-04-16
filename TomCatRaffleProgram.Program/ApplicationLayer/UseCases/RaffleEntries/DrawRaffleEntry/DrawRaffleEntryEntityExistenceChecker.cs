using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DrawRaffleEntry
{
    public class DrawRaffleEntryEntityExistenceChecker : IEntityExistenceChecker<DrawRaffleEntryInputPort, IDrawRaffleEntryOutputPort>
    {
        private readonly IRaffleRepository RaffleRepository;

        public DrawRaffleEntryEntityExistenceChecker(IRaffleRepository raffleRepository)
            => RaffleRepository = raffleRepository;

        async Task<bool> IEntityExistenceChecker<DrawRaffleEntryInputPort, IDrawRaffleEntryOutputPort>.ValidateEntityExistAsync(
            DrawRaffleEntryInputPort inputPort,
            IDrawRaffleEntryOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            if (RaffleRepository.Find<Raffle>(inputPort.RaffleId) == null)
            {
                await outputPort.PresentRaffleNotFoundAsyc(inputPort.RaffleId, cancellationToken);
                return false;
            }

            return true;
        }
    }
}
