namespace PSLCommandCentre.Domain
{
    public class Venue
    {
        public int VenueId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
        public string PitchType { get; set; }
        public string Country { get; set; } = "Pakistan";

        public override string ToString() => Name; // lets Venue show nicely in ComboBoxes
    }
}