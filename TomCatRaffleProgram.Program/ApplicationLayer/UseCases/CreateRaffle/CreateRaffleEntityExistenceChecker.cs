using System.Linq;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle
{
    class CreateRaffleEntityExistenceChecker
    {

        private FileServices FileServices = new FileServices();
        private readonly IPersistenceContext PersistenceContext;

        public CreateRaffleInteractor Interactor;

        public CreateRaffleEntityExistenceChecker(IPersistenceContext persistenceContext)
        {
            this.PersistenceContext = persistenceContext;
            this.Interactor = new CreateRaffleInteractor(this.PersistenceContext);
        }

        public async Task<IViewModel> ValidateAsync(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
        {
            if (!this.FileServices.DoesFileExist())
                await outputPort.PresentFileNotFoundAsync();

            if (this.PersistenceContext.GetEntities<Raffle>().Where(r => r.Attribute("Name").Value == inputPort.RaffleName).SingleOrDefault() != null)
                return await outputPort.PresentRaffleExistsAsync(inputPort.RaffleName);

            return await this.Interactor.CreateRaffleAsync(inputPort, outputPort);
        }
    }
}
