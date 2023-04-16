using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.CreateRaffleEntry;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DeleteRaffleEntry;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DrawRaffleEntry;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.GetRaffleEntries;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.UpdateRaffleEntry;

namespace TomCatRaffleProgram.Program.InterfaceAdapters.Controllers
{
    class RaffleEntryController
    {
        public RaffleEntryController()
        { }

        public async Task CreateRaffleEntryAsync(CreateRaffleEntryInputPort inputPort, ICreateRaffleEntryOutputPort outputPort, CancellationToken cancellationToken)
            => await new UseCasePipeline<CreateRaffleEntryInputPort, ICreateRaffleEntryOutputPort>().InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

        public async Task GetRaffleEntriesAsync(GetRaffleEntriesInputPort inputPort, IGetRaffleEntriesOutputPort outputPort, CancellationToken cancellationToken)
            => await new UseCasePipeline<GetRaffleEntriesInputPort, IGetRaffleEntriesOutputPort>().InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

        public async Task DeleteRaffleEntryAsync(DeleteRaffleEntryInputPort inputPort, IDeleteRaffleEntryOutputPort outputPort, CancellationToken cancellationToken)
            => await new UseCasePipeline<DeleteRaffleEntryInputPort, IDeleteRaffleEntryOutputPort>().InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

        public async Task UpdateRaffleEntryAsync(UpdateRaffleEntryInputPort inputPort, IUpdateRaffleEntryOutputPort outputPort, CancellationToken cancellationToken)
            => await new UseCasePipeline<UpdateRaffleEntryInputPort, IUpdateRaffleEntryOutputPort>().InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

        public async Task DrawRaffleEntryAsync(DrawRaffleEntryInputPort inputPort, IDrawRaffleEntryOutputPort outputPort, CancellationToken cancellationToken)
            => await new UseCasePipeline<DrawRaffleEntryInputPort, IDrawRaffleEntryOutputPort>().InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

    }
}
