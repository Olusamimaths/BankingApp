using System;
using Xunit;
using BankingApp.Accounts;

namespace BankingApp.Tests.AccountsTests
{
    public class CurrentAccountTests
    {
        const string ID = "567";
        [Fact]
        public void Creates_Current_Account()
        {
            CurrentAccount currentAccount = new CurrentAccount(ID);
            Assert.True(currentAccount.GetID().GetType() == typeof(string));
        }
    }
}   