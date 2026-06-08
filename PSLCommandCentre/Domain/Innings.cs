namespace PSLCommandCentre.Domain
{
    public class Innings
    {
        public int InningsId { get; set; }
        public int MatchId { get; set; }
        public int BattingTeamId { get; set; }
        public int InningsNumber { get; set; }
        public int TotalRuns { get; set; }
        public int TotalWickets { get; set; }
        public decimal TotalOvers { get; set; }

        // Display only
        public string BattingTeamName { get; set; }

        public override string ToString() =>
            $"Innings {InningsNumber}: {TotalRuns}/{TotalWickets} ({TotalOvers} ov)";
    }
}