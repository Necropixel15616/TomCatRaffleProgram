using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.DeleteRaffle;

namespace TomCatRaffleProgram.Program.Framework.Presentation.Raffle.DeleteRaffle
{
    public class DeleteRafflePresenter : BasePresenter<RaffleDto>, IDeleteRaffleOutputPort
    {

        private readonly IRaffleRepository m_RaffleRepository;

        public DeleteRafflePresenter(IRaffleRepository raffleRepository)
            => m_RaffleRepository = raffleRepository ?? throw new ArgumentNullException(nameof(raffleRepository));

        Task IDeleteRaffleOutputPort.PresentRaffleDeletedAsync(CancellationToken cancellationToken)
        {
            this.m_RaffleRepository.Save();
            return SetResultAsync(null, cancellationToken);
        }

        Task IDeleteRaffleOutputPort.PresentRaffleNotFoundAsync(int raffleId, CancellationToken cancellationToken)
            => SetErrorsAsync(new List<string> { $"A Raffle with the Id {raffleId} could not be found," }, cancellationToken);
    }
}
