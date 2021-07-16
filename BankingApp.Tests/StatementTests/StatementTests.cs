using System;
using Xunit;
using BankingApp.Entity;
using BankingApp.Accounts;

namespace BankingApp.Tests.StatementTests
{
    public class StatementTests
    {
        Account account = new Account(new User("Sam", "Tobi"));

        [Fact]
        public void Creates_Statement_For_Account()
        {
            Statement statement = new Statement(account);
            Assert.True(statement.GetID().GetType() == typeof(string));
            Assert.Equal(statement.LinkedAccount, account);
            Assert.True(statement.CreatedAt.GetType() == typeof(DateTime));
        }
    }
}