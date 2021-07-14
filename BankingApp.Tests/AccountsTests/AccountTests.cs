using System;
using Xunit;
using BankingApp.Accounts; 
using BankingApp.Utilities;
using BankingApp.Entity;

namespace BankingApp.Tests.AccountsTests
{
    public class AccountTests
    {
        User user1 = new User("Sam", "Tobi");
        User user2 = new User("Sam", "Tobi");

        [Fact]
        public void Creates_ID_For_Account()
        {
            Account account = new Account(user1);
            string accountID = account.GetID();
            Assert.True(accountID.GetType() == typeof(string));
        }

        [Fact]
        public void Links_User_Id_To_Account()
        {
            Account account = new Account(user1);
            User owner = account.Owner;
            Assert.True(owner == user1);
        }

        [Fact]
        public void AccountIDs_Must_Be_Unique()
        {
            Account account = new Account(user1);
            string accountID = account.GetID();

            Account account2 = new Account(user2);
            string accountID2 = account2.GetID();

            Assert.NotEqual(accountID, accountID2);
        }

        [Fact]
        public void Account_Is_Active_By_Default()
        {
            Account account = new Account(user1);
            Assert.True(account.IsActive);
        }
        
        [Fact]
        public void Set_Balance_To_Zero_By_Default()
        {
            Account account = new Account(user1);
            Assert.True(account.GetBalance() == 0);
        }

        [Fact]
        public void Sets_Minimum_Balance_By_Default()
        {
            Account account = new Account(user1);
            Assert.Equal(account.MinimumBalance, AccountInfo.GeneralAccountMinBalance);
            
        }

        [Fact]
        public void Sets_Maximum_Balance_By_Default()
        {
            Account account = new Account(user1);
            Assert.Equal(account.MaximumBalance, AccountInfo.GeneralAccountMaxBalance);
         
        }

        [Fact]
        public void Adds_To_Account_Balance()
        {
            Account account = new Account(user1);
            Assert.True(account.GetBalance() == 0);

            account.DepositOrThrow(1000);

            Assert.True(account.GetBalance() == 1000);
        }

        [Fact]
        public void Withdraws_From_Account_Balance()
        {
            Account account = new Account(user1);
            account.DepositOrThrow(5000);
            account.WithdrawOrThrow(400);

            Assert.True(account.GetBalance() == 4600);
        }

        [Fact]
        public void Throws_Exception_If_No_Previous_Deposit()
        {
            Account account = new Account(user1);

            var ex = Assert.Throws<Exception>(() => account.WithdrawOrThrow(100));
            Assert.Equal(ex.Message, ErrorMessages.InsufficientBalance);
        }

        [Fact]
        public void Throws_Exception_If_Insufficient_Balance()
        {
            Account account = new Account(user1);
            account.DepositOrThrow(40);

            var ex = Assert.Throws<Exception>(() => account.WithdrawOrThrow(100));
            Assert.Equal(ex.Message, ErrorMessages.InsufficientBalance);
        }

        [Fact]
        public void Throws_Exception_If_Negative_Amount_For_Deposit()
        {
            Account account = new Account(user1);

            var ex = Assert.Throws<Exception>(() => account.DepositOrThrow(-100));
            Assert.Equal(ex.Message, ErrorMessages.InvalidAmount);
        }

        [Fact]
        public void Throws_Exception_If_Negative_Amount_For_Withdrawal()
        {
            Account account = new Account(user1);
            account.DepositOrThrow(1000);

            var ex = Assert.Throws<Exception>(() => account.WithdrawOrThrow(-100));
            Assert.Equal(ex.Message, ErrorMessages.InvalidAmount);
        }

        [Fact]
        public void Deactivates_Account_When_Max_Balance_Exceeded()
        {
            Account account = new Account(user1);
            Assert.True(account.IsActive);
            
            account.DepositOrThrow(AccountInfo.GeneralAccountMaxBalance);
            account.DepositOrThrow(1000);
            Assert.False(account.IsActive);
        }

        [Fact]
        public void Withdrawal_Fails_When_Min_Balance_Will_Be_Exceeded()
        {
            Account account = new Account(user1);
            
            account.DepositOrThrow(AccountInfo.GeneralAccountMinBalance);
            account.WithdrawOrThrow(200);

            Assert.Equal(account.GetBalance(), AccountInfo.GeneralAccountMinBalance);
        }

        [Fact]
        public void Deactivates_Account()
        {
            Account account = new Account(user1);
            Assert.True(account.IsActive);

            account.DeactivateAccount();
            Assert.False(account.IsActive);
        }
    }
}