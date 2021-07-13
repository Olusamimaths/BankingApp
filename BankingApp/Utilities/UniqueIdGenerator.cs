
using System;

namespace BankingApp.Utilities
{
    public class UniqueIdGenerator
    {
       public static string GenerateNewId() {
           return Guid.NewGuid().ToString("N");
       }
    }
}