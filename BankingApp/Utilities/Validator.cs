using System;
using System.Text.RegularExpressions;

namespace BankingApp.Utilities
{
    /// <summary>
    /// Validator class for validating inputs
    /// </summary>
    public static class Validator
    {
        private static Regex rgx = new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");

        /// <summary>
        /// Checks if a string represents a valid phone number
        /// </summary>
        /// <param name="phone">String representation of Phone number to validate</param>
        /// <returns>Boolean indicating if phone number is valid or not</returns>
        public static bool IsValidPhoneNumber(string phone) {
            if(phone.Length < 10) {
                return false;
            }
            return rgx.IsMatch(phone);
        }
    }
}