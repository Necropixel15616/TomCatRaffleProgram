using System;
using System.IO;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Services
{
    //Probably want to make this a Service
    class FileServices
    {

        private string FilePath = $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"TomCatRaffle\")}RaffleData.xml";
        private FileInfo File = new FileInfo($"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"TomCatRaffle\")}RaffleData.xml");

        public bool DoesFileExist()
            => this.File.Exists;

        public string GetFilePath()
            => this.FilePath;
    }
}
