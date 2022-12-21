using System.Linq;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle
{
    class CreateRaffleEntityExistenceChecker : IEntityExistenceCheckerPipe<CreateRaffleInputPort, ICreateRaffleOutputPort>
    {

        private FileServices FileServices = new FileServices();
        private readonly IPersistenceContext PersistenceContext;

        public CreateRaffleInteractor Interactor;

        public CreateRaffleEntityExistenceChecker(IPersistenceContext persistenceContext)
        {
            this.PersistenceContext = persistenceContext;
            this.Interactor = new CreateRaffleInteractor(this.PersistenceContext);
        }

        bool IEntityExistenceCheckerPipe<CreateRaffleInputPort, ICreateRaffleOutputPort>.ValidateEntityExist(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
        {
            if (!this.FileServices.DoesFileExist())
            {
                outputPort.PresentFileNotFoundAsync();
                return false;
            }

            if (this.PersistenceContext.GetEntities<Raffle>()
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
