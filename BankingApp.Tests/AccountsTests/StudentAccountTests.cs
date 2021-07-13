using System;
using Xunit;
using BankingApp.Roles;
using BankingApp.Common;
using BankingApp.Accounts;

namespace BankingApp.Tests.AccountsTests
{
    public class StudentAccountTests
    {
        const string ID = "1234";
        const string ID2 = "567";
        [Fact]
        public void Creates_Student_Account()
        {
            StudentAccount stAccount = new StudentAccount(ID, ID2);
            Assert.True(stAccount.UserID.GetType() == typeof(string));
            Assert.True(stAccount.GetID().GetType() == typeof(string));
        }
    }
}