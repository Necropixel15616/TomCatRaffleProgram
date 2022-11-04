using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle
{
    class CreateRaffleEntityExistenceChecker
    {

        public FileInfo FileInfo;
        public CreateRaffleInteractor Interactor = new CreateRaffleInteractor();

        public CreateRaffleEntityExistenceChecker()
            => this.FileInfo = new FileInfo(App.GetFilePath());

        public async Task ValidateAsync(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
        {
            if (!this.FileInfo.Exists)
                await outputPort.FileNotFound();

            var file = XDocument.Load(App.GetFilePath());
            if (file.Root.Elements().Where(r => r.Attribute("Name").Value.ToUpper().Equals(inputPort.RaffleName.ToUpper())).SingleOrDefault() != null)
                await outputPort.RaffleExists(inputPort.RaffleName);

            await this.Interactor.CreateRaffleAsync(inputPort, outputPort);
        }
    }
}
