using BankingApp.Utilities;
using BankingApp.Common;

namespace BankingApp.Roles
{
    public class RoleBase : BasicEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        private string ID;
        public RoleBase(string title, string description) {
            Title = title;
            Description = description;
            ID = UniqueIdGenerator.GenerateNewId();
        }

        public override string GetID() {
            return ID;
        }
    }
}