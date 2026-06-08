namespace PSLCommandCentre.Domain
{
    public class MatchResult
    {
        public int ResultId { get; set; }
        public int MatchId { get; set; }
        public int WinnerTeamId { get; set; }
        public int Margin { get; set; }
        public string MarginType { get; set; }  // "runs" or "wickets"
        public int? MotmPlayerId { get; set; }

        // Display only
        public string WinnerTeamName { get; set; }
        public string MotmPlayerName { get; set; }
    }
}