using System;
using System.Text.RegularExpressions;

namespace BankingApp.Utilities
{
    public static class Validator
    {
        static Regex rgx = new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");
        public static bool IsValidPhoneNumber(string phone) {
            if(phone.Length < 10) {
                return false;
            }
            return rgx.IsMatch(phone);
        }
    }
}