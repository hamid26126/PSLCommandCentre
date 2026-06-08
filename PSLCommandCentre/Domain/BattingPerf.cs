namespace PSLCommandCentre.Domain
{
    public class BattingPerf
    {
        public int BpId { get; set; }
        public int InningsId { get; set; }
        public int PlayerId { get; set; }
        public int Runs { get; set; }
        public int Balls { get; set; }
        public int Fours { get; set; }
        public int Sixes { get; set; }
        public string DismissalType { get; set; }

        // Display only
        public string PlayerName { get; set; }

        public double StrikeRate => Balls > 0
            ? System.Math.Round((double)Runs / Balls * 100, 2) : 0;
    }
}