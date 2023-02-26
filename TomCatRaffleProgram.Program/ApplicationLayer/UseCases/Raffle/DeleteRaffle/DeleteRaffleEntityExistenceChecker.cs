using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.DeleteRaffle
{
    class DeleteRaffleEntityExistenceChecker : IEntityExistenceChecker<DeleteRaffleInputPort, IDeleteRaffleOutputPort>
    {
        private readonly IFileServices FileServices;
        private readonly IRaffleRepository RaffleRepository;

        public DeleteRaffleEntityExistenceChecker(IFileServices fileServices, IRaffleRepository raffleRepository)
        {
            this.FileServices = fileServices;
            this.RaffleRepository = raffleRepository;
        }

        async Task<bool> IEntityExistenceChecker<DeleteRaffleInputPort, IDeleteRaffleOutputPort>.ValidateEntityExistAsync(
            DeleteRaffleInputPort inputPort,
            IDeleteRaffleOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            if (!FileServices.DoesFileExist())
            {
                await outputPort.PresentFileNotFoundAsync(cancellationToken);
                return false;
            }

            if (RaffleRepository.Find(inputPort.RaffleId) == null)
            {
                await outputPort.PresentRaffleNotFoundAsync(inputPort.RaffleId, cancellationToken);
                return false;
            }

            return true;
        }
    }
}
