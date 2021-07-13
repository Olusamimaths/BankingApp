using System;
using Xunit;
using BankingApp.Utilities;

namespace BankingApp.Tests.UtilitiesTests
{
    public class ValidatorTests
    {
        const string validPhone = "+2348128921566";
        const string validPhone2 = "+2348128921677";
        const string invalidPhone = "+234U128921566";
        const string invalidPhone2 = "+Udkfdjajdfkd";


        [Fact]
        public void True_If_Number_Has_Valid_Length() {
            bool isValid = Validator.IsValidPhoneNumber(validPhone);
            Assert.True(isValid);
            Assert.False(Validator.IsValidPhoneNumber("+234"), "Three digits phone number not valid");
            Assert.False(Validator.IsValidPhoneNumber("+23467890"), "9 digits phone number not valid");
        }

        [Fact]
        public void True_If_Phone_Has_Numbers_Only()
        {
            bool isValid = Validator.IsValidPhoneNumber(invalidPhone);
            bool isValid2 = Validator.IsValidPhoneNumber(invalidPhone2);
            bool isValid3 = Validator.IsValidPhoneNumber(validPhone2);

            Assert.False(isValid);
            Assert.False(isValid2);
            Assert.True(isValid3);
        }
    }
}