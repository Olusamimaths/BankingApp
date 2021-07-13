using BankingApp.Common;

namespace BankingApp.Roles
{
    public class Employee : RoleBase
    {
       public Employee() : base(RolesTitle.Employee, RolesDescription.Employee) {}
    }
}