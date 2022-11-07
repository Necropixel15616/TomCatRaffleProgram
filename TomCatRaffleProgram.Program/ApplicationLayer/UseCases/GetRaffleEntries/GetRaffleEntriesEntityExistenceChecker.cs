using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.GetRaffleEntries
{
    class GetRaffleEntriesEntityExistenceChecker
    {

        private readonly FileServices FileServices = new FileServices();

        private readonly GetRaffleEntriesInteractor Interactor;
        private readonly IPersistenceContext PersistenceContext;

        public GetRaffleEntriesEntityExistenceChecker(IPersistenceContext persistenceContext)
        {
            this.PersistenceContext = persistenceContext;
            Interactor = new GetRaffleEntriesInteractor(FileServices, this.PersistenceContext);
        }

        public async Task<IViewModel> ValidateAsync(GetRaffleEntriesInputPort inputPort, IGetRaffleEntriesOutputPort outputPort)
        {
            if (!this.FileServices.DoesFileExist())
                return await outputPort.PresentFileNotFoundAsync();

            if (this.PersistenceContext.Find<Raffle>(inputPort.RaffleId) == null)
                return await outputPort.PresentRaffleNotFound(inputPort.RaffleId);

            return await this.Interactor.HandleAsync(inputPort, outputPort);
        }

    }
}
