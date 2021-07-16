namespace BankingApp.Utilities
{
    /// <summary>
    /// Holds the error messages int thrown exceptions
    /// </summary>
    public static class ErrorMessages
    {
        /// <summary>
        /// Error message of exception thrown when phone number is invalid
        /// </summary>
        public const string InvalidPhone = "Invalid Phone Number. Please provide a valid phone number";

        /// <summary>
        /// Error message of exception thrown when balance is insufficient
        /// </summary>
        public const string InsufficientBalance = "Transaction Failed. Insufficient Balance";

        /// <summary>
        /// Error message of exception thrown when amount provided is invalid
        /// </summary>
        public const string InvalidAmount = "Transaction Failed. Amount provided should be a positive number";

        /// <summary>
        /// Error message of exception thrown when transfer is attempted on account that is unfunded
        /// </summary>
        public const string TransferUnfundedAccount = "Transfer Failed. You need to fund your account first";

        /// <summary>
        /// Error message of exception thrown when withdrawal is attempted on account that is unfunded
        /// </summary>
        public const string WithdrawalUnfundedAccount = "Withdrawal Failed. You need to fund your account first";

        /// <summary>
        /// Error message of exception thrown when transfer will leave balance in account below minimum balance
        /// </summary>
        public const string TransferBalanceBelowMin = "Transfer Failed. You will go below the allowed minimum balance on your account if transfer is made";

        /// <summary>
        /// Error message of exception thrown when balance has exceeded the maximum balance possible
        /// </summary>
        public const string MaxBalanceExceeded = "Balance has exceeded the current max possible on your account. You account has been deactivated, ungrade your account to be able to access your money";
        
        /// <summary>
        /// Error message of exception thrown when withdrawal will cause balance to go below minimum balance allowed in the account
        /// </summary>
        public const string InvalidWithdrawal = "Withdrawal cannot be completed. Min balance will be exceeded.";

        /// <summary>
        /// Error message of exception thrown when a destination account is not set
        /// </summary>
        public const string DestinationAccountNotSet = "Deposit failed because a destination account was not provided";

        /// <summary>
        /// Error message of exception thrown when a transaction is attempted on an account that has been deactivated
        /// </summary>
        public const string AccountDeactivated = "Transaction failed because account is currently deactivated.";
    }
}