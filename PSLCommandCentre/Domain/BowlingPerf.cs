namespace PSLCommandCentre.Domain
{
    public class BowlingPerf
    {
        public int BwpId { get; set; }
        public int InningsId { get; set; }
        public int PlayerId { get; set; }
        public decimal Overs { get; set; }
        public int RunsGiven { get; set; }
        public int Wickets { get; set; }
        public decimal Economy { get; set; }

        // Display only
        public string PlayerName { get; set; }
    }
}