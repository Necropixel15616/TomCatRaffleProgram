using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.Framework.Infrastructure
{
    public class PersistenceContext : IPersistenceContext
    {
        private static readonly XmlSerializer XmlSerializer = new XmlSerializer(typeof(List<Raffle>), new XmlRootAttribute("Raffles"));

        private static List<Raffle> Entities;

        private readonly FileServices FileServices = new FileServices();
        public PersistenceContext()
        {

        }

        void IPersistenceContext.Add(object entity) { }

        TEntity IPersistenceContext.Find<TEntity>(int id)
            => default;

        List<TEntity> IPersistenceContext.GetEntities<TEntity>()
            => null;

        void IPersistenceContext.Remove<TEntity>(int id)
        {
            var entity = Entities.SingleOrDefault(e => e.Id == id);
            Entities.Remove(entity);
        }

        void IPersistenceContext.Save()
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
