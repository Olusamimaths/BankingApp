using BankingApp.Utilities;
using BankingApp.Entity;

namespace BankingApp.Accounts
{
    /// <summary>
    /// Represents a Savings Account class
    /// </summary>
    public class SavingsAccount : Account
    {
        /// <summary>
        /// Interest ratio on the savings account
        /// </summary>
        /// <value>float: Interest ratio</value>
        public float InterestRatio { get; private set; }

        /// <summary>
        /// Flag indincating if savings account is a zero balance account
        /// </summary>
        /// <value>Boolean</value>
        public bool IsZeroBalance { get; private set; }
        private void Init() {
            this.MinimumBalance = AccountInfo.SavingsAccountMinBalance;
            this.MaximumBalance = AccountInfo.SavingsAccountMaxBalance;
        }

        /// <summary>
        /// Creates a savings account for a user 
        /// And initializes minimum and maximum amounts allowed on the account
        /// </summary>
        /// <param name="user">Owner of the account</param>
        public SavingsAccount(User user) : base(user) {
            Init();
        }


        /// <summary>
        /// Creates a savings account for a user with initial deposit
        /// And initializes minimum and maximum amounts allowed on the account
        /// </summary>
        /// <param name="user">Owner of the account</param>
        /// <param name="amount">Initial deposit amount</param>
        public SavingsAccount(User user, decimal amount) : base(user, amount) {
            Init();
        }

        /// <summary>
        /// Sets the interest ratio
        /// </summary>
        /// <param name="newInterest">floating point number</param>
        public void SetInterestRatio(float newInterest) {
            InterestRatio = newInterest;
        }

        /// <summary>
        /// Set the IsZeroBalance status flag of account
        /// </summary>
        /// <param name="val"></param>
        public void SetIsZeroBalance(bool val) {
            IsZeroBalance = val;
        }
    }
}