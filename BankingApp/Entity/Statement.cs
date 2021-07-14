using BankingApp.Common;

namespace BankingApp.Entity
{
    public class Statement : BasicEntity
    {
        private string ID;

        public Statement() {
            
        }

        public override string GetID()
        {
            return ID;
        }
        
    }
}