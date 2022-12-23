using System.Linq;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.CreateRaffle
{
    class CreateRaffleEntityExistenceChecker : IEntityExistenceCheckerPipe<CreateRaffleInputPort, ICreateRaffleOutputPort>
    {

        private readonly IFileServices FileServices;
        private readonly IRaffleRepository PersistenceContext;

        public CreateRaffleEntityExistenceChecker(IFileServices fileServices, IRaffleRepository persistenceContext)
        {
            FileServices = fileServices;
            PersistenceContext = persistenceContext;
        }

        bool IEntityExistenceCheckerPipe<CreateRaffleInputPort, ICreateRaffleOutputPort>.ValidateEntityExist(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
        {
            if (!FileServices.DoesFileExist())
            {
                outputPort.PresentFileNotFoundAsync();
                return false;
            }

            if (PersistenceContext.GetRaffles()
                    .Where(r => r.Name.ToUpper().Equals(inputPort.RaffleName.ToUpper()))
                    .SingleOrDefault() != null)
            {
                outputPort.PresentRaffleExistsAsync(inputPort.RaffleName);
                return false;
            }

            return true;
        }
    }
}
