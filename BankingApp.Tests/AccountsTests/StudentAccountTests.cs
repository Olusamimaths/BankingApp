using System;
using Xunit;
using BankingApp.Roles;
using BankingApp.Common;
using BankingApp.Accounts;
using BankingApp.Entity;

namespace BankingApp.Tests.AccountsTests
{
    public class StudentAccountTests
    {
        const string ID = "1234";
        User user1 = new User("Sam", "Tobi");

        [Fact]
        public void Creates_Student_Account()
        {
            StudentAccount stAccount = new StudentAccount(user1, ID);
            Assert.True(stAccount.GetID().GetType() == typeof(string));
        }
    }
}