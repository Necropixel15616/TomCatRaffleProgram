using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle
{
    class CreateRaffleInteractor
    {

        public CreateRaffleInteractor() { }

        public async Task CreateRaffleAsync(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
        {
            var file = XDocument.Load(App.GetFilePath());

            List<XElement> raffles = file.Root.Descendants("Raffle").ToList();
            var id = 0;
            foreach (var r in raffles)
                if (int.Parse(r.Attribute("Id").Value) > id)
                    id = int.Parse(r.Attribute("Id").Value);
            id++;

            XElement raffle = new XElement("Raffle");
            raffle.Add(new XAttribute("Name", inputPort.RaffleName));
            raffle.Add(new XAttribute("Id", id));

            file.Root.Add(raffle);
            file.Save(App.GetFilePath());
            await outputPort.RaffleCreated(new RaffleDto(new Raffle(inputPort.RaffleName, id)));
        }

    }
}
