using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DrawRaffleEntry
{
    public class DrawRaffleEntryInteractor : IInteractor<DrawRaffleEntryInputPort, IDrawRaffleEntryOutputPort>
    {
        private readonly IRaffleRepository RaffleRepository;

        public DrawRaffleEntryInteractor(IRaffleRepository raffleRepository)
            => RaffleRepository = raffleRepository;

        Task IInteractor<DrawRaffleEntryInputPort, IDrawRaffleEntryOutputPort>.HandleAsync(
            DrawRaffleEntryInputPort inputPort,
            IDrawRaffleEntryOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            var raffle = RaffleRepository.Find<Raffle>(inputPort.RaffleId);

            var raffleEntriesById = new List<int>();
            foreach (var entry in raffle.Entries)
            {
                for (int i = 0; i <= entry.Tickets; i++)
                    raffleEntriesById.Add(entry.Id);
            }

            var winningIndex = new Random().Next(0, raffleEntriesById.Count);

            return outputPort.PresentRaffleWinnerAsync(new RaffleEntryDto(raffle.Entries.Single(re => re.Id == raffleEntriesById[winningIndex])), cancellationToken);
        }
    }
}
