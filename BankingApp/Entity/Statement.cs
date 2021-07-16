using System;
using BankingApp.Common;
using BankingApp.Accounts;
using BankingApp.Utilities;

namespace BankingApp.Entity
{
    /// <summary>
    /// Represents the Bank account statement
    /// </summary>
    public class Statement : BasicEntity
    {
        private string ID;
        /// <summary>
        /// Account that the statement is generated for
        /// </summary>
        /// <value>Account</value>
        public Account LinkedAccount { get; private set; }

        /// <summary>
        /// The time the statement is generated
        /// </summary>
        /// <value></value>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Creates statement object that is linked to an account
        /// </summary>
        /// <param name="account">Account</param>
        public Statement(Account account) {
            LinkedAccount = account;
            ID = UniqueIdGenerator.GenerateNewId();
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Returns the statement ID
        /// </summary>
        /// <returns>String: Statement ID</returns>
        public override string GetID()
        {
            return ID;
        }
        
    }
}