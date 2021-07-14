using BankingApp.Entity;
namespace BankingApp.Accounts
{
    public class StudentAccount : Account
    {
        public string StudentID { get; private set; }
        public StudentAccount(User user, string studentID) : base(user) {
            StudentID = studentID;
        }
    }
}