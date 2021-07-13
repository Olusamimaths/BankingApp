using BankingApp.Utilities;
using BankingApp.Common;
using BankingApp.Roles;
using System;

namespace BankingApp.Entity
{
    public class User : BasicEntity
    {
        private string ID;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public RoleBase Role { get; private set; }

        public User(string firstName, string lastName)
        {
            ID = UniqueIdGenerator.GenerateNewId();
            Role = new Customer();
            FirstName = firstName;
            LastName = lastName;
        }

        public User(string firstName, string lastName, string phone) : this(firstName, lastName)
        {
            if (!Validator.IsValidPhoneNumber(phone))
            {
                throw new Exception(ErrorMessages.InvalidPhone);
            }
            Phone = phone;
        }

        public User(string firstName, string lastName, string phone, string address) : this(firstName, lastName, phone)
        {
            Address = address;
        }
        public User(string firstName, string lastName, string phone, string address, string emailAddress) : this(firstName, lastName, phone, address)
        {
            EmailAddress = emailAddress;
        }
        public override string GetID()
        {
            return ID;
        }

        public void SetRole(RoleBase newRole)
        {
            Role = newRole;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}