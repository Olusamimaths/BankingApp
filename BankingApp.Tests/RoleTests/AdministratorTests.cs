using System;
using Xunit;
using BankingApp.Roles;
using BankingApp.Common;

namespace BankingApp.Tests.RoleTests
{
    public class AdministratorTests
    {
        [Fact]
        public void Creates_Administrator_Role()
        {
            Administrator administrator = new Administrator();
            Assert.Equal(administrator.Title, RolesTitle.Administrator);
            Assert.Equal(administrator.Description, RolesDescription.Administrator);
        }
    }
}