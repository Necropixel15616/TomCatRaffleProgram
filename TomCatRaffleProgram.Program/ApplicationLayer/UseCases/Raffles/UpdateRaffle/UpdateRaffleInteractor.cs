using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.UpdateRaffle
{
    public class UpdateRaffleInteractor : IInteractor<UpdateRaffleInputPort, IUpdateRaffleOutputPort>
    {
        private readonly IRaffleRepository RaffleRepository;

        public UpdateRaffleInteractor(IRaffleRepository raffleRepository)
            => RaffleRepository = raffleRepository;

        Task IInteractor<UpdateRaffleInputPort, IUpdateRaffleOutputPort>.HandleAsync(
            UpdateRaffleInputPort inputPort,
            IUpdateRaffleOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            var raffle = RaffleRepository.Find<Raffle>(inputPort.RaffleId);
            raffle.Name = inputPort.Name;

            return outputPort.PresentRaffleUpdatedAsync(new RaffleDto(raffle), cancellationToken);
        }
    }
}
