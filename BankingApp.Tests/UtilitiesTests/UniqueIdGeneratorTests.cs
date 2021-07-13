using System;
using Xunit;
using BankingApp.Utilities;

namespace BankingApp.Tests.UtilitiesTests
{
    public class UniqueIdGeneratorTests
    {
        [Fact]
        public void Generates_String_Id() {
            string id = UniqueIdGenerator.GenerateNewId();
            Assert.True(id.GetType() == typeof(string));
        }

        [Fact]
        public void Generated_Ids_Should_Be_Unique() {
            string id1 = UniqueIdGenerator.GenerateNewId();
            string id2 = UniqueIdGenerator.GenerateNewId();
            Assert.True(id1 != id2);
        }
    }
}