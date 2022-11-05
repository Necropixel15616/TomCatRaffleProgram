using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.GetRaffleEntries
{
    class GetRaffleEntriesInteractor
    {
        private readonly FileServices FileServices;

        public GetRaffleEntriesInteractor(FileServices fileServices)
            => this.FileServices = fileServices ?? new FileServices();

        public async Task<IViewModel> HandleAsync(GetRaffleEntriesInputPort inputPort, IGetRaffleEntriesOutputPort outputPort)
        {
            var file = XDocument.Load(this.FileServices.GetFilePath());
            var raffle = file.Root.Elements("Raffle").Where(r => int.Parse(r.Attribute("Id").Value) == inputPort.RaffleId).Single();
            List<Entry> entries = new List<Entry>();
            raffle.Descendants("RaffleEntry").ToList().ForEach(re
                => entries.Add(new Entry(
                    re.Attribute("FirstName").Value,
                    re.Attribute("LastName").Value,
                    int.Parse(re.Element("Tickets").Value))));

            return await outputPort.PresentRaffleEntriesAsync(new List<EntryDto>(entries.Select(re => new EntryDto(re))));
        }

    }
}
