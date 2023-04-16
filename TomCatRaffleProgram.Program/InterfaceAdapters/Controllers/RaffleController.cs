using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.CreateRaffle;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.DeleteRaffle;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.GetRaffles;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.UpdateRaffle;

namespace TomCatRaffleProgram.Program.InterfaceAdapters.Controllers
{
    class RaffleController
    {
        public RaffleController()
        { }

        public async Task CreateRaffleAsync(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort, CancellationToken cancellationToken)
            => await new UseCasePipeline<CreateRaffleInputPort, ICreateRaffleOutputPort>().InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

        public async Task GetRafflesAsync(GetRafflesInputPort inputPort, IGetRafflesOutputPort outputPort, CancellationToken cancellationToken)
            => await new UseCasePipeline<GetRafflesInputPort, IGetRafflesOutputPort>().InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

        public async Task DeleteRaffleAsync(DeleteRaffleInputPort inputPort, IDeleteRaffleOutputPort outputPort, CancellationToken cancellationToken)
            => await new UseCasePipeline<DeleteRaffleInputPort, IDeleteRaffleOutputPort>().InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

        public async Task UpdateRaffleAsync(UpdateRaffleInputPort inputPort, IUpdateRaffleOutputPort outputPort, CancellationToken cancellationToken)
            => await new UseCasePipeline<UpdateRaffleInputPort, IUpdateRaffleOutputPort>().InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);
    }
}
