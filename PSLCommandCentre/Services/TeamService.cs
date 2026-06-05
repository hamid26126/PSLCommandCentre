using System.Collections.Generic;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Repositories;

namespace PSLCommandCentre.Services
{
    public class TeamService
    {
        private readonly TeamRepository _repo = new TeamRepository();

        public List<Team> GetAllTeams() => _repo.GetAll();

        public bool AddTeam(Team t)
        {
            var val = Validator.ValidateTeam(t);
            if (!val.IsValid) throw new System.Exception(val.Message);
            return _repo.Add(t);
        }

        public bool UpdateTeam(Team t)
        {
            var val = Validator.ValidateTeam(t);
            if (!val.IsValid) throw new System.Exception(val.Message);
            return _repo.Update(t);
        }

        public bool DeleteTeam(int id) => _repo.Delete(id);
    }
}