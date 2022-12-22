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
                if (!InputPortValidator.ValidateAsync(inputPort, outputPort))
                    return outputPort;

            if (EntityExistenceChecker != null)
                if (!EntityExistenceChecker.ValidateEntityExist(inputPort, outputPort))
                    return outputPort;

            if (BusinessRuleValidator != null)
                if (!BusinessRuleValidator.ValidateAsync(inputPort, outputPort))
                    return outputPort;

            await Interactor.HandleAsync(inputPort, outputPort);
            return outputPort;
        }

    }
}