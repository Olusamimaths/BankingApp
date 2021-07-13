using System;
using Xunit;
using BankingApp.Entity;
using BankingApp.Common;
using BankingApp.Roles;
using BankingApp.Utilities;

namespace BankingApp.Tests.UserTests
{
    public class UserTests
    {
        const string firstName = "Manager";
        const string lastName = "In charge of other people";
        const string phone = "+2348128921525";
        const string address = "Konibaje Avenue";
        const string email = "olusola@sam.com";

        [Fact]
        public void Creates_User()
        {
            User user = new User(firstName, lastName);
            Assert.Equal(user.FirstName, firstName);
            Assert.Equal(user.LastName, lastName);
        }

        [Fact]
        public void Creates_ID_For_User()
        {
            User user = new User(firstName, lastName);
            string userID = user.GetID();
            Assert.True(userID.GetType() == typeof(string));
        }

        [Fact]
        public void UserIDs_Must_Be_Unique()
        {
            User user = new User(firstName, lastName);
            string userID = user.GetID();

            User user2 = new User(firstName, lastName);
            string userID2 = user2.GetID();

            Assert.NotEqual(userID, userID2);
        }

        [Fact]
        public void Throws_Exception_If_Invalid_Phone_Is_Provided()
        {
            var ex = Assert.Throws<Exception>(() => new User(firstName, lastName, "+dkd"));
            Assert.Equal(ex.Message, ErrorMessages.InvalidPhone);
        }

        [Fact]
        public void Creates_User_With_Phone()
        {
            User user = new User(firstName, lastName, phone);
            Assert.Equal(user.FirstName, firstName);
            Assert.Equal(user.LastName, lastName);
            Assert.Equal(user.Phone, phone);
        }

        [Fact]
        public void Creates_User_With_Address()
        {
            User user = new User(firstName, lastName, phone, address);
            Assert.Equal(user.FirstName, firstName);
            Assert.Equal(user.LastName, lastName);
            Assert.Equal(user.Phone, phone);
            Assert.Equal(user.Address, address);
        }

        [Fact]
        public void Creates_User_With_Email()
        {
            User user = new User(firstName, lastName, phone, address, email);
            Assert.Equal(user.FirstName, firstName);
            Assert.Equal(user.LastName, lastName);
            Assert.Equal(user.Phone, phone);
            Assert.Equal(user.Address, address);
            Assert.Equal(user.EmailAddress, email);
        }

        [Fact]
        public void Assigns_Customer_Role_By_Default()
        {
            User user = new User(firstName, lastName);
            RoleBase userRole = user.Role;
            Assert.Equal(userRole.Title, RolesTitle.Customer);
            Assert.Equal(userRole.Description, RolesDescription.Customer);
        }
        [Fact]
        public void Assigns_A_New_Role()
        {
            User user = new User(firstName, lastName);
            RoleBase employeeRole = new Employee();
            user.SetRole(employeeRole);

            RoleBase userRole = user.Role;

            Assert.Equal(userRole.Title, RolesTitle.Employee);
            Assert.Equal(userRole.Description, RolesDescription.Employee);
        }

        [Fact]
        public void Gets_FullName()
        {
            User user = new User(firstName, lastName);
            string fullName = user.GetFullName();
            Assert.Equal(fullName, firstName + " " + lastName);
        }
    }
}