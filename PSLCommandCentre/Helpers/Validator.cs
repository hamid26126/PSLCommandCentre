using PSLCommandCentre.Domain;
using System;

namespace PSLCommandCentre.Helpers
{
    public class ValidationResult
    {
        public bool IsValid { get; private set; }
        public string Message { get; private set; }

        public static ValidationResult Ok()
            => new ValidationResult { IsValid = true, Message = "" };

        public static ValidationResult Fail(string message)
            => new ValidationResult { IsValid = false, Message = message };
    }

    public static class Validator
    {
        // --- Generic helpers ---

        public static bool IsEmpty(string value)
            => string.IsNullOrWhiteSpace(value);

        public static bool IsValidLength(string value, int min, int max)
            => !IsEmpty(value) && value.Trim().Length >= min && value.Trim().Length <= max;

        public static bool IsPositive(decimal value)
            => value > 0;

        // --- Login validation ---

        public static ValidationResult ValidateLogin(string username, string password)
        {
            if (IsEmpty(username))
                return ValidationResult.Fail("Username is required.");
            if (IsEmpty(password))
                return ValidationResult.Fail("Password is required.");
            if (password.Length < 4)
                return ValidationResult.Fail("Password must be at least 4 characters.");
            return ValidationResult.Ok();
        }

        // --- Player validation (you'll use this in Phase 2) ---

        public static ValidationResult ValidatePlayerName(string name)
        {
            if (IsEmpty(name))
                return ValidationResult.Fail("Player name is required.");
            if (!IsValidLength(name, 2, 100))
                return ValidationResult.Fail("Player name must be between 2 and 100 characters.");
            return ValidationResult.Ok();
        }

        public static ValidationResult ValidateVenue(Venue v)
        {
            if (IsEmpty(v.Name)) return ValidationResult.Fail("Venue name is required.");
            if (IsEmpty(v.City)) return ValidationResult.Fail("City is required.");
            if (v.Capacity <= 0) return ValidationResult.Fail("Capacity must be greater than 0.");
            return ValidationResult.Ok();
        }

        public static ValidationResult ValidateSeason(Season s)
        {
            if (IsEmpty(s.Name)) return ValidationResult.Fail("Season name is required.");
            if (s.Year < 2016) return ValidationResult.Fail("Year must be 2016 or later.");
            if (s.EndDate <= s.StartDate) return ValidationResult.Fail("End date must be after start date.");
            return ValidationResult.Ok();
        }

        public static ValidationResult ValidateTeam(Team t)
        {
            if (IsEmpty(t.Name)) return ValidationResult.Fail("Team name is required.");
            if (IsEmpty(t.City)) return ValidationResult.Fail("City is required.");
            if (t.Budget < 0) return ValidationResult.Fail("Budget cannot be negative.");
            return ValidationResult.Ok();
        }

        public static ValidationResult ValidatePlayer(Player p)
        {
            if (IsEmpty(p.Name)) return ValidationResult.Fail("Player name is required.");
            if (IsEmpty(p.Nationality)) return ValidationResult.Fail("Nationality is required.");
            if (IsEmpty(p.Role)) return ValidationResult.Fail("Role is required.");
            return ValidationResult.Ok();
        }

        public static ValidationResult ValidateMatch(Match m)
        {
            if (m.SeasonId <= 0) return ValidationResult.Fail("Please select a season.");
            if (m.Team1Id <= 0) return ValidationResult.Fail("Please select Team 1.");
            if (m.Team2Id <= 0) return ValidationResult.Fail("Please select Team 2.");
            if (m.Team1Id == m.Team2Id) return ValidationResult.Fail("A team cannot play against itself.");
            if (m.VenueId <= 0) return ValidationResult.Fail("Please select a venue.");
            if (m.MatchDate < DateTime.Today) return ValidationResult.Fail("Match date cannot be in the past.");
            return ValidationResult.Ok();
        }
    }
}