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

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle
{
    class CreateRaffleInteractor
    {

        public readonly IPersistenceContext PersistenceContext;

        public CreateRaffleInteractor(IPersistenceContext persistenceContext)
            => PersistenceContext = persistenceContext;

        public async Task<IViewModel> CreateRaffleAsync(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
        {
            List<XElement> raffles = this.PersistenceContext.GetEntities<Raffle>();
            var id = 0;
            foreach (var r in raffles)
                if (int.Parse(r.Attribute("Id").Value) > id)
                    id = int.Parse(r.Attribute("Id").Value);
            id++;

            XElement raffle = new XElement(typeof(Raffle).Name);
            raffle.Add(new XAttribute("Name", inputPort.RaffleName));
            raffle.Add(new XAttribute("Id", id));
            raffle.Add(new XAttribute("Open", true));

            this.PersistenceContext.Add(raffle);
            this.PersistenceContext.Save();
            return await outputPort.PresentRaffleCreatedAsync(new RaffleDto(new Raffle(inputPort.RaffleName, id)));
        }

    }
}
