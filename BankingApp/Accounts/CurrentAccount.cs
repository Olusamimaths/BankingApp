using BankingApp.Utilities;
using BankingApp.Entity;

namespace BankingApp.Accounts
{
    public class CurrentAccount : Account
    {
        public decimal OverDraft { get; private set; }
        
        public CurrentAccount(User user) : base(user) {
            this.MinimumBalance = AccountInfo.CurrentAccountMinBalance;
            this.MaximumBalance = AccountInfo.CurrentAccountMaxBalance;
        }
    }
}