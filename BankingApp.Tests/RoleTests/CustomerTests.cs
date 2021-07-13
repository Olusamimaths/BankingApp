using System;
using Xunit;
using BankingApp.Roles;
using BankingApp.Common;

namespace BankingApp.Tests.RoleTests
{
    public class CustomerTests
    {
        [Fact]
        public void Creates_Customer_Role()
        {
            Customer customer = new Customer();
            Assert.Equal(customer.Title, RolesTitle.Customer);
            Assert.Equal(customer.Description, RolesDescription.Customer);
        }
    }
}