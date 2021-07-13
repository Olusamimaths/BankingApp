namespace BankingApp.Utilities
{
    public static class ErrorMessages
    {
        public const string InvalidPhone = "Invalid Phone Number. Please provide a valid phone number";
        public const string InsufficientBalance = "Transaction Failed. Insufficient Balance";
        public const string InvalidAmount = "Transaction Failed. Amount provided should be a positive number";
        public const string InvalidDeposit = "Balance has exceeded the current max possible on your account. You account has been deactivated, ungrade your account to be able to access your money";
        public const string InvalidWithdrawal = "Withdrawal cannot be completed. Min balance will be exceeded.";
    }
}