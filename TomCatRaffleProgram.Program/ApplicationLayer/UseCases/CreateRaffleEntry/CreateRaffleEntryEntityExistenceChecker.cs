﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffleEntry
{
    class CreateRaffleEntryEntityExistenceChecker
    {
        private FileServices FileServices = new FileServices();

        public CreateRaffleEntryInteractor Interactor;
        private readonly IPersistenceContext PersistenceContext;

        public CreateRaffleEntryEntityExistenceChecker(IPersistenceContext persistenceContext)
        {
            this.PersistenceContext = persistenceContext;
            this.Interactor = new CreateRaffleEntryInteractor(this.PersistenceContext);
        }

        public async Task<IViewModel> ValidateAsync(CreateRaffleEntryInputPort inputPort, ICreateRaffleEntryOutputPort outputPort)
        {
            if (!this.FileServices.DoesFileExist())
                return await outputPort.PresentFileNotFoundAsync();
            if (file.Root.Elements("Raffle").Where(r => int.Parse(r.Attribute("Id").Value) == inputPort.RaffleId).SingleOrDefault() == null)
                return await outputPort.PresentRaffleNotFoundAsync(inputPort.RaffleId);

            return await this.Interactor.HandleAsync(inputPort, outputPort);
        }
    }
}
