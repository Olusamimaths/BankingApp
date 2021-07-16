using BankingApp.Utilities;
using BankingApp.Common;
using BankingApp.Roles;
using System;

namespace BankingApp.Entity
{

    /// <summary>
    /// Represents the User of the Bank
    /// </summary>
    public class User : BasicEntity
    {
        private string ID;

        /// <summary>
        /// Sets and gets user's first name
        /// </summary>
        /// <value>string</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Sets and gets User's last name
        /// </summary>
        /// <value>string</value>
        public string LastName { get; set; }

        /// <summary>
        /// Sets and gets User's phone number
        /// </summary>
        /// <value></value>
        public string Phone { get; set; }

        /// <summary>
        /// Sets and gets User's address
        /// </summary>
        /// <value></value>
        public string Address { get; set; }

        /// <summary>
        /// Sets and gets User's email address
        /// </summary>
        /// <value></value>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets user's role
        /// </summary>
        /// <value></value>
        public RoleBase Role { get; private set; }

        /// <summary>
        /// Creats a user object and associats a unique ID with it.
        /// It also sets te role as a Customer
        /// </summary>
        /// <param name="firstName">User's first name</param>
        /// <param name="lastName">User's last name</param>
        public User(string firstName, string lastName)
        {
            ID = UniqueIdGenerator.GenerateNewId();
            Role = new Customer();
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// Creats a user object and associats a unique ID with it.
        /// </summary>
        /// <param name="firstName">User's first name</param>
        /// <param name="lastName">User's last name</param>
        /// <param name="phone">User's phone</param>
        /// <returns></returns>
        public User(string firstName, string lastName, string phone) : this(firstName, lastName)
        {
            if (!Validator.IsValidPhoneNumber(phone))
            {
                throw new Exception(ErrorMessages.InvalidPhone);
            }
            Phone = phone;
        }

        /// <summary>
        /// Creates user object and sets the following properties
        /// </summary>
        /// <param name="firstName">User's first name</param>
        /// <param name="lastName">User's last name</param>
        /// <param name="phone">User's phone number</param>
        /// <param name="address">User's address</param>
        /// <returns></returns>

        public User(string firstName, string lastName, string phone, string address) : this(firstName, lastName, phone)
        {
            Address = address;
        }

        /// <summary>
        /// Creates user objec with the followign properties
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phone"></param>
        /// <param name="address"></param>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public User(string firstName, string lastName, string phone, string address, string emailAddress) : this(firstName, lastName, phone, address)
        {
            EmailAddress = emailAddress;
        }

        /// <summary>
        /// Returns user unique ID
        /// </summary>
        /// <returns>String: user ID</returns>
        public override string GetID()
        {
            return ID;
        }

        /// <summary>
        /// Set's uer role
        /// </summary>
        /// <param name="newRole">RoleBase: New role of user</param>
        public void SetRole(RoleBase newRole)
        {
            Role = newRole;
        }

        /// <summary>
        /// Returns the full name of the user
        /// </summary>
        /// <returns>String: User full name</returns>
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}