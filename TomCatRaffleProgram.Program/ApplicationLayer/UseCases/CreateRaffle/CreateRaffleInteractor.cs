﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle
{
    class CreateRaffleInteractor
    {

        private readonly FileServices FileServices;

        public CreateRaffleInteractor(FileServices fileServices)
            => this.FileServices = fileServices ?? new FileServices();

        public async Task<IViewModel> CreateRaffleAsync(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
        {
            var file = XDocument.Load(this.FileServices.GetFilePath());

            List<XElement> raffles = file.Root.Descendants("Raffle").ToList();
            var id = 0;
            foreach (var r in raffles)
                if (int.Parse(r.Attribute("Id").Value) > id)
                    id = int.Parse(r.Attribute("Id").Value);
            id++;

            XElement raffle = new XElement("Raffle");
            raffle.Add(new XAttribute("Name", inputPort.RaffleName));
            raffle.Add(new XAttribute("Id", id));
            raffle.Add(new XAttribute("Open", true));

            file.Root.Add(raffle);
            file.Save(this.FileServices.GetFilePath());
            return await outputPort.PresentRaffleCreatedAsync(new RaffleDto(new Raffle(inputPort.RaffleName, id)));
        }

    }
}
