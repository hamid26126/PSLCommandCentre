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
    }
}