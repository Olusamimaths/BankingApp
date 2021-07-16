using BankingApp.Utilities;
using BankingApp.Entity;

namespace BankingApp.Accounts
{
    public class CurrentAccount : Account
    {
        public decimal OverDraft { get; private set; }

        private void Init() {
            this.MinimumBalance = AccountInfo.CurrentAccountMinBalance;
            this.MaximumBalance = AccountInfo.CurrentAccountMaxBalance;
        }
        
        /// <summary>
        /// Creates a current account for a user 
        /// And initializes minimum and maximum amounts allowed on the account
        /// </summary>
        /// <param name="user">Owner of the account</param>
        public CurrentAccount(User user) : base(user) {
            Init();
        }

        /// <summary>
        /// Creates a current account for a user with initial deposit
        /// And initializes minimum and maximum amounts allowed on the account
        /// </summary>
        /// <param name="user">Owner of the account</param>
        /// <param name="amount">Initial deposit amount</param>
        public CurrentAccount(User user, decimal amount) : base(user, amount) {
            Init();
        }
    }
}