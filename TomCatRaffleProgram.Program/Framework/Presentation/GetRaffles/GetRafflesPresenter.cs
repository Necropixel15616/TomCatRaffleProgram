using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.GetRaffles;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;

namespace TomCatRaffleProgram.Program.Framework.Presentation.GetRaffles
{
    class GetRafflesPresenter : BasePresenter<List<RaffleViewModel>>, IGetRafflesOutputPort
    {
        Task IGetRafflesOutputPort.PresentRaffles(List<RaffleDto> raffleDtos)
        {
            var viewModels = new List<RaffleViewModel>();
            raffleDtos.ForEach(r => viewModels.Add(new RaffleViewModel(r)));
            return SetResult(viewModels);
        }
    }
}
