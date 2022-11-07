using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Services
{
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
