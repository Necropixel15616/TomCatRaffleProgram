using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TomCatRaffleProgram.Program.ApplicationLayer.Dtos;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffleEntry
{
    class CreateRaffleEntryInteractor
    {
        private readonly IPersistenceContext PersistenceContext;

        public CreateRaffleEntryInteractor(IPersistenceContext persistenceContext)
            => this.PersistenceContext = persistenceContext;

        public async Task<IViewModel> HandleAsync(CreateRaffleEntryInputPort inputPort, ICreateRaffleEntryOutputPort outputPort)
        {

            var raffleEntry = this.PersistenceContext.GetEntities<RaffleEntry>().Where(re => re.Attribute("Full Name").Value == string.Concat(inputPort.FirstName, " ", inputPort.LastName)).SingleOrDefault();
            if (raffleEntry != null)
                raffleEntry.Element("Tickets").Value = (int.Parse(raffleEntry.Element("Tickets").Value) + inputPort.Tickets).ToString();
            else
            {
                raffleEntry = new XElement("RaffleEntry");
                raffleEntry.Add(new XAttribute("FirstName", inputPort.FirstName));
                raffleEntry.Add(new XAttribute("LastName", inputPort.LastName));
                raffleEntry.Add(new XAttribute("FullName", string.Concat(inputPort.FirstName, " ", inputPort.LastName)));
                raffleEntry.Add(new XElement("Tickets", inputPort.Tickets));
                var raffle = this.PersistenceContext.Find<Raffle>(inputPort.RaffleId);
                raffle.Add(raffleEntry);
            }

            this.PersistenceContext.Save();

            return await outputPort.PresentRaffleEntryAsync(new RaffleEntryDto(new RaffleEntry(inputPort.FirstName, inputPort.LastName, inputPort.Tickets)));
        }

    }
}
