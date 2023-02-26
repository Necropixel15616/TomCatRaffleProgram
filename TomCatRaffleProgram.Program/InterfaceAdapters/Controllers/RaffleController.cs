using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.CreateRaffle;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.DeleteRaffle;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.GetRaffles;

namespace TomCatRaffleProgram.Program.InterfaceAdapters.Controllers
{
    class RaffleController
    {
        private readonly IFileServices FileServices;
        private readonly IRaffleRepository RaffleRepository;

        public RaffleController(IFileServices fileServices, IRaffleRepository raffleRepository)
        {
            FileServices = fileServices;
            RaffleRepository = raffleRepository;
        }

        public async Task CreateRaffleAsync(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort, CancellationToken cancellationToken)
        {
            var _Pipeline = new UseCasePipeline<CreateRaffleInputPort, ICreateRaffleOutputPort>(
                                new CreateRaffleInteractor(RaffleRepository),
                                _inputPortValidator: new CreateRaffleInputPortValidator(),
                                _entityExistenceChecker: new CreateRaffleEntityExistenceChecker(FileServices, RaffleRepository));

            await _Pipeline.InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);
        }

        public async Task GetRafflesAsync(GetRafflesInputPort inputPort, IGetRafflesOutputPort outputPort, CancellationToken cancellationToken)
        {
            var _Pipeline = new UseCasePipeline<GetRafflesInputPort, IGetRafflesOutputPort>(
                                new GetRafflesInteractor(RaffleRepository));

            await _Pipeline.InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);
        }

        public async Task DeleteRaffleAsync(DeleteRaffleInputPort inputPort, IDeleteRaffleOutputPort outputPort, CancellationToken cancellationToken)
        {
            var _Pipeline = new UseCasePipeline<DeleteRaffleInputPort, IDeleteRaffleOutputPort>(
                    new DeleteRaffleInteractor(RaffleRepository),
                    _entityExistenceChecker: new DeleteRaffleEntityExistenceChecker(FileServices, RaffleRepository));

            await _Pipeline.InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);
        }
    }
}
