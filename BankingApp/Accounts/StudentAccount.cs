using BankingApp.Entity;
using BankingApp.Utilities;

namespace BankingApp.Accounts
{
    /// <summary>
    /// Represents a student account
    /// </summary>
    public class StudentAccount : Account
    {

        /// <summary>
        /// An ID issued by an institution to a student
        /// e.g Matriculation Number
        /// </summary>
        /// <value>string</value>
        public string StudentID { get; private set; }

        private void Init(string studentID) {
            StudentID = studentID;
            this.MinimumBalance = AccountInfo.StudentAccountMinBalance;
            this.MaximumBalance = AccountInfo.StudentAccountMaxBalance;
        }

        /// <summary>
        /// Creates a student account
        /// </summary>
        /// <param name="user">Owner of the account</param>
        /// <param name="studentID">ID issued to student by institution they attend</param>
        public StudentAccount(User user, string studentID) : base(user) {
            Init(studentID);
        }

        /// <summary>
        /// Creates a student account with initial starting amount
        /// </summary>
        /// <param name="user">Owner of the account</param>
        /// <param name="studentID">ID issued to student by institution they attend</param>
        /// <param name="startingAmount">Initial amount to deposit in account</param>
        public StudentAccount(User user, string studentID, decimal startingAmount) : base(user, startingAmount) {
            Init(studentID);
        }
    }
}