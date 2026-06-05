namespace PSLCommandCentre.Domain
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Owner { get; set; }
        public int? HomeVenueId { get; set; }
        public string HomeVenueName { get; set; } // for display only, not saved
        public decimal Budget { get; set; }

        public override string ToString() => Name;
    }
}