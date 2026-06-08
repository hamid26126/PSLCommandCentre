using System;
using System.Collections.Generic;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Repositories;

namespace PSLCommandCentre.Services
{
    public class MatchService
    {
        private readonly MatchRepository _repo = new MatchRepository();

        public List<Match> GetAllMatches() => _repo.GetAll();
        public List<Match> GetMatchesBySeason(int sid) => _repo.GetBySeason(sid);

        public int AddMatch(Match m)
        {
            var val = Validator.ValidateMatch(m);
            if (!val.IsValid) throw new Exception(val.Message);
            return _repo.Add(m);
        }

        public bool UpdateMatch(Match m)
        {
            var val = Validator.ValidateMatch(m);
            if (!val.IsValid) throw new Exception(val.Message);
            return _repo.Update(m);
        }

        public bool DeleteMatch(int id) => _repo.Delete(id);
    }
}