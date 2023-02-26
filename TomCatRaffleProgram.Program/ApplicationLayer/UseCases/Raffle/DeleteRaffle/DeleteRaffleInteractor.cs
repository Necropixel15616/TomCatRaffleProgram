using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.DeleteRaffle
{
    class DeleteRaffleInteractor : IInteractor<DeleteRaffleInputPort, IDeleteRaffleOutputPort>
    {
        private readonly IRaffleRepository RaffleRepository;

        public DeleteRaffleInteractor(IRaffleRepository raffleRepository)
            => this.RaffleRepository = raffleRepository;

        Task IInteractor<DeleteRaffleInputPort, IDeleteRaffleOutputPort>.HandleAsync(DeleteRaffleInputPort inputPort, IDeleteRaffleOutputPort outputPort, CancellationToken cancellationToken)
        {
            RaffleRepository.RemoveRaffle(inputPort.RaffleId);
            RaffleRepository.Save();
            return outputPort.PresentRaffleDeletedAsync(cancellationToken);
        }
    }
}
