using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TomCatRaffleProgram.Program.Framework.Presentation
{
    public class BasePresenter<TEntity> : IFileValidation
    {
        public List<string> Errors { get; private set; }

        public TEntity Result { get; private set; }

        protected Task SetErrorsAsync(List<string> errors, CancellationToken cancellationToken)
        {
            Errors = errors;
            return Task.CompletedTask;
        }

        protected Task SetResultAsync(TEntity result, CancellationToken cancellationToken)
        {
            Result = result;
            return Task.CompletedTask;
        }

        Task IFileValidation.PresentFileNotFoundAsync(CancellationToken cancellationToken)
            => SetErrorsAsync(new List<string>() { "The File was not found." }, cancellationToken);
    }
}
