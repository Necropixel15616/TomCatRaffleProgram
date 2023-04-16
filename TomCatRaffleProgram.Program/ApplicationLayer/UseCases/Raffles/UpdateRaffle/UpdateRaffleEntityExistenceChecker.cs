using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.UpdateRaffle
{
    public class UpdateRaffleEntityExistenceChecker : IEntityExistenceChecker<UpdateRaffleInputPort, IUpdateRaffleOutputPort>
    {
        private readonly IRaffleRepository RaffleRepository;

        public UpdateRaffleEntityExistenceChecker(IRaffleRepository raffleRepository)
            => RaffleRepository = raffleRepository;

        async Task<bool> IEntityExistenceChecker<UpdateRaffleInputPort, IUpdateRaffleOutputPort>.ValidateEntityExistAsync(
            UpdateRaffleInputPort inputPort,
            IUpdateRaffleOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            if (RaffleRepository.Find<Raffle>(inputPort.RaffleId) == null)
            {
                await outputPort.PresentRaffleNotFoundAsync(inputPort.RaffleId, cancellationToken);
                return false;
            }

            return true;
        }
    }
}
