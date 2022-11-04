using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle;
using TomCatRaffleProgram.Program.Framework.Presentation.CreateRaffle;

namespace TomCatRaffleProgram.Program
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string FilePath = $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"TomCatRaffle\")}RaffleData.xml";

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            this.CreateFileOnStartup();
            this.Test().Wait();
            Window mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void CreateFileOnStartup()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filePath = Path.Combine(folder, @"TomCatRaffle\");
            Directory.CreateDirectory(filePath);

            FileInfo file = new FileInfo($"{filePath}RaffleData.xml");
            if (!file.Exists)
            {
                using(var sw = file.CreateText())
                {
                    sw.WriteLine("<Raffles></Raffles>");
                    sw.Close();
                }
            }
        }

        public static string GetFilePath()
            => FilePath;
        
        private async Task Test()
        {
            var function = new CreateRaffleEntityExistenceChecker();
            var presenter = new CreateRafflePresenter();
            await function.ValidateAsync(new CreateRaffleInputPort { RaffleName = "Test" }, presenter);
        }
    }
}
