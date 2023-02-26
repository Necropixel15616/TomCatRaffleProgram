using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.CreateRaffleEntry
{
    class CreateRaffleEntryEntityExistenceChecker : IEntityExistenceChecker<CreateRaffleEntryInputPort, ICreateRaffleEntryOutputPort>
    {
        private readonly IFileServices FileServices;
        private readonly IRaffleRepository PersistenceContext;

        public CreateRaffleEntryEntityExistenceChecker(IFileServices fileServices, IRaffleRepository persistenceContext)
        {
            FileServices = fileServices;
            PersistenceContext = persistenceContext;
        }

        async Task<bool> IEntityExistenceChecker<CreateRaffleEntryInputPort, ICreateRaffleEntryOutputPort>.ValidateEntityExistAsync(
            CreateRaffleEntryInputPort inputPort,
            ICreateRaffleEntryOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            if (!this.FileServices.DoesFileExist())
            {
                await outputPort.PresentFileNotFound(cancellationToken);
                return false;
            }

            if (this.PersistenceContext.Find(inputPort.RaffleId) == null)
            {
                await outputPort.PresentRaffleNotFoundAsync(inputPort.RaffleId, cancellationToken);
                return false;
            }

            return true;
        }
    }
}
