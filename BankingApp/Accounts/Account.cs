using System;
using BankingApp.Common;
using BankingApp.Utilities;

namespace BankingApp.Accounts
{
    public class Account : BasicEntity
    {
        private string ID;
        protected decimal Balance;
        public decimal MinimumBalance;
        public decimal MaximumBalance;
        public bool IsActive { get; private set; }
        public string UserID { get; private set; }

        public Account(string userID) {
            ID = UniqueIdGenerator.GenerateNewId();
            UserID = userID;
            IsActive = true;
            MinimumBalance = AccountInfo.GeneralAccountMinBalance;
            MaximumBalance = AccountInfo.GeneralAccountMaxBalance;
        }

        public override string GetID()
        {   
            return ID;
        }
        
        public decimal GetBalance() {
            return Decimal.Floor(Balance);
        }

        public void DepositOrThrow(decimal amount) {
            ThrowExceptionIfNegativeAmount(amount);
            decimal sum = Decimal.Add(Balance, amount);
            Balance = sum;
            DeactivateAccountIfMaxBalanceExceeded(sum);
        }

        private void DeactivateAccountIfMaxBalanceExceeded(decimal balance) {
            if(balance > MaximumBalance) {
                IsActive = false;
                Console.WriteLine(ErrorMessages.InvalidDeposit);
            }
        }

        public void WithdrawOrThrow(decimal amount) {
            ThrowExceptionIfNegativeAmount(amount);
            if(GetBalance() < amount) throw new Exception(ErrorMessages.InsufficientBalance); 
            decimal sub = Decimal.Subtract(Balance, amount);
            if(sub < MinimumBalance) {
                Console.WriteLine(ErrorMessages.InvalidWithdrawal);
                return;
            };
            Balance = sub;
        }

        private void ThrowExceptionIfNegativeAmount(decimal amount) {
            if(amount < 0) throw new Exception(ErrorMessages.InvalidAmount);
        }

        public void DeactivateAccount() {
            IsActive = false;
        }

    }
}