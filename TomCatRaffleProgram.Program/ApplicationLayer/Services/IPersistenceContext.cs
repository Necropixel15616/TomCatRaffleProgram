using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Services
{
    public interface IPersistenceContext
    {

        public XElement Find<TEntity>(int id);

        public List<XElement> GetEntities<TEntity>();

        public void Add(object entity);

        public void Remove<TEntity>(int id);

        public void Save();

    }
}
