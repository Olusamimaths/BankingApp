using BankingApp.Utilities;
using BankingApp.Common;

namespace BankingApp.Roles
{
    /// <summary>
    /// Represents the base Role class
    /// </summary>
    public class RoleBase : BasicEntity
    {
        /// <summary>
        /// Gets Title of the role
        /// </summary>
        /// <value></value>
        public string Title { get; private set; }

        /// <summary>
        /// Gets Description of the role
        /// </summary>
        /// <value></value>
        public string Description { get; private set; }
        private string ID;

        /// <summary>
        /// Creates base role class setting the following properties
        /// Alongside a unique ID for the role
        /// </summary>
        /// <param name="title">String: Title of the role</param>
        /// <param name="description">String: Description of the role</param>
        public RoleBase(string title, string description) {
            Title = title;
            Description = description;
            ID = UniqueIdGenerator.GenerateNewId();
        }

        /// <summary>
        /// Gets the ID of the role
        /// </summary>
        /// <returns>String: ID of the role</returns>
        public override string GetID() {
            return ID;
        }
    }
}