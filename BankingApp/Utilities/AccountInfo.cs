namespace BankingApp.Utilities
{
    public static class AccountInfo
    {
        public const decimal GeneralAccountMinBalance = 1000;
        public const decimal GeneralAccountMaxBalance = 5_000_000;
        public const decimal StudentAccountMinBalance = 0;
        public const decimal StudentAccountMaxBalance = 1_000_000;
        public const decimal SavingsAccountMinBalance = 0;
        public const decimal SavingsAccountMaxBalance = 10_000_000;
        public const decimal CurrentAccountMinBalance = 2000;
        public const decimal CurrentAccountMaxBalance = 15_000_000;
    }
}