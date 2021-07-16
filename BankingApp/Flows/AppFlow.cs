using System;
using BankingApp.Accounts;
using BankingApp.Entity;
using System.Collections.Generic;
using BankingApp.Transactions;

namespace BankingApp.Flows
{
    /// <summary>
    /// Defines the flow of the application
    /// </summary>
    public class AppFlow
    {
        private static Account CurrentUserAccount;
        
        // holds the list of accounts created since app startup
        private static List<Account> accounts = new List<Account>();

        /// <summary>
        /// Starts up the banking app
        /// </summary>
        public static void StartUp()
        {
            ShowWelcomeScreen();
            Console.Write("> ");
            int selectedOption = 0;
            try
            {
                selectedOption = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.Exception)
            {
                Console.WriteLine("Failed. Wrong Input, try again.");
                StartUp();
            }

            // Create Account
            if (selectedOption == 1)
            {
                HandleCreateAccount();
            }
            // check balance
            else if (selectedOption == 2)
            {
                HandleCheckAccountBalance();
            }
            // transfer
            else if (selectedOption == 3)
            {
                HandleTransfer();
            }
            // widthdrawal
            else if (selectedOption == 4)
            {
                HandleWithdrawal();
            }
            // deposit
            else if (selectedOption == 5)
            {
                HandleDeposit();
            } else {
                Console.WriteLine("Wrong option provided");
                StartUp();
            }
        }

        // handles the deposit operation
        private static void HandleDeposit() {
                // collect amount to deposit and target account from user
                decimal depositAmount = 0;
                long targetAccountNumber = 0;
                Account targetAccount = null;
                try
                {
                    Console.Write("> Input amount to deposit: ");
                    depositAmount = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("> Input account number to deposit to: ");
                    targetAccountNumber = Convert.ToInt64(Console.ReadLine());
                    targetAccount = FindAccountByAccountNumber(accounts, targetAccountNumber);
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Failed. Wrong Input");
                    StartUp(); ;
                }

                DepositTransaction depositTransaction = new DepositTransaction();

                depositTransaction.SetDestinationAccount(targetAccount);
                depositTransaction.DepositToDestinationOrFail(depositAmount);

                Console.WriteLine("\n\nTransaction completed");
                PrintDarkGreenText("You have deposited " + depositAmount + " to account number " + targetAccountNumber);

                StartUp();
        }

        // handles the withdrawal operation of the banking app
        private static void HandleWithdrawal()
        {
            long accountNumber = 0;
            Account foundAccount = null;
            decimal withdrawAmount = 0;
            try
            {
                Console.Write("> Input your account number: ");
                accountNumber = Convert.ToInt64(Console.ReadLine());
                foundAccount = FindAccountByAccountNumber(accounts, accountNumber);

                Console.Write("> Input amount to withdraw: ");
                withdrawAmount = Convert.ToDecimal(Console.ReadLine());
            }
            catch (System.Exception)
            {
                Console.WriteLine("Failed. Wrong Input");
                StartUp();

            }

            if (foundAccount == null)
            {
                Console.WriteLine("Account with account number provided was not found.");
                StartUp();
            }
            else
            {
                WithdrawalTransaction withdrawalTransaction = new WithdrawalTransaction(foundAccount);
                try
                {
                    withdrawalTransaction.WithdrawalOrThrow(withdrawAmount);
                    Console.WriteLine("\n\nTransaction completed");
                    PrintDarkGreenText("You have withdrawn " + withdrawAmount);
                    Console.WriteLine("\nRemaining  balance is " + foundAccount.GetBalance());

                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                finally
                {
                    StartUp();
                }
            }
        }

        // handles the transfer operationof the bank
        private static void HandleTransfer()
        {
            Account userAccount = null;
            Account targetAccount = null;
            decimal transferAmount = 0;

            try
            {
                Console.Write("> Input your account number: ");
                long userAccountNumber = Convert.ToInt64(Console.ReadLine());
                userAccount = FindAccountByAccountNumber(accounts, userAccountNumber);
                PrintDarkGreenText("You current balance is " + userAccount.GetBalance());

                Console.Write("> Input target account number: ");
                long targetAccountNumber = Convert.ToInt64(Console.ReadLine());
                targetAccount = FindAccountByAccountNumber(accounts, targetAccountNumber);

                Console.Write("> Input amount to transfer: ");
                transferAmount = Convert.ToDecimal(Console.ReadLine());
            }
            catch (System.Exception)
            {

                Console.WriteLine("Failed. Wrong Input");
                StartUp();
            }
            
            TransferTransaction transferTransaction = new TransferTransaction(userAccount);
            try
            {
                transferTransaction.TransferOrThrow(targetAccount, transferAmount);
                PrintDarkGreenText("Transfer successful. You balance is now " + userAccount.GetBalance());
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                StartUp();
            }
        }

        // handles the check account balance opertion
        private static void HandleCheckAccountBalance()
        {
            long accountNumber = 0;
            Account foundAccount = null;
            try
            {
                Console.Write("> Input your account number: ");
                accountNumber = Convert.ToInt64(Console.ReadLine());
                foundAccount = FindAccountByAccountNumber(accounts, accountNumber);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Failed. Wrong Input");
                StartUp(); ;
            }

            if (foundAccount == null)
            {
                Console.WriteLine("Account with account number provided was not found.");
                HandleCreateAccount();
            }
            else
            {
                PrintDarkGreenText("Your account balance is " + foundAccount.GetBalance());
                StartUp();
            }

        }

        /// <summary>
        /// It finds an account from a list of accounts when provided the list and an account number
        /// returns null if account was not found
        /// </summary>
        /// <param name="accounts">List of accounts to search</param>
        /// <param name="accountNumber">Account number of account to search</param>
        /// <returns></returns>
        public static Account FindAccountByAccountNumber(List<Account> accounts, long accountNumber)
        {
            if (accounts.Count > 0)
            {
                foreach (Account account in accounts)
                {
                    if (account.GetAccountNumber() == accountNumber)
                    {
                        return account;
                    }
                }
            }
            return null;
        }
        private static void HandleCreateAccount()
        {
            Account account = null;
            PrintDarkGreenText("\n\n What type of account do you want to create?\n\n");

            Console.WriteLine("{0,-50} {1,5}\n", "> 1. Student Account", "> 2. Savings Account");
            Console.WriteLine("{0,-50}\n", "> 3. Current Account");

            int selectedAccountOption = 0;
            string firstName = "";
            string lastName = "";
            string input = "";
            try
            {
                Console.Write("> Input your account number: ");
                selectedAccountOption = Convert.ToInt32(Console.ReadLine());

                Console.Write("> Input your first name *: ");
                firstName = Console.ReadLine();

                Console.Write("> Input your last name *: ");
                lastName = Console.ReadLine();

                Console.Write("Do you want to deposit an initial amount? Y/N: ");
                input = Console.ReadLine();
            }
            catch (System.Exception)
            {
                Console.WriteLine("Failed. Wrong Input");
                StartUp(); ;
            }

            decimal startingAmount = 0;

            if (input == "Y" || input == "y")
            {
                Console.Write("\n\n> Input starting amount: ");
                startingAmount = Convert.ToDecimal(Console.ReadLine());
            }

            if (selectedAccountOption == 1)
            {
                Console.Write("> Input your student ID number *: ");
                string studentID = Console.ReadLine();

                User user = new User(firstName, lastName);
                account = new StudentAccount(user, studentID, startingAmount);
                Console.WriteLine("\n\nCongratulations, a Student Account has been created for you");

            }
            else if (selectedAccountOption == 2 || selectedAccountOption == 3)
            {
                User user = new User(firstName, lastName);

                if (selectedAccountOption == 2)
                {
                    account = new SavingsAccount(user, startingAmount);
                    Console.WriteLine("\n\nCongratulations, a Savings Account has been created for you");
                }
                else
                {
                    account = new CurrentAccount(user, startingAmount);
                    Console.WriteLine("\n\nCongratulations, a Current Account has been created for you");

                }
            }

            PrintAccountNumber(account);
            // add new account to accounts list
            accounts.Add(account);

            CurrentUserAccount = account;
            StartUp();
        }

        private static void ShowWelcomeScreen()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t\t\t________________________");
            Console.WriteLine("\n\t\t\tWelcome to Kopoke Bank");
            Console.WriteLine("\t\t\t________________________\n");

            PrintDarkGreenText(" Select an option\n");

            Console.WriteLine("{0,-50} {1,5}\n", "> 1. Create Account", "> 2. Check Balance");
            Console.WriteLine("{0,-50} {1,5}\n", "> 3. Transfer", "> 4. Withdrawal");
            Console.WriteLine("{0,-50}", "> 5. Deposit");
        }

        private static void PrintDarkGreenText(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void PrintAccountNumber(Account account)
        {
            Console.Write("Here is your account number: ");
            PrintDarkGreenText("" + account.GetAccountNumber());
        }
    }
}