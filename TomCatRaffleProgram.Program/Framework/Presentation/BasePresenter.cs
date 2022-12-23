using System.Collections.Generic;
using System.Threading.Tasks;

namespace TomCatRaffleProgram.Program.Framework.Presentation
{
    class BasePresenter<TEntity> : IFileValidation
    {
        public List<string> Errors { get; private set; }

        public Task<TEntity> Result { get; set; }

        protected Task SetErrors(List<string> errors)
        {
            Errors = errors;
            return Task.CompletedTask;
        }

        protected Task SetResult(TEntity result)
            => Result = Task.FromResult(result);

        Task IFileValidation.PresentFileNotFound()
            => SetErrors(new List<string>() { "The File was not found." });
    }
}
