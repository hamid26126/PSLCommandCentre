using System;

namespace PSLCommandCentre.Domain
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string BattingStyle { get; set; }
        public string BowlingStyle { get; set; }
        public string Role { get; set; }
        public bool IsForeign { get; set; }
        public string ProfilePic { get; set; }

        public int Age => DateOfBirth.HasValue
            ? DateTime.Today.Year - DateOfBirth.Value.Year
            : 0;

        public override string ToString() => Name;
    }
}