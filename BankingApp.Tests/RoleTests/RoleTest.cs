using System;
using Xunit;
using BankingApp.Roles;

namespace BankingApp.Tests.RoleTests
{
    public class RoleTest
    {
        const string title = "Manager";
        const string description = "In charge of other people";
        [Fact]
        public void Sets_Role_Title_And_Description_On_Creation()
        {
            RoleBase role = new RoleBase(title, description);
            Assert.Equal(role.Title, title);
            Assert.Equal(role.Description, description);
        }

        [Fact]
        public void Generates_String_Id_For_Role() {
            RoleBase role = new RoleBase(title, description);
            string roleId = role.GetID();
            Assert.True(roleId.GetType() == typeof(string));
        }

        [Fact]
        public void Ids_Should_Be_Unique()
        {
            RoleBase role1 = new RoleBase(title, description);
            RoleBase role2 = new RoleBase("different title", "different description");

            string role1Id = role1.GetID();
            string role2Id = role2.GetID();
            
            Assert.True(role1Id != role2Id);
        }
    }
}
