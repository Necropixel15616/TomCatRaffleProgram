using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Infrastructure;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    class UseCasePipeline<TInputPort, TOutputPort> where TInputPort : IInputPort<TOutputPort> where TOutputPort : IFileValidation
    {

        IInputPortValidator<TInputPort, TOutputPort> InputPortValidator;

        IEntityExistenceChecker<TInputPort, TOutputPort> EntityExistenceChecker;

        IBusinessRuleValidator<TInputPort, TOutputPort> BusinessRuleValidator;

        IInteractor<TInputPort, TOutputPort> Interactor;

        IFileValidator<TOutputPort> FileValidation;

        public UseCasePipeline(
            IInteractor<TInputPort, TOutputPort> _interactor,
            IInputPortValidator<TInputPort, TOutputPort> _inputPortValidator = null,
            IEntityExistenceChecker<TInputPort, TOutputPort> _entityExistenceChecker = null,
            IBusinessRuleValidator<TInputPort, TOutputPort> _businessRuleValidator = null)
        {
            Interactor = _interactor;
            EntityExistenceChecker = _entityExistenceChecker;
            BusinessRuleValidator = _businessRuleValidator;
            InputPortValidator = _inputPortValidator;
            FileValidation = new FileValidator<TOutputPort>(new FileServices());
        }

        public async Task<TOutputPort> InvokeUseCaseAsync(
            TInputPort inputPort,
            TOutputPort outputPort,
            CancellationToken cancellationToken)
        {
            if (InputPortValidator != null)
                if (!await InputPortValidator.ValidateAsync(inputPort, outputPort, cancellationToken))
                    return outputPort;

            if (!await FileValidation.ValidateFileExistsAsync(outputPort, cancellationToken))
                return outputPort;

            if (EntityExistenceChecker != null)
                if (!await EntityExistenceChecker.ValidateEntityExistAsync(inputPort, outputPort, cancellationToken))
                    return outputPort;

            if (BusinessRuleValidator != null)
                if (!await BusinessRuleValidator.ValidateAsync(inputPort, outputPort, cancellationToken))
                    return outputPort;

            await Interactor.HandleAsync(inputPort, outputPort, cancellationToken);
            return outputPort;
        }

    }
}