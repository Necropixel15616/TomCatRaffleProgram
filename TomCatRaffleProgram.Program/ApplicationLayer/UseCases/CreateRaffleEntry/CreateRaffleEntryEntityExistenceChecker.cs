using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffleEntry
{
    class CreateRaffleEntryEntityExistenceChecker
    {
        private readonly FileServices FileServices = new FileServices();

        public CreateRaffleEntryInteractor Interactor;
        private readonly IPersistenceContext PersistenceContext;

        public CreateRaffleEntryEntityExistenceChecker(IPersistenceContext persistenceContext)
        {
            this.PersistenceContext = persistenceContext;
            this.Interactor = new CreateRaffleEntryInteractor(this.PersistenceContext);
        }

        public async Task<IViewModel> ValidateAsync(CreateRaffleEntryInputPort inputPort, ICreateRaffleEntryOutputPort outputPort)
        {
            if (!this.FileServices.DoesFileExist())
                return await outputPort.PresentFileNotFoundAsync();
            if (this.PersistenceContext.Find<Raffle>(inputPort.RaffleId) == null)
                return await outputPort.PresentRaffleNotFoundAsync(inputPort.RaffleId);

            return await this.Interactor.HandleAsync(inputPort, outputPort);
        }
    }
}
