using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Domain.Entities;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffleEntry
{
    class CreateRaffleEntryInteractor
    {

        public CreateRaffleEntryInteractor() { }

        public async Task<IViewModel> HandleAsync(CreateRaffleEntryInputPort inputPort, ICreateRaffleEntryOutputPort outputPort)
        {
            var file = XDocument.Load(App.GetFilePath());
            var raffle = file.Root.Descendants("Raffle").Where(r => int.Parse(r.Attribute("Id").Value) == inputPort.RaffleId).Single();

            var raffleEntry = raffle.Elements("RaffleEntry").Where(re => re.Attribute("FullName").Value.ToUpper().Equals(string.Concat(inputPort.FirstName, " ", inputPort.LastName).ToUpper())).SingleOrDefault();
            if (raffleEntry != null)
                raffleEntry.Element("Tickets").Value = (int.Parse(raffleEntry.Element("Tickets").Value) + inputPort.Tickets).ToString();
            else
            {
                raffleEntry = new XElement("RaffleEntry");
                raffleEntry.Add(new XAttribute("FirstName", inputPort.FirstName));
                raffleEntry.Add(new XAttribute("LastName", inputPort.LastName));
                raffleEntry.Add(new XAttribute("FullName", string.Concat(inputPort.FirstName, " ", inputPort.LastName)));
                raffleEntry.Add(new XElement("Tickets", inputPort.Tickets));
                raffle.Add(raffleEntry);
            }

            file.Save(App.GetFilePath());

            return await outputPort.PresentRaffleEntryAsync(new EntryDto(new Entry(inputPort.FirstName, inputPort.LastName, inputPort.Tickets)));
        }

    }
}
