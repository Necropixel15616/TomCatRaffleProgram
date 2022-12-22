namespace TomCatRaffleProgram.Program.ApplicationLayer.Services
{
    public interface IFileServices
    {

        public bool DoesFileExist();

        public string GetFilePath();

    }
}
