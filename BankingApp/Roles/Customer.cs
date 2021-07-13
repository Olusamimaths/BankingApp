using BankingApp.Common;

namespace BankingApp.Roles
{
    public class Customer : RoleBase
    {
       public Customer() : base(RolesTitle.Customer, RolesDescription.Customer) {}
    }
}