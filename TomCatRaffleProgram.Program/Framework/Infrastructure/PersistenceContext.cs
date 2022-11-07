using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TomCatRaffleProgram.Program.ApplicationLayer.Services;

namespace TomCatRaffleProgram.Program.Framework.Infrastructure
{
    public class PersistenceContext : IPersistenceContext
    {
        //private readonly FileServices FileServices = new FileServices()

        private readonly XDocument File = XDocument.Load(App.GetFilePath());

        void IPersistenceContext.Add(object entity)
            => this.File.Root.Add(entity);

        XElement IPersistenceContext.Find<TEntity>(int id)
            => this.File.Root.Elements(typeof(TEntity).Name).Where(e => int.Parse(e.Attribute("Id").Value) == id).SingleOrDefault();

        List<XElement> IPersistenceContext.GetEntities<TEntity>()
            => this.File.Root.Elements(typeof(TEntity).Name).ToList();

        void IPersistenceContext.Remove<TEntity>(int id)
        {
            var entity = this.File.Root.Elements(typeof(TEntity).Name).Where(e => int.Parse(e.Attribute("Id").Value) == id).Single();
            entity.Remove();
        }

        void IPersistenceContext.Save()
            => this.File.Save(App.GetFilePath());
    }
}
