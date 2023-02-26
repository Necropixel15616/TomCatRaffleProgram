using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.CreateRaffle
{
    class CreateRaffleEntityExistenceChecker : IEntityExistenceChecker<CreateRaffleInputPort, ICreateRaffleOutputPort>
    {

        private readonly IFileServices FileServices;
        private readonly IRaffleRepository PersistenceContext;

        public CreateRaffleEntityExistenceChecker(IFileServices fileServices, IRaffleRepository persistenceContext)
        {
            FileServices = fileServices;
            PersistenceContext = persistenceContext;
        }

        async Task<bool> IEntityExistenceChecker<CreateRaffleInputPort, ICreateRaffleOutputPort>.ValidateEntityExistAsync(
            CreateRaffleInputPort inputPort,
            ICreateRaffleOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            if (!FileServices.DoesFileExist())
            {
                await outputPort.PresentFileNotFoundAsync(cancellationToken);
                return false;
            }

            if (PersistenceContext.GetRaffles()
                    .Where(r => r.Name.ToUpper().Equals(inputPort.RaffleName.ToUpper()))
                    .SingleOrDefault() != null)
            {
                await outputPort.PresentRaffleExistsAsync(inputPort.RaffleName, cancellationToken);
                return false;
            }

            return true;
        }
    }
}
