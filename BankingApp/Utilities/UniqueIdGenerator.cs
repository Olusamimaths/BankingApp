
using System;

namespace BankingApp.Utilities
{
    /// <summary>
    /// Unique ID generator
    /// </summary>
    public class UniqueIdGenerator
    {
        /// <summary>
        /// Generates unique random strings
        /// </summary>
        /// <returns></returns>
       public static string GenerateNewId() {
           return Guid.NewGuid().ToString("N");
       }
    }
}