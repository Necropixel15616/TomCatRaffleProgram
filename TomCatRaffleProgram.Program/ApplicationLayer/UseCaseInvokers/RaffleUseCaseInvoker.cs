using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCaseInvokers
{
    class RaffleUseCaseInvoker
    {
        private readonly IRaffleRepository PersistenceContext;
        private CreateRaffleInputPortValidator BusinessRuleValidator;

        public RaffleUseCaseInvoker(IRaffleRepository persistenceContext)
        {
            this.PersistenceContext = persistenceContext;
            this.BusinessRuleValidator = new CreateRaffleInputPortValidator(this.PersistenceContext);
        }

        public async Task<IViewModel> InvokeCreateRaffle(CreateRaffleInputPort inputPort, ICreateRaffleOutputPort outputPort)
            => null;
    }
}
