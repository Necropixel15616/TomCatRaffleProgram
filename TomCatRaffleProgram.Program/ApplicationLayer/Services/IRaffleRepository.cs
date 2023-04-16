using System.Collections.Generic;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Services
{
    public interface IRaffleRepository
    {

        public TEntity Find<TEntity>(int raffleId, int? entryId = null);

        public List<Raffle> GetRaffles();

        public void AddRaffle(Raffle entity);

        public void RemoveRaffle(int id);

        public void Save();

    }
}
