using System;
using Xunit;
using BankingApp.Roles;
using BankingApp.Common;

namespace BankingApp.Tests.RoleTests
{
    public class EmployeeTests
    {
        [Fact]
        public void Creates_Employee_Role()
        {
            Employee employee = new Employee();
            Assert.Equal(employee.Title, RolesTitle.Employee);
            Assert.Equal(employee.Description, RolesDescription.Employee);
        }
    }
}