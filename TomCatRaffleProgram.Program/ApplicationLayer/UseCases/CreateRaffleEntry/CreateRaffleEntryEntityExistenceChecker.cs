using System;
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
        private readonly FileServices FileServices = new FileServices();

        private readonly CreateRaffleEntryInteractor Interactor;

        public CreateRaffleEntryEntityExistenceChecker()
            => this.Interactor = new CreateRaffleEntryInteractor(this.FileServices);
        public async Task<IViewModel> ValidateAsync(CreateRaffleEntryInputPort inputPort, ICreateRaffleEntryOutputPort outputPort)
        {
            if (!this.FileServices.DoesFileExist())
                return await outputPort.PresentFileNotFoundAsync();
            var file = XDocument.Load(this.FileServices.GetFilePath());
            if (file.Root.Elements("Raffle").Where(r => int.Parse(r.Attribute("Id").Value) == inputPort.RaffleId).SingleOrDefault() == null)
                return await outputPort.PresentRaffleNotFoundAsync(inputPort.RaffleId);

            return await this.Interactor.HandleAsync(inputPort, outputPort);
        }
    }
}
