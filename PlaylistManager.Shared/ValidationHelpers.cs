using System.Text.RegularExpressions;

namespace PlaylistManager.Shared
{
    public static class ValidationHelpers
    {
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
