using System;
using Xunit;
using BankingApp.Flows;
using System.Collections.Generic;
using BankingApp.Entity;
using BankingApp.Accounts;

namespace BankingApp.Tests.FlowsTests
{
    public class AppFlowTests
    {
        User user1 = new User("Sam", "Tobi");

        [Fact]
        public void Finds_An_Account_In_List() {
            List<Account> accounts = new List<Account>();
            
            Account acc = new Account(user1);

            accounts.Add(new Account(user1));
            accounts.Add(new Account(user1));
            accounts.Add(new Account(user1));
            accounts.Add(new Account(user1));
            accounts.Add(new Account(user1));
            accounts.Add(acc);

            Account foundAccount = AppFlow.FindAccountByAccountNumber(accounts, acc.GetAccountNumber());
            Assert.True(foundAccount.GetAccountNumber() == acc.GetAccountNumber());
        }

        [Fact]
        public void Returns_Null_If_Account_Is_Not_In_List() {
             List<Account> accounts = new List<Account>();
            
            Account acc = new Account(user1);

            accounts.Add(new Account(user1));
            accounts.Add(new Account(user1));
            accounts.Add(new Account(user1));
            accounts.Add(new Account(user1));
            accounts.Add(new Account(user1));

            Account foundAccount = AppFlow.FindAccountByAccountNumber(accounts, acc.GetAccountNumber());
            Assert.True(foundAccount == null);
        }
    }
}