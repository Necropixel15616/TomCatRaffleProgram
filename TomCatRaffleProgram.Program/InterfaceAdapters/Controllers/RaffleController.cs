using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle;

namespace TomCatRaffleProgram.Program.InterfaceAdapters.Controllers
{
    class RaffleController
    {
        private readonly IFileServices FileServices;
        private readonly IRaffleRepository PersistenceContext;

        public RaffleController(IFileServices fileServices, IRaffleRepository persistenceContext)
        {
            FileServices = fileServices;
            PersistenceContext = persistenceContext;
        }

        public async Task CreateRaffleAsync(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
        {
            var _Pipeline = new UseCasePipeline<CreateRaffleInputPort, ICreateRaffleOutputPort>(
                                new CreateRaffleInteractor(PersistenceContext),
                                _inputPortValidator: new CreateRaffleInputPortValidator(),
                                _entityExistenceChecker: new CreateRaffleEntityExistenceChecker(FileServices, PersistenceContext));

            await _Pipeline.InvokeUseCaseAsync(inputPort, outputPort);
        }
    }
}
