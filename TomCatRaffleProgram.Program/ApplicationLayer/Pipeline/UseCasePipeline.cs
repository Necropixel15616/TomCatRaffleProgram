using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    class UseCasePipeline<TInputPort, TOutputPort> where TInputPort : IInputPort<TOutputPort> where TOutputPort : IFileValidation
    {

        private readonly IBusinessRuleValidator<TInputPort, TOutputPort> BusinessRuleValidator;
        private readonly IEntityExistenceChecker<TInputPort, TOutputPort> EntityExistenceChecker;
        private readonly IFileValidator<TOutputPort> FileValidation;
        private readonly IInputPortValidator<TInputPort, TOutputPort> InputPortValidator;
        private readonly IInteractor<TInputPort, TOutputPort> Interactor;

        public UseCasePipeline()
        {
            var serviceProvider = App.GetServiceProvider();
            BusinessRuleValidator = (IBusinessRuleValidator<TInputPort, TOutputPort>)serviceProvider.GetService(typeof(IBusinessRuleValidator<TInputPort, TOutputPort>));
            EntityExistenceChecker = (IEntityExistenceChecker<TInputPort, TOutputPort>)serviceProvider.GetService(typeof(IEntityExistenceChecker<TInputPort, TOutputPort>));
            FileValidation = (IFileValidator<TOutputPort>)serviceProvider.GetService(typeof(IFileValidator<TOutputPort>));
            InputPortValidator = (IInputPortValidator<TInputPort, TOutputPort>)serviceProvider.GetService(typeof(IInputPortValidator<TInputPort, TOutputPort>));
            Interactor = (IInteractor<TInputPort, TOutputPort>)serviceProvider.GetService(typeof(IInteractor<TInputPort, TOutputPort>));
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