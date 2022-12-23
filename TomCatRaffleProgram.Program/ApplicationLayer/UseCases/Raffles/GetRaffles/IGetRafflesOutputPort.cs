using System.Collections.Generic;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.GetRaffles
{
    interface IGetRafflesOutputPort : IFileValidation
    {

        Task PresentRaffles(List<RaffleDto> raffleDtos);

    }
}
