using System;
using Xunit;
using BankingApp.Accounts; 
using BankingApp.Utilities;

namespace BankingApp.Tests.AccountsTests
{
    public class AccountTests
    {
        const string ID = "1234";
        const string ID2 = "567";

        [Fact]
        public void Creates_ID_For_Account()
        {
            Account account = new Account(ID);
            string accountID = account.GetID();
            Assert.True(accountID.GetType() == typeof(string));
        }

        [Fact]
        public void Links_User_Id_To_Account()
        {
            Account account = new Account(ID);
            string userID = account.UserID;
            Assert.True(userID == ID);
        }

        [Fact]
        public void AccountIDs_Must_Be_Unique()
        {
            Account account = new Account(ID);
            string accountID = account.GetID();

            Account account2 = new Account(ID2);
            string accountID2 = account2.GetID();

            Assert.NotEqual(accountID, accountID2);
        }

        [Fact]
        public void Account_Is_Active_By_Default()
        {
            Account account = new Account(ID);
            Assert.True(account.IsActive);
        }
        
        [Fact]
        public void Set_Balance_To_Zero_By_Default()
        {
            Account account = new Account(ID);
            Assert.True(account.GetBalance() == 0);
        }

        [Fact]
        public void Sets_Minimum_Balance_By_Default()
        {
            Account account = new Account(ID);
            Assert.Equal(account.MinimumBalance, AccountInfo.GeneralAccountMinBalance);
            
        }

        [Fact]
        public void Sets_Maximum_Balance_By_Default()
        {
            Account account = new Account(ID);
            Assert.Equal(account.MaximumBalance, AccountInfo.GeneralAccountMaxBalance);
         
        }

        [Fact]
        public void Adds_To_Account_Balance()
        {
            Account account = new Account(ID);
            Assert.True(account.GetBalance() == 0);

            account.DepositOrThrow(1000);

            Assert.True(account.GetBalance() == 1000);
        }

        [Fact]
        public void Withdraws_From_Account_Balance()
        {
            Account account = new Account(ID);
            account.DepositOrThrow(5000);
            account.WithdrawOrThrow(400);

            Assert.True(account.GetBalance() == 4600);
        }

        [Fact]
        public void Throws_Exception_If_No_Previous_Deposit()
        {
            Account account = new Account(ID);

            var ex = Assert.Throws<Exception>(() => account.WithdrawOrThrow(100));
            Assert.Equal(ex.Message, ErrorMessages.InsufficientBalance);
        }

        [Fact]
        public void Throws_Exception_If_Insufficient_Balance()
        {
            Account account = new Account(ID);
            account.DepositOrThrow(40);

            var ex = Assert.Throws<Exception>(() => account.WithdrawOrThrow(100));
            Assert.Equal(ex.Message, ErrorMessages.InsufficientBalance);
        }

        [Fact]
        public void Throws_Exception_If_Negative_Amount_For_Deposit()
        {
            Account account = new Account(ID);

            var ex = Assert.Throws<Exception>(() => account.DepositOrThrow(-100));
            Assert.Equal(ex.Message, ErrorMessages.InvalidAmount);
        }

        [Fact]
        public void Throws_Exception_If_Negative_Amount_For_Withdrawal()
        {
            Account account = new Account(ID);
            account.DepositOrThrow(1000);

            var ex = Assert.Throws<Exception>(() => account.WithdrawOrThrow(-100));
            Assert.Equal(ex.Message, ErrorMessages.InvalidAmount);
        }

        [Fact]
        public void Deactivates_Account_When_Max_Balance_Exceeded()
        {
            Account account = new Account(ID);
            Assert.True(account.IsActive);
            
            account.DepositOrThrow(AccountInfo.GeneralAccountMaxBalance);
            account.DepositOrThrow(1000);
            Assert.False(account.IsActive);
        }

        [Fact]
        public void Withdrawal_Fails_When_Min_Balance_Will_Be_Exceeded()
        {
            Account account = new Account(ID);
            
            account.DepositOrThrow(AccountInfo.GeneralAccountMinBalance);
            account.WithdrawOrThrow(200);

            Assert.Equal(account.GetBalance(), AccountInfo.GeneralAccountMinBalance);
        }

        [Fact]
        public void Deactivates_Account()
        {
            Account account = new Account(ID);
            Assert.True(account.IsActive);

            account.DeactivateAccount();
            Assert.False(account.IsActive);
        }
    }
}