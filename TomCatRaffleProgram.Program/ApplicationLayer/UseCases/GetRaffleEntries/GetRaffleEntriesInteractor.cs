using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.GetRaffleEntries
{
    class GetRaffleEntriesInteractor
    {
        private readonly FileServices FileServices;
        private readonly IRaffleRepository PersistenceContext;

        public GetRaffleEntriesInteractor(FileServices fileServices, IRaffleRepository persistenceContext)
        {
            FileServices = fileServices ?? new FileServices();
            this.PersistenceContext = persistenceContext;
        }

        public async Task<IViewModel> HandleAsync(GetRaffleEntriesInputPort inputPort, IGetRaffleEntriesOutputPort outputPort)
        {
            var raffle = this.PersistenceContext.Find(inputPort.RaffleId);
            List<RaffleEntry> entries = new List<RaffleEntry>();
            //raffle.Descendants(typeof(RaffleEntry).Name).ToList().ForEach(re
            //    => entries.Add(new RaffleEntry(
            //        re.Attribute("FirstName").Value,
            //        re.Attribute("LastName").Value,
            //        int.Parse(re.Element("Tickets").Value))));

            return await outputPort.PresentRaffleEntriesAsync(new List<RaffleEntryDto>(entries.Select(re => new RaffleEntryDto(re))));
        }

    }
}
