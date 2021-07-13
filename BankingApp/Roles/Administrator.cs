using BankingApp.Common;

namespace BankingApp.Roles
{
    public class Administrator : RoleBase
    {
       public Administrator() : base(RolesTitle.Administrator, RolesDescription.Administrator) {}
    }
}