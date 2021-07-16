using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BankingApp.Utilities
{
    /// <summary>
    /// Generates unique 10 digit bank numbers 
    /// Bank numbers start with the Prefix 22 e.g 2252315676, 2224434047
    /// </summary>
    public static class AccountNumberGenerator
    {
        /// <summary>
        /// The prefix acount numbers start from
        /// </summary>
        /// <value></value>
        public static int Prefix { get; private set; } = 22;

        // BaseBankNumber = 2200000000
        private static long BaseBankNumber = Prefix * (long)Math.Pow(10, 8);

        // Random eight digit number will be created between LowerBound and UpperBound
        private static int LowerBound = 10000000;
        private static int UpperBound = 99999999;

        private static Random random = new Random();
        private static List<long> bankNumbers = new List<long>();

        /// <summary>
        /// 10 digits unique account number generator
        /// </summary>
        /// <returns>10 digit account number</returns>
        public static long Generate() {
            long bankNumber = random.Next(LowerBound, UpperBound);
            bankNumber = bankNumber + BaseBankNumber;
            // Continue to generate more numbers if current bankNumber has been generated before
            while(bankNumbers.Contains(bankNumber)) bankNumber = random.Next(0, 8);
            // add random eight digit number to 2200000000
            return bankNumber;
        }
        
        /// <summary>
        /// Gets a read-only collection of all the account numbers that have been generated
        /// </summary>
        /// <returns>Read-only collection of all account numbers</returns>
        public static ReadOnlyCollection<long> GetAllBankNumbers() {
            return new ReadOnlyCollection<long>(bankNumbers);
        }
    }
}