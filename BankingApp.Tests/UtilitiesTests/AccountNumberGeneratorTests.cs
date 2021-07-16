using System;
using Xunit;
using BankingApp.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace BankingApp.Tests.UtilitiesTests
{
    public class AccountNumberGeneratorTests
    {
        [Fact]
        public void Generates_10_Digits_Bank_Number() {
            long bankNumber = AccountNumberGenerator.Generate();
            Assert.True(bankNumber.GetType() == typeof(long));
            Assert.True(bankNumber.ToString().Length == 10);
        }

        [Fact]
        public void Generated_Bank_Number_Must_Begin_With_Bank_Prefix() {
            long bankNumber = AccountNumberGenerator.Generate();
            long prefix = bankNumber / (long)Math.Pow(10, 8);

            Assert.True(prefix == (long)AccountNumberGenerator.Prefix);
        }

        [Fact]
        public void Returns_List_Of_10_digits_Numbers()
        {
            for(int i = 0; i < 10; i++) {
                AccountNumberGenerator.Generate();
            }
            ReadOnlyCollection<long> bankNumbers = AccountNumberGenerator.GetAllBankNumbers();
            foreach(long bankNumber in bankNumbers) {
                Assert.True(bankNumber.ToString().Length == 10);
            }
        }

        [Fact]
        public void BankNumbersList_Contains_Unique_Elements()
        {
            ReadOnlyCollection<long> bankNumbers = AccountNumberGenerator.GetAllBankNumbers();
            
            List<long> list = new List<long>(bankNumbers);
            bool isUnique = list.Distinct().Count() == bankNumbers.Count();
            
            Assert.True(isUnique);
        }
        
    }
}