using System;
using BankingApp.Utilities;
using BankingApp.Accounts;

namespace BankingApp.Transactions
{
    /// <summary>
    /// Represents a Transfer Transaction
    /// </summary>
    public class TransferTransaction : TransactionBase
    {
        /// <summary>
        /// Creates transfer object linked to account
        /// </summary>
        /// <param name="account">Account transaction is linked to</param>
        public TransferTransaction(Account account) : base(account) {}

        /// <summary>
        /// Transfer money to account 
        /// Throws exception when an error occurs
        /// </summary>
        /// <param name="account">Account to transfer to</param>
        /// <param name="amount">Amount to transfer</param>
        public void TransferOrThrow(Account account, decimal amount) {
            ThrowIfAccountIsUnfunded();
            this.ThrowIfInsufficientBalance(amount);
            ThrowIfBalanceWillGoBelowMinBalance(amount);
            Transfer(account, amount);
        }

        private void Transfer(Account targetAccount, decimal amount) {
             try
            {
                targetAccount.DepositOrThrow(amount);
                this.LinkedAccount.WithdrawOrThrow(amount);
                
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        private void ThrowIfAccountIsUnfunded() {
            if(this.LinkedAccount.GetBalance() == 0) throw new Exception(ErrorMessages.TransferUnfundedAccount);
        }

        private void ThrowIfBalanceWillGoBelowMinBalance(decimal amount) {
            decimal remainingBalance = Decimal.Subtract(this.LinkedAccount.GetBalance(), amount);
            if(remainingBalance < this.LinkedAccount.MinimumBalance) throw new Exception(ErrorMessages.TransferBalanceBelowMin);;
        }
    }
}