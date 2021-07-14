using System;
using Xunit;
using BankingApp.Accounts;
using BankingApp.Utilities;
using BankingApp.Entity;

namespace BankingApp.Tests.AccountsTests
{
    public class CurrentAccountTests
    {
        User user1 = new User("Sam", "Tobi");

        [Fact]
        public void Creates_Current_Account()
        {
            CurrentAccount currentAccount = new CurrentAccount(user1);
            Assert.True(currentAccount.GetID().GetType() == typeof(string));
        }

        [Fact]
        public void Deactivates_Account_When_Current_Max_Balance_Exceeded()
        {
            CurrentAccount currentAccount = new CurrentAccount(user1);
            Assert.True(currentAccount.IsActive);
            
            currentAccount.DepositOrThrow(AccountInfo.CurrentAccountMaxBalance);
            currentAccount.DepositOrThrow(1000);
            Assert.False(currentAccount.IsActive);
        }

        [Fact]
        public void Withdrawal_Fails_When_Current_Min_Balance_Will_Be_Exceeded()
        {
            CurrentAccount account = new CurrentAccount(user1);
            
            account.DepositOrThrow(AccountInfo.CurrentAccountMinBalance);
            account.WithdrawOrThrow(200);

            Assert.Equal(account.GetBalance(), AccountInfo.CurrentAccountMinBalance);
        }
    }
}   