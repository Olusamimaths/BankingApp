using System;
using Xunit;
using BankingApp.Roles;
using BankingApp.Common;
using BankingApp.Accounts;
using BankingApp.Utilities;
using BankingApp.Entity;

namespace BankingApp.Tests.AccountsTests
{
    public class StudentAccountTests
    {
        const string ID = "1234";
        User user1 = new User("Sam", "Tobi");
        decimal amount = 1000;

        [Fact]
        public void Creates_Student_Account()
        {
            StudentAccount stAccount = new StudentAccount(user1, ID);
            Assert.True(stAccount.GetID().GetType() == typeof(string));
        }

        
        [Fact]
        public void Creates_Student_Account_With_Zero_Starting_Amount()
        {
            StudentAccount stAccount = new StudentAccount(user1, ID);
            Assert.True(stAccount.GetBalance() == 0);
        }

        [Fact]
        public void Creates_Student_Account_With_Starting_Amount()
        {
            StudentAccount stAccount = new StudentAccount(user1, ID, amount);
            Assert.True(stAccount.GetBalance() == amount);
        }

        [Fact]
        public void Deactivates_Account_When_Student_Max_Balance_Exceeded()
        {
            StudentAccount studentAccount = new StudentAccount(user1, ID);
            Assert.True(studentAccount.IsActive);
            
            studentAccount.DepositOrThrow(AccountInfo.StudentAccountMaxBalance);
            studentAccount.DepositOrThrow(1000);
            Assert.False(studentAccount.IsActive);
        }
    }
}