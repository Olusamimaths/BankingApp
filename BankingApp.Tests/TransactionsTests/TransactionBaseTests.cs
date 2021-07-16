using System;
using Xunit;
using BankingApp.Transactions;
using BankingApp.Entity;
using BankingApp.Accounts; 

namespace BankingApp.Tests.TransactionsTests
{
    public class TransactionBaseTests
    {
        Account account = new Account(new User("Sam", "Tobi"));

        [Fact]
        public void Creates_Transaction_With_ID()
        {
            TransactionBase transaction = new TransactionBase(account);
            string transactionID = transaction.GetID();
            Assert.True(transactionID.GetType() == typeof(string));
        }

        [Fact]
        public void Links_Account_To_Transaction()
        {
            TransactionBase transaction = new TransactionBase(account);
            Assert.Equal(transaction.LinkedAccount, account);
        }

        [Fact]
        public void Sets_Created_At_Date()
        {
            TransactionBase transaction = new TransactionBase(account);
            Assert.True(transaction.CreatedAt.GetType() == typeof(DateTime));
        }

        [Fact]
        public void Newly_Created_Transaction_Is_Not_Complete_By_Default()
        {
            TransactionBase transaction = new TransactionBase(account);
            Assert.False(transaction.IsCompleted);
        }

        [Fact]
        public void Newly_Created_Transaction_Is_Not_Cancelled_By_Default()
        {
            TransactionBase transaction = new TransactionBase(account);
            Assert.False(transaction.IsCancelled);
        }

        [Fact]
        public void Cancels_Transaction()
        {
            TransactionBase transaction = new TransactionBase(account);
            transaction.Cancel();
            Assert.True(transaction.IsCancelled);
        }

        [Fact]
        public void Completes_Transaction()
        {
            TransactionBase transaction = new TransactionBase(account);
            transaction.Complete();
            Assert.True(transaction.IsCompleted);
        }
    }
}