namespace TomCatRaffleProgram.Program.ApplicationLayer.Services
{
    interface IFileServices
    {

        public bool DoesFileExist();

        public string GetFilePath();

    }
}
