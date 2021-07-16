namespace BankingApp.Utilities
{
    /// <summary>
    /// Holds account specific information
    /// </summary>
    public static class AccountInfo
    {
        /// <summary>
        /// The Minimum balance allowed on a general account
        /// </summary>
        public const decimal GeneralAccountMinBalance = 1000;
        /// <summary>
        /// The maximum balance allowed on a general account
        /// </summary>
        public const decimal GeneralAccountMaxBalance = 5_000_000;

        /// <summary>
        /// The Minimum balance allowed on a student account
        /// </summary>
        public const decimal StudentAccountMinBalance = 0;
        /// <summary>
        /// The Maximum balance allowed on a student account
        /// </summary>
        public const decimal StudentAccountMaxBalance = 1_000_000;

        /// <summary>
        /// The Minimum balance allowed on a Savings account
        /// </summary>
        public const decimal SavingsAccountMinBalance = 0;
        /// <summary>
        /// The maximum balance allowed on a Savings account
        /// </summary>
        public const decimal SavingsAccountMaxBalance = 10_000_000;

        /// <summary>
        /// The Minimum balance allowed on a Current account
        /// </summary>
        public const decimal CurrentAccountMinBalance = 2000;
        /// <summary>
        /// The Maximum balance allowed on a Current account
        /// </summary>
        public const decimal CurrentAccountMaxBalance = 15_000_000;
    }
}