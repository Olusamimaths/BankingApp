using System;
using Xunit;
using BankingApp.Entity; 
using BankingApp.Accounts; 
using BankingApp.Utilities;
using BankingApp.Transactions;

namespace BankingApp.Tests.TransactionsTests
{
    public class WithdrawalTransactionTests
    {
        Account account = new Account(new User("Sam", "Tobi"));
        Account account2 = new Account(new User("Sam", "Tobi"));
        decimal amount = 2000;


        [Fact]
        public void Withdrawal_Fails_If_Account_Is_Unfunded()
        {
            WithdrawalTransaction withdrawalTransaction = new WithdrawalTransaction(account);

            var ex = Assert.Throws<Exception>(() => withdrawalTransaction.WithdrawalOrThrow(amount));
            Assert.Equal(ex.Message, ErrorMessages.WithdrawalUnfundedAccount);
        }

        [Fact]
        public void Withdrawal_Fails_If_Balance_Is_Insufficient()
        {
            WithdrawalTransaction withdrawalTransaction = new WithdrawalTransaction(account);
            withdrawalTransaction.LinkedAccount.DepositOrThrow(amount-100);

            var ex = Assert.Throws<Exception>(() => withdrawalTransaction.WithdrawalOrThrow(amount));
            Assert.Equal(ex.Message, ErrorMessages.InsufficientBalance);
        }

    }
}