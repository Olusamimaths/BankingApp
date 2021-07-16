using System;
using BankingApp.Common;
using BankingApp.Utilities;
using BankingApp.Accounts;

namespace BankingApp.Transactions 
{
    /// <summary>
    /// Represents the Base Transaction class
    /// </summary>
    public class TransactionBase : BasicEntity
    {
        private string ID;
        /// <summary>
        /// Account transaction is linked to
        /// </summary>
        public Account LinkedAccount;

        /// <summary>
        /// The date the transaction was created
        /// </summary>
        public DateTime CreatedAt;

        /// <summary>
        /// Flag indicating if transaction is completed
        /// </summary>
        public bool IsCompleted {get; private set; }

        /// <summary>
        /// flag indicating if transaction is cancelled
        /// </summary>
        public bool IsCancelled { get; private set; }

        /// <summary>
        /// Creates base transaction object
        /// Also sets a unique ID
        /// </summary>
        public TransactionBase() {
            ID = UniqueIdGenerator.GenerateNewId();
            CreatedAt = DateTime.Now;
            IsCompleted = false;
            IsCancelled = false;
        }

        /// <summary>
        /// Creates a base transaction object and links an account to it
        /// </summary>
        /// <param name="account">Account to be linked to transaction</param>
        public TransactionBase(Account account) : this() {
            LinkedAccount = account;
        }

        /// <summary>
        /// Gets the Unique ID assigned to transaction
        /// </summary>
        /// <returns>String: Transaction ID</returns>
        public override string GetID()
        {
            return ID;
        }

        /// <summary>
        /// Cancels a transaction
        /// </summary>
        public void Cancel() {
            IsCancelled = true;
        }

        /// <summary>
        /// Completes a transaction
        /// </summary>
        public void Complete() {
            IsCompleted = true;
        }

        protected void ThrowIfInsufficientBalance(decimal amount) {
            if(LinkedAccount.GetBalance() < amount) throw new Exception(ErrorMessages.InsufficientBalance);;
        }
    }
}