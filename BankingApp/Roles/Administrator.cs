using BankingApp.Common;

namespace BankingApp.Roles
{
    /// <summary>
    /// Represents and Administrator role
    /// </summary>
    public class Administrator : RoleBase
    {
        /// <summary>
        /// Creats the administrator role
        /// </summary>
        /// <returns></returns>
        public Administrator() : base(RolesTitle.Administrator, RolesDescription.Administrator) { }
    }
}