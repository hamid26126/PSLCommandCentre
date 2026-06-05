using System;

namespace PSLCommandCentre.Domain
{
    public class Season
    {
        public int SeasonId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Upcoming";

        public override string ToString() => Name;
    }
}