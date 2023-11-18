using System.Threading;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.Framework.Presentation;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Services
{
    public interface IFileValidator<TOutputPort> where TOutputPort : IFileValidation
    {

        Task<bool> ValidateFileExistsAsync(TOutputPort outputPort, CancellationToken cancellationToken);

    }
}
