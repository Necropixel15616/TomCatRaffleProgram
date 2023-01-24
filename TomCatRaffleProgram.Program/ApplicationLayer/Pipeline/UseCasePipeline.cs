﻿using System.Threading.Tasks;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    public class UseCasePipeline<TInputPort, TOutputPort> where TInputPort : IInputPort<TOutputPort>
    {

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
        }

        IInputPortValidator<TInputPort, TOutputPort> InputPortValidator;

        IEntityExistenceChecker<TInputPort, TOutputPort> EntityExistenceChecker;

        IBusinessRuleValidator<TInputPort, TOutputPort> BusinessRuleValidator;

        IInteractor<TInputPort, TOutputPort> Interactor;

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