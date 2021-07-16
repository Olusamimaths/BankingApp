namespace BankingApp.Common
{
    /// <summary>
    /// Defines propeties of a basic entity
    /// </summary>
    public abstract class BasicEntity
    {
        /// <summary>
        /// Gets the ID of the entity
        /// </summary>
        /// <returns>string: ID of the entity</returns>
        public abstract string GetID() ;
    }
}