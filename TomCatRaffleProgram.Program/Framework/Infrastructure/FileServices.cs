using System;
using System.IO;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Services
{
    //Probably want to make this a Service
    class FileServices : IFileServices
    {

        private string FilePath = $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"TomCatRaffle\")}RaffleData.xml";
        private FileInfo File = new FileInfo($"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"TomCatRaffle\")}RaffleData.xml");

        bool IFileServices.DoesFileExist()
            => this.File.Exists;

        string IFileServices.GetFilePath()
            => this.FilePath;
    }
}
