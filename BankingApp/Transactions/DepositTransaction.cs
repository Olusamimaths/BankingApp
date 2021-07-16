using System;
using BankingApp.Utilities;
using BankingApp.Accounts;

namespace BankingApp.Transactions
{
    /// <summary>
    /// Represents a Deposit Transaction
    /// </summary>
    public class DepositTransaction : TransactionBase
    {
        /// <summary>
        /// Account to make deposit into
        /// </summary>
        /// <value>Account</value>
        public Account DestinationAccount { get; private set; }

        /// <summary>
        /// Sets deposit transaction destination account
        /// </summary>
        /// <param name="destinationAccount">Account</param>
        public void SetDestinationAccount(Account destinationAccount) {
            DestinationAccount = destinationAccount;
        }

        /// <summary>
        /// Deposits to destination account or fails
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        public void DepositToDestinationOrFail(decimal amount) {
            if(DestinationAccount == null) throw new Exception(ErrorMessages.DestinationAccountNotSet);
            try
            {
                DestinationAccount.DepositOrThrow(amount);;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Sorry, deposit failed. Reason: " + ex.Message);
            }
        }
    }
}