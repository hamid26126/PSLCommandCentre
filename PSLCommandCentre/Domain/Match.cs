using System;

namespace PSLCommandCentre.Domain
{
    public class Match
    {
        public int MatchId { get; set; }
        public int SeasonId { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public int VenueId { get; set; }
        public DateTime MatchDate { get; set; }
        public string MatchType { get; set; } = "League";
        public string Status { get; set; } = "Scheduled";

        // Display-only — filled when reading from DB with joins
        public string SeasonName { get; set; }
        public string Team1Name { get; set; }
        public string Team2Name { get; set; }
        public string VenueName { get; set; }
    }
}