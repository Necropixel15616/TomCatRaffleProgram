using System.Threading.Tasks;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    public class UseCasePipeline<TInputPort, TOutputPort> where TInputPort : IInputPort<TOutputPort>
    {

        public UseCasePipeline(
            IInteractorPipe<TInputPort, TOutputPort> _interactor,
            IInputPortValidatorPipe<TInputPort, TOutputPort> _inputPortValidator = null,
            IEntityExistenceCheckerPipe<TInputPort, TOutputPort> _entityExistenceChecker = null,
            IBusinessRuleValidatorPipe<TInputPort, TOutputPort> _businessRuleValidator = null)
        {
            Interactor = _interactor;
            EntityExistenceChecker = _entityExistenceChecker;
            BusinessRuleValidator = _businessRuleValidator;
            InputPortValidator = _inputPortValidator;
        }

        IInputPortValidatorPipe<TInputPort, TOutputPort> InputPortValidator;

        IEntityExistenceCheckerPipe<TInputPort, TOutputPort> EntityExistenceChecker;

        IBusinessRuleValidatorPipe<TInputPort, TOutputPort> BusinessRuleValidator;

        IInteractorPipe<TInputPort, TOutputPort> Interactor;

        public async Task<TOutputPort> InvokeUseCaseAsync(
            TInputPort inputPort,
            TOutputPort outputPort)
        {
            if (InputPortValidator != null)
                InputPortValidator.ValidateAsync(inputPort, outputPort);

            if (EntityExistenceChecker != null)
                EntityExistenceChecker.ValidateEntityExist(inputPort, outputPort);

            if (BusinessRuleValidator != null)
                BusinessRuleValidator.ValidateAsync(inputPort, outputPort);

            await Interactor.HandleAsync(inputPort, outputPort);

            return outputPort;
        }

    }
}