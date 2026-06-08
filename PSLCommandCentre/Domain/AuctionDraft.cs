namespace PSLCommandCentre.Domain
{
    public class AuctionDraft
    {
        public int AuctionId { get; set; }
        public int SeasonId { get; set; }
        public int PlayerId { get; set; }
        public decimal BasePrice { get; set; }
        public decimal? SoldPrice { get; set; }
        public int? BoughtByTeam { get; set; }
        public string Status { get; set; } = "Unsold";

        // Display only
        public string PlayerName { get; set; }
        public string PlayerRole { get; set; }
        public string PlayerNation { get; set; }
        public string BoughtByTeamName { get; set; }

        public override string ToString() => PlayerName;
    }
}