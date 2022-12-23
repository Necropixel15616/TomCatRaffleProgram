using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.GetRaffles
{
    interface IGetRafflesOutputPort
    {

        Task PresentRaffles(List<RaffleDto> raffleDtos);

    }
}
