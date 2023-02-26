using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Infrastructure
{
    class FileValidator<TOutputPort> : IFileValidator<TOutputPort> where TOutputPort : IFileValidation
    {
        private readonly IFileServices FileServices;

        public FileValidator(IFileServices fileServices)
            => this.FileServices = fileServices;

        async Task<bool> IFileValidator<TOutputPort>.ValidateFileExistsAsync(TOutputPort outputPort, CancellationToken cancellationToken)
        {
            if (!FileServices.DoesFileExist())
            {
                await outputPort.PresentFileNotFoundAsync(cancellationToken);
                return false;
            }

            return true;
        }
    }
}
