using System.Collections.Generic;
using PSLCommandCentre.Repositories;

namespace PSLCommandCentre.Services
{
    public class PointsTableService
    {
        private readonly PointsTableRepository _repo = new PointsTableRepository();

        public List<PointsTableEntry> GetStandings(int seasonId)
            => _repo.GetStandings(seasonId);

        public bool InitialiseForSeason(int seasonId, List<int> teamIds)
            => _repo.InitialiseForSeason(seasonId, teamIds);
    }
}