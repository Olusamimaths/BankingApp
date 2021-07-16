using System;
using Xunit;
using BankingApp.Entity; 
using BankingApp.Accounts; 
using BankingApp.Utilities;
using BankingApp.Transactions;

namespace BankingApp.Tests.TransactionsTests
{
    public class TransferTransactionTests
    {
        Account account = new Account(new User("Sam", "Tobi"));
        Account account2 = new Account(new User("Sam", "Tobi"));
        decimal amount = 2000;


        [Fact]
        public void Transfer_Fails_If_Account_Is_Unfunded()
        {
            TransferTransaction transferTransaction = new TransferTransaction(account);

            var ex = Assert.Throws<Exception>(() => transferTransaction.TransferOrThrow(account2, amount));
            Assert.Equal(ex.Message, ErrorMessages.TransferUnfundedAccount);
        }

        [Fact]
        public void Transfer_Fails_If_Balance_Is_Insufficient()
        {
            TransferTransaction transferTransaction = new TransferTransaction(account);
            transferTransaction.LinkedAccount.DepositOrThrow(amount-100);

            var ex = Assert.Throws<Exception>(() => transferTransaction.TransferOrThrow(account2, amount));
            Assert.Equal(ex.Message, ErrorMessages.InsufficientBalance);
        }

        [Fact]
        public void Transfer_Fails_If_Balance_Will_Go_Below_Min_Balance()
        {
            TransferTransaction transferTransaction = new TransferTransaction(account);
            transferTransaction.LinkedAccount.DepositOrThrow(account.MinimumBalance + amount - 100);

            var ex = Assert.Throws<Exception>(() => transferTransaction.TransferOrThrow(account2, amount));
            Assert.Equal(ex.Message, ErrorMessages.TransferBalanceBelowMin);
        }

        [Fact]
        public void Transfers_To_Destination()
        {
            TransferTransaction transferTransaction = new TransferTransaction(account);
            transferTransaction.LinkedAccount.DepositOrThrow(amount);

            decimal amountToTransfer = 100;
            decimal destinationInitialBalance = account2.GetBalance();
            transferTransaction.TransferOrThrow(account2, amountToTransfer);

            decimal destinationFinalBalance = account2.GetBalance();

            Assert.Equal(destinationFinalBalance, Decimal.Add(destinationInitialBalance, amountToTransfer));

        }

        [Fact]
        public void Deducts_From_Balance_After_Transfer()
        {
            TransferTransaction transferTransaction = new TransferTransaction(account);
            transferTransaction.LinkedAccount.DepositOrThrow(amount);

            decimal amountToTransfer = 100;
            decimal initialBalance = transferTransaction.LinkedAccount.GetBalance();
            transferTransaction.TransferOrThrow(account2, amountToTransfer);

            decimal finalBalance = transferTransaction.LinkedAccount.GetBalance();

            Assert.Equal(finalBalance, Decimal.Subtract(initialBalance, amountToTransfer));
        }
    }
}