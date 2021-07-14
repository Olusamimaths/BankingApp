using System;
using BankingApp.Common;
using BankingApp.Utilities;
using BankingApp.Entity;

namespace BankingApp.Accounts
{
    public class Account : BasicEntity
    {
        private string ID;
        protected decimal Balance;
        public decimal MinimumBalance;
        public decimal MaximumBalance;
        public bool IsActive { get; private set; }
        public User Owner { get; private set; }

        public Account(User user) {
            ID = UniqueIdGenerator.GenerateNewId();
            Owner = user;
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