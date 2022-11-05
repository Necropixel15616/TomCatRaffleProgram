using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle
{
    class CreateRaffleEntityExistenceChecker
    {

        private readonly FileServices FileServices = new FileServices();

        private readonly CreateRaffleInteractor Interactor;

        public CreateRaffleEntityExistenceChecker()
            => this.Interactor = new CreateRaffleInteractor(this.FileServices);

        public async Task<IViewModel> ValidateAsync(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
        {
            if (!this.FileServices.DoesFileExist())
                await outputPort.PresentFileNotFoundAsync();

            var file = XDocument.Load(this.FileServices.GetFilePath());
            if (file.Root.Descendants("Raffle").Where(r => r.Attribute("Name").Value.ToUpper().Equals(inputPort.RaffleName.ToUpper())).SingleOrDefault() != null)
                return await outputPort.PresentRaffleExistsAsync(inputPort.RaffleName);

            return await this.Interactor.CreateRaffleAsync(inputPort, outputPort);
        }
    }
}
