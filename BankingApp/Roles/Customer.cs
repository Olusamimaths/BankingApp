using BankingApp.Common;

namespace BankingApp.Roles
{
    /// <summary>
    /// Represents a  Customer Role
    /// </summary>
    public class Customer : RoleBase
    {
        /// <summary>
        /// Creates the customer role
        /// </summary>
        public Customer() : base(RolesTitle.Customer, RolesDescription.Customer) {}
    }
}