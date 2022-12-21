using System.Collections.Generic;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Services
{
    public interface IPersistenceContext
    {

        public TEntity Find<TEntity>(int id);

        public List<TEntity> GetEntities<TEntity>();

        public void Add(object entity);

        public void Remove<TEntity>(int id);

        public void Save();

    }
}
