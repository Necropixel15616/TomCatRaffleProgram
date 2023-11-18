using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.GetRaffles;

namespace TomCatRaffleProgram.Program.Framework.Presentation.Raffle.GetRaffles
{
    public class GetRafflesPresenter : BasePresenter<List<RaffleDto>>, IGetRafflesOutputPort
    {
        Task IGetRafflesOutputPort.PresentRafflesAsync(List<RaffleDto> raffleDtos, CancellationToken cancellationToken)
            => SetResultAsync(raffleDtos, cancellationToken);
    }
}
