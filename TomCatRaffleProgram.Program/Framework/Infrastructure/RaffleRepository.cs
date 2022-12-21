using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.Framework.Infrastructure
{
    public class RaffleRepository : IRaffleRepository
    {
        private static readonly XmlSerializer XmlSerializer = new XmlSerializer(typeof(List<Raffle>), new XmlRootAttribute("Raffles"));

        private static List<Raffle> Entities;

        private readonly FileServices FileServices = new FileServices();

        public RaffleRepository() { }

        void IRaffleRepository.AddRaffle(Raffle entity)
            => Entities.Add(entity);

        object IRaffleRepository.Find(int raffleId, int? entryId = null)
        {
            if (entryId.HasValue)
                return Entities.Where(e => e.Id == raffleId).SelectMany(e => e.Entries).SingleOrDefault(e => e.Id == entryId);
            else
                return Entities.SingleOrDefault(e => e.Id == raffleId);
        }

        List<Raffle> IRaffleRepository.GetRaffles()
            => Entities;

        void IRaffleRepository.RemoveRaffle(int id)
            => Entities.Remove(Entities.SingleOrDefault(e => e.Id == id));

        void IRaffleRepository.Save()
        {
            using var sw = new StreamWriter(FileServices.GetFilePath());
            XmlSerializer.Serialize(sw, Entities);
        }

        public void LoadFile()
        {
            if (FileServices.DoesFileExist())
            {
                using var sr = new StreamReader(FileServices.GetFilePath());
                Entities = (List<Raffle>)XmlSerializer.Deserialize(sr);
                sr.Close();
            }
            else
            {
                CreateFileOnStartup();
                Entities = new List<Raffle>();
            }
        }

        private void CreateFileOnStartup()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filePath = Path.Combine(folder, @"TomCatRaffle\");
            Directory.CreateDirectory(filePath);

            FileInfo file = new FileInfo($"{filePath}RaffleData.xml");
            if (!file.Exists)
            {
                using (var sw = file.CreateText())
                {
                    sw.WriteLine("<Raffles></Raffles>");
                    sw.Close();
                }
            }
        }
    }
}
