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

        bool IEntityExistenceChecker<DeleteRaffleEntryInputPort, IDeleteRaffleEntryOutputPort>.ValidateEntityExist(DeleteRaffleEntryInputPort inputPort, IDeleteRaffleEntryOutputPort outputPort)
        {
            if (!FileServices.DoesFileExist())
            {
                outputPort.PresentFileNotFound();
                return false;
            }

            if (RaffleRepository.Find(inputPort.RaffleId) == null)
            {
                outputPort.PresentRaffleNotFound(inputPort.RaffleId);
                return false;
            }

            if (RaffleRepository.Find(inputPort.RaffleId, inputPort.RaffleEntryId) == null)
            {
                outputPort.PresentRaffleEntryNotFound(inputPort.RaffleEntryId, inputPort.RaffleId);
                return false;
            }

            return true;
        }
    }
}
