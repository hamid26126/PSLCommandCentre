using System.Collections.Generic;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Repositories;

namespace PSLCommandCentre.Services
{
    public class PlayerService
    {
        private readonly PlayerRepository _repo = new PlayerRepository();

        public List<Player> GetAllPlayers() => _repo.GetAll();
        public List<Player> SearchPlayers(string kw) => _repo.Search(kw);

        public bool AddPlayer(Player p)
        {
            var val = Validator.ValidatePlayer(p);
            if (!val.IsValid) throw new System.Exception(val.Message);
            return _repo.Add(p);
        }

        public bool UpdatePlayer(Player p)
        {
            var val = Validator.ValidatePlayer(p);
            if (!val.IsValid) throw new System.Exception(val.Message);
            return _repo.Update(p);
        }

        public bool DeletePlayer(int id) => _repo.Delete(id);
    }
}