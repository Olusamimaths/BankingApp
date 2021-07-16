using System;
using BankingApp.Common;
using BankingApp.Utilities;
using BankingApp.Entity;

namespace BankingApp.Accounts
{
    /// <summary>
    /// Represents base account object
    /// </summary>
    public class Account : BasicEntity
    {
        private string ID;
        private long AccountNumber;
        private decimal Balance = 0;

        /// <summary>
        /// The minimum balance allowed on the account
        /// </summary>
        public decimal MinimumBalance;

        /// <summary>
        /// The maximum balance allowed on the account
        /// </summary>
        public decimal MaximumBalance;

        /// <summary>
        /// Flag indicating if account is still active
        /// </summary>
        /// <value>A boolean</value>
        public bool IsActive { get; private set; }

        /// <summary>
        /// The owner of the account
        /// </summary>
        /// <value>A user object</value>
        public User Owner { get; private set; }

        /// <summary>
        /// Creates a new account object
        /// </summary>
        /// <param name="user">The owner of the account</param>
        public Account(User user) {
            ID = UniqueIdGenerator.GenerateNewId();
            Owner = user;
            IsActive = true;
            MinimumBalance = AccountInfo.GeneralAccountMinBalance;
            MaximumBalance = AccountInfo.GeneralAccountMaxBalance;
            AccountNumber = AccountNumberGenerator.Generate();
        }

        /// <summary>
        /// Creates a new account object
        /// </summary>
        /// <param name="user">Owner of the account</param>
        /// <param name="amount">Initial deposit into account</param>
        /// <returns></returns>
        public Account(User user, decimal amount) : this(user) {
            Balance = amount;
        }

        /// <summary>
        /// Gets the ID of the account
        /// </summary>
        /// <returns>string</returns>
        public override string GetID()
        {   
            return ID;
        }
        
        /// <summary>
        /// Gets the balance in the account
        /// </summary>
        /// <returns>Number representing the balance</returns>
        public decimal GetBalance() {
            return Decimal.Floor(Balance);
        }

        /// <summary>
        /// Deposits an amount into account. 
        /// Throws exception if an error occurs
        /// </summary>
        /// <param name="amount">Number: Amount to deposit</param>
        public void DepositOrThrow(decimal amount) {
            ThrowExceptionIfNegativeAmount(amount);
            ThrowExceptionIfAccountIsDeactivated();

            decimal sum = Decimal.Add(Balance, amount);
            Balance = sum;

            DeactivateAccountIfMaxBalanceExceeded(Balance);
        }


        /// <summary>
        /// Deactivates account if the maximum possible balance has been exceeded
        /// </summary>
        /// <param name="balance">The balance in account</param>
        private void DeactivateAccountIfMaxBalanceExceeded(decimal balance) {
            if(balance > MaximumBalance) {
                IsActive = false;
                Console.WriteLine(ErrorMessages.MaxBalanceExceeded);
            }
        }
        
        /// <summary>
        /// Withdraws an amount from account.
        /// Throws exception if error occurs
        /// </summary>
        /// <param name="amount"></param>
        public void WithdrawOrThrow(decimal amount) {
            ThrowExceptionIfNegativeAmount(amount);
            ThrowExceptionIfAccountIsDeactivated();
            ThrowExceptionIfInsuffientBalance(amount);

            decimal remainingBalance = Decimal.Subtract(Balance, amount);

            if(remainingBalance < MinimumBalance) {
                Console.WriteLine(ErrorMessages.InvalidWithdrawal);
                return;
            };
            Balance = remainingBalance;
        }

        // Throws exception if balance is less than amount provided
        private void ThrowExceptionIfInsuffientBalance(decimal amount) {
            if(GetBalance() < amount) throw new Exception(ErrorMessages.InsufficientBalance); 
        }

        // Throws exception if a negative amount is provided
        private void ThrowExceptionIfNegativeAmount(decimal amount) {
            if(amount < 0) throw new Exception(ErrorMessages.InvalidAmount);
        }

        // Throws exception if account
        private void ThrowExceptionIfAccountIsDeactivated() {
            if(!IsActive) throw new Exception(ErrorMessages.AccountDeactivated);
        }

        /// <summary>
        /// Deactivates account
        /// </summary>
        public void DeactivateAccount() {
            IsActive = false;
        }

        /// <summary>
        /// Gets the account number associated with the account
        /// </summary>
        /// <returns>10 digit account number</returns>
        public long GetAccountNumber() {
            return AccountNumber;
        }
    }
}