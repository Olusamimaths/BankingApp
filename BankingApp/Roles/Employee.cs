using BankingApp.Common;

namespace BankingApp.Roles
{
    /// <summary>
    /// Represents and Employee role
    /// </summary>
    public class Employee : RoleBase
    {
        /// <summary>
        /// Creates the employee role
        /// </summary>
        /// <returns></returns>
        public Employee() : base(RolesTitle.Employee, RolesDescription.Employee) {}
    }
}