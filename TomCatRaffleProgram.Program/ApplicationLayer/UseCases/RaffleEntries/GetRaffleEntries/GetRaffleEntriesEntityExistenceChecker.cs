using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.GetRaffleEntries
{
    class GetRaffleEntriesEntityExistenceChecker : IEntityExistenceCheckerPipe<GetRaffleEntriesInputPort, IGetRaffleEntriesOutputPort>
    {

        private readonly IFileServices FileServices;
        private readonly IRaffleRepository PersistenceContext;

        public GetRaffleEntriesEntityExistenceChecker(IFileServices fileServices, IRaffleRepository persistenceContext)
        {
            FileServices = fileServices;
            PersistenceContext = persistenceContext;
        }

        bool IEntityExistenceCheckerPipe<GetRaffleEntriesInputPort, IGetRaffleEntriesOutputPort>.ValidateEntityExist(GetRaffleEntriesInputPort inputPort, IGetRaffleEntriesOutputPort outputPort)
        {
            if (!this.FileServices.DoesFileExist())
            {
                outputPort.PresentFileNotFoundAsync();
                return false;
            }

            if (this.PersistenceContext.Find(inputPort.RaffleId) == null)
            {
                outputPort.PresentRaffleNotFound(inputPort.RaffleId);
                return false;
            }

            return true;
        }
    }
}
