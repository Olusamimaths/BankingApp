namespace BankingApp.Accounts
{
    public class StudentAccount : Account
    {
        public string StudentID { get; private set; }
        public StudentAccount(string userID, string studentID) : base(userID) {
            StudentID = studentID;
        }
    }
}