using BankingApp.Utilities;

namespace BankingApp.Accounts
{
    public class SavingsAccount : Account
    {
        public float InterestRatio { get; private set; }
        public bool IsZeroBalance { get; private set; }
        public SavingsAccount(string userID) : base(userID) {
            this.MinimumBalance = AccountInfo.SavingsAccountMinBalance;
            this.MaximumBalance = AccountInfo.SavingsAccountMaxBalance;
        }

        public void SetInterestRatio(float newInterest) {
            InterestRatio = newInterest;
        }

        public void SetIsZeroBalance(bool val) {
            IsZeroBalance = val;
        }
    }
}