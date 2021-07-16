using System;
using Xunit;
using BankingApp.Roles;
using BankingApp.Common;
using BankingApp.Accounts;
using BankingApp.Utilities;
using BankingApp.Entity;


namespace BankingApp.Tests.AccountsTests
{
    public class SavingsAccountTests
    {
        User user1 = new User("Sam", "Tobi");
        decimal amount = 1000;
        
        [Fact]
        public void Creates_Savings_Account()
        {
            SavingsAccount savingsAccount = new SavingsAccount(user1);
            Assert.True(savingsAccount.GetID().GetType() == typeof(string));
        }

        [Fact]
        public void Creates_Savings_Account_With_Zero_Starting_Amount()
        {
            SavingsAccount stAccount = new SavingsAccount(user1);
            Assert.True(stAccount.GetBalance() == 0);
        }

        [Fact]
        public void Creates_Savings_Account_With_Starting_Amount()
        {
            SavingsAccount stAccount = new SavingsAccount(user1, amount);
            Assert.True(stAccount.GetBalance() == amount);
        }

        
        [Fact]
        public void Sets_Minimum_Balance_By_Default()
        {
            SavingsAccount account = new SavingsAccount(user1);
            Assert.Equal(account.MinimumBalance, AccountInfo.SavingsAccountMinBalance);
            
        }

        [Fact]
        public void Sets_Maximum_Balance_By_Default()
        {
            SavingsAccount account = new SavingsAccount(user1);
            Assert.Equal(account.MaximumBalance, AccountInfo.SavingsAccountMaxBalance);
         
        }

        [Fact]
        public void Creates_SavingAccounts_With_Zero_Interest_Ratio_By_Default()
        {
            SavingsAccount savingsAccount = new SavingsAccount(user1);
            Assert.True(savingsAccount.InterestRatio == 0);
        }

        [Fact]
        public void Updates_Interest_Ratio()
        {
            SavingsAccount savingsAccount = new SavingsAccount(user1);
            savingsAccount.SetInterestRatio(5);
            Assert.Equal(5, savingsAccount.InterestRatio);
        }

        [Fact]
        public void Updates_ZeroBalance_Status()
        {
            SavingsAccount savingsAccount = new SavingsAccount(user1);
            savingsAccount.SetIsZeroBalance(true);
            Assert.True(savingsAccount.IsZeroBalance);
        }

        [Fact]
        public void Deactivates_Account_When_Savings_Max_Balance_Exceeded()
        {
            SavingsAccount savingsAccount = new SavingsAccount(user1);
            Assert.True(savingsAccount.IsActive);
            
            savingsAccount.DepositOrThrow(AccountInfo.SavingsAccountMaxBalance);
            savingsAccount.DepositOrThrow(1000);
            Assert.False(savingsAccount.IsActive);
        }
    }
}