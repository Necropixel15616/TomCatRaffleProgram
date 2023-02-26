using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TomCatRaffleProgram.Program.Framework.Presentation
{
    class BasePresenter<TEntity> : IFileValidation
    {
        public List<string> Errors { get; private set; }

        public Task<TEntity> Result { get; private set; }

        protected Task SetErrors(List<string> errors, CancellationToken cancellationToken)
        {
            Errors = errors;
            return Task.CompletedTask;
        }

        protected Task SetResult(TEntity result, CancellationToken cancellationToken)
            => Result = Task.FromResult(result);

        Task IFileValidation.PresentFileNotFound(CancellationToken cancellationToken)
            => SetErrors(new List<string>() { "The File was not found." }, cancellationToken);
    }
}
