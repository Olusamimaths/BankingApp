using System;
using BankingApp.Utilities;
using BankingApp.Accounts;

namespace BankingApp.Transactions
{
    /// <summary>
    /// Represents Withdrawal transaction
    /// </summary>
    public class WithdrawalTransaction : TransactionBase
    {
        /// <summary>
        /// Creates a withdrawal transaction linked to an account
        /// </summary>
        /// <param name="account">Account the transaction is linked to</param>
        public WithdrawalTransaction(Account account) : base(account) {}

        /// <summary>
        /// Withdraws from account provided
        /// </summary>
        /// <param name="account">Account to withdraw from</param>
        /// <param name="amount">Amount to withdraw</param>
        public void WithdrawalOrThrow(decimal amount) {
            ThrowIfAccountIsUnfunded();
            this.ThrowIfInsufficientBalance(amount);
            this.LinkedAccount.WithdrawOrThrow(amount);
        }

        private void ThrowIfAccountIsUnfunded() {
            if(this.LinkedAccount.GetBalance() == 0) throw new Exception(ErrorMessages.WithdrawalUnfundedAccount);
        }
    }
}