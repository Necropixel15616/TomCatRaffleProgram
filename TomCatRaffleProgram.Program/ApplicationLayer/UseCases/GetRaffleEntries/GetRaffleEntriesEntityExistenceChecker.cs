using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.GetRaffleEntries
{
    class GetRaffleEntriesEntityExistenceChecker
    {

        private readonly FileServices FileServices = new FileServices();

        private readonly GetRaffleEntriesInteractor Interactor;

        public GetRaffleEntriesEntityExistenceChecker()
            => this.Interactor = new GetRaffleEntriesInteractor(this.FileServices);

        public async Task<IViewModel> ValidateAsync(GetRaffleEntriesInputPort inputPort, IGetRaffleEntriesOutputPort outputPort)
        {
            if (!this.FileServices.DoesFileExist())
                return await outputPort.PresentFileNotFoundAsync();

            var file = XDocument.Load(this.FileServices.GetFilePath());
            if (file.Root.Descendants("Raffle").Where(r => int.Parse(r.Attribute("Id").Value) == inputPort.RaffleId).SingleOrDefault() == null)
                return await outputPort.PresentRaffleNotFound(inputPort.RaffleId);

            return await this.Interactor.HandleAsync(inputPort, outputPort);
        }

    }
}
