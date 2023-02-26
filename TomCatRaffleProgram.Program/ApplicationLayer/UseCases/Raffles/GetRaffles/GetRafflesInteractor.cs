using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.GetRaffles
{
    class GetRafflesInteractor : IInteractor<GetRafflesInputPort, IGetRafflesOutputPort>
    {
        private readonly IRaffleRepository RaffleRepository;

        public GetRafflesInteractor(IRaffleRepository raffleRepository)
            => RaffleRepository = raffleRepository;

        Task IInteractor<GetRafflesInputPort, IGetRafflesOutputPort>.HandleAsync(
            GetRafflesInputPort inputPort,
            IGetRafflesOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            var raffles = RaffleRepository.GetRaffles();
            var raffleDtos = new List<RaffleDto>();
            raffles.ForEach(r => raffleDtos.Add(new RaffleDto(r)));
            return outputPort.PresentRaffles(raffleDtos, cancellationToken);
        }
    }
}
