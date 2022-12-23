using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.CreateRaffleEntry
{
    class CreateRaffleEntryEntityExistenceChecker : IEntityExistenceCheckerPipe<CreateRaffleEntryInputPort, ICreateRaffleEntryOutputPort>
    {
        private readonly IFileServices FileServices;
        private readonly IRaffleRepository PersistenceContext;

        public CreateRaffleEntryEntityExistenceChecker(IFileServices fileServices, IRaffleRepository persistenceContext)
        {
            FileServices = fileServices;
            PersistenceContext = persistenceContext;
        }

        bool IEntityExistenceCheckerPipe<CreateRaffleEntryInputPort, ICreateRaffleEntryOutputPort>.ValidateEntityExist(CreateRaffleEntryInputPort inputPort, ICreateRaffleEntryOutputPort outputPort)
        {
            if (!this.FileServices.DoesFileExist())
            {
                outputPort.PresentFileNotFound();
                return false;
            }

            if (this.PersistenceContext.Find(inputPort.RaffleId) == null)
            {
                outputPort.PresentRaffleNotFoundAsync(inputPort.RaffleId);
                return false;
            }

            return true;
        }
    }
}
