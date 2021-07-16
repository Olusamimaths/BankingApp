using System;
using Xunit;
using BankingApp.Entity; 
using BankingApp.Accounts; 
using BankingApp.Utilities;
using BankingApp.Transactions;

namespace BankingApp.Tests.TransactionsTests
{
    public class DepositTransactionTests
    {
        Account account = new Account(new User("Sam", "Tobi"));
        Account account2 = new Account(new User("Sam", "Tobi"));
        decimal amount = 2000;


        [Fact]
        public void Links_A_Destination_Account_To_Deposit()
        {
            DepositTransaction depositTransaction = new DepositTransaction();
            depositTransaction.SetDestinationAccount(account2);

            Assert.Equal(depositTransaction.DestinationAccount, account2);
        }

        [Fact]
        public void Deposit_Throws_Exception_If_Destination_Not_Set()
        {
            DepositTransaction depositTransaction = new DepositTransaction();
            
            var ex = Assert.Throws<Exception>(() => depositTransaction.DepositToDestinationOrFail(amount));
            Assert.Equal(ex.Message, ErrorMessages.DestinationAccountNotSet);
        }

        [Fact]
        public void Deposits_To_Destination_Account()
        {
            DepositTransaction depositTransaction = new DepositTransaction();
            depositTransaction.SetDestinationAccount(account2);

            depositTransaction.DepositToDestinationOrFail(amount);
            decimal balance = depositTransaction.DestinationAccount.GetBalance();

            Assert.Equal(balance, amount);
        }
    }
}