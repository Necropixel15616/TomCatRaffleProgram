using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DeleteRaffleEntry
{
    class DeleteRaffleEntryEntityExistenceChecker : IEntityExistenceChecker<DeleteRaffleEntryInputPort, IDeleteRaffleEntryOutputPort>
    {

        private readonly IFileServices FileServices;
        private readonly IRaffleRepository RaffleRepository;

        public DeleteRaffleEntryEntityExistenceChecker(IRaffleRepository raffleRepository, IFileServices fileServices)
        {
            FileServices = fileServices;
            RaffleRepository = raffleRepository;
        }

        async Task<bool> IEntityExistenceChecker<DeleteRaffleEntryInputPort, IDeleteRaffleEntryOutputPort>.ValidateEntityExistAsync(
            DeleteRaffleEntryInputPort inputPort,
            IDeleteRaffleEntryOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            if (!FileServices.DoesFileExist())
            {
                await outputPort.PresentFileNotFound(cancellationToken);
                return false;
            }

            if (RaffleRepository.Find(inputPort.RaffleId) == null)
            {
                await outputPort.PresentRaffleNotFound(inputPort.RaffleId, cancellationToken);
                return false;
            }

            if (RaffleRepository.Find(inputPort.RaffleId, inputPort.RaffleEntryId) == null)
            {
                await outputPort.PresentRaffleEntryNotFound(inputPort.RaffleEntryId, inputPort.RaffleId, cancellationToken);
                return false;
            }

            return true;
        }
    }
}
