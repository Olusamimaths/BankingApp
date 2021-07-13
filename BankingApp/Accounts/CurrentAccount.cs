using BankingApp.Utilities;

namespace BankingApp.Accounts
{
    public class CurrentAccount : Account
    {
        public decimal OverDraft { get; private set; }
        
        public CurrentAccount(string userID) : base(userID) {
            this.MinimumBalance = AccountInfo.CurrentAccountMinBalance;
            this.MaximumBalance = AccountInfo.CurrentAccountMaxBalance;
        }
    }
}