using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.CreateRaffleEntry;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DeleteRaffleEntry;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.GetRaffleEntries;

namespace TomCatRaffleProgram.Program.InterfaceAdapters.Controllers
{
    class RaffleEntryController
    {
        private readonly IFileServices FileServices;
        private readonly IRaffleRepository PersistenceContext;

        public RaffleEntryController(IFileServices fileServices, IRaffleRepository persistenceContext)
        {
            FileServices = fileServices;
            PersistenceContext = persistenceContext;
        }

        public async Task CreateRaffleEntryAsync(CreateRaffleEntryInputPort inputPort, ICreateRaffleEntryOutputPort outputPort)
        {
            var _Pipeline = new UseCasePipeline<CreateRaffleEntryInputPort, ICreateRaffleEntryOutputPort>(
                                new CreateRaffleEntryInteractor(PersistenceContext),
                                _inputPortValidator: new CreateRaffleEntryInputPortValidator(),
                                _entityExistenceChecker: new CreateRaffleEntryEntityExistenceChecker(FileServices, PersistenceContext));

            await _Pipeline.InvokeUseCaseAsync(inputPort, outputPort);
        }

        public async Task GetRaffleEntriesAsync(GetRaffleEntriesInputPort inputPort, IGetRaffleEntriesOutputPort outputPort)
        {
            var _Pipeline = new UseCasePipeline<GetRaffleEntriesInputPort, IGetRaffleEntriesOutputPort>(
                                new GetRaffleEntriesInteractor(PersistenceContext),
                                _entityExistenceChecker: new GetRaffleEntriesEntityExistenceChecker(FileServices, PersistenceContext));

            await _Pipeline.InvokeUseCaseAsync(inputPort, outputPort);
        }

        public async Task DeleteRaffleEntryAsync(DeleteRaffleEntryInputPort inputPort, IDeleteRaffleEntryOutputPort outputPort)
        {
            var _Pipeline = new UseCasePipeline<DeleteRaffleEntryInputPort, IDeleteRaffleEntryOutputPort>(
                                new DeleteRaffleEntryInteractor(PersistenceContext),
                                _entityExistenceChecker: new DeleteRaffleEntryEntityExistenceChecker(PersistenceContext, FileServices));

            await _Pipeline.InvokeUseCaseAsync(inputPort, outputPort);
        }

    }
}
