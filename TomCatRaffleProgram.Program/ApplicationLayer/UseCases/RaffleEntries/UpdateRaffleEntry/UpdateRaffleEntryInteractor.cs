using System;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.UpdateRaffleEntry
{
    public class UpdateRaffleEntryInteractor : IInteractor<UpdateRaffleEntryInputPort, IUpdateRaffleEntryOutputPort>
    {
        private readonly IRaffleRepository RaffleRepository;

        public UpdateRaffleEntryInteractor(IRaffleRepository raffleRepository)
            => RaffleRepository = raffleRepository ?? throw new ArgumentNullException(nameof(raffleRepository));

        Task IInteractor<UpdateRaffleEntryInputPort, IUpdateRaffleEntryOutputPort>.HandleAsync(
            UpdateRaffleEntryInputPort inputPort,
            IUpdateRaffleEntryOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            var raffleEntry = RaffleRepository.Find<RaffleEntry>(inputPort.RaffleId, inputPort.RaffleEntryId);
            raffleEntry.FirstName = inputPort.FirstName;
            raffleEntry.LastName = inputPort.LastName;
            raffleEntry.Tickets = inputPort.Tickets;

            return outputPort.PresentRaffleEntryUpdatedAsync(new RaffleEntryDto(raffleEntry), cancellationToken);
        }
    }
}
