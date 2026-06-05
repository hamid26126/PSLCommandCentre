using System.Collections.Generic;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Repositories;

namespace PSLCommandCentre.Services
{
    public class SeasonService
    {
        private readonly SeasonRepository _repo = new SeasonRepository();

        public List<Season> GetAllSeasons() => _repo.GetAll();

        public bool AddSeason(Season s)
        {
            var val = Validator.ValidateSeason(s);
            if (!val.IsValid) throw new System.Exception(val.Message);
            return _repo.Add(s);
        }

        public bool UpdateSeason(Season s)
        {
            var val = Validator.ValidateSeason(s);
            if (!val.IsValid) throw new System.Exception(val.Message);
            return _repo.Update(s);
        }

        public bool DeleteSeason(int id) => _repo.Delete(id);
    }
}