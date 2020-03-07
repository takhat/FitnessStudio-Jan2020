using Microsoft.VisualBasic;
        
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Transactions;

namespace FitnessStudioApp
{
    static class FitnessStudio
    {
        private static List<CustomerAccount> customerAccounts = new List<CustomerAccount>();
        private static List<FitnessClass> fitnessClasses = new List<FitnessClass>();
        private static List<Transaction> transactions = new List<Transaction>();

        /// <summary>
        /// Create a new FitnessClass
        /// </summary>
        /// <param name="classTitle">Select a Class Title</param>
        /// <param name="classDescription">Enter a detailed class description</param>
        /// <param name="minimumAge">Minimum Age requirement to participate in class</param>
        /// <param name="daysClassOffered">Days Class is offered</param>
        /// <param name="classTimings">Class Time</param>
        /// <param name="startDate">Class Start Date</param>
        /// <param name="endDate">Class End Date</param>
        /// <param name="instructor">Instructor Name</param>
        /// <param name="classSize">Maximum number of participants allowed</param>
        /// <param name="spacesAvailable">Number of Spaces available</param>
        /// <returns>creates a new fitness class</returns>
        public static FitnessClass CreateClass(
            TitleofClass classTitle,
            string classDescription,
            int minimumAge,
            DayOfWeek daysClassOffered,
            string classTimings,
            string startDate,
            string endDate,
            string instructor,
            int classSize=20
            )
        {
            //Object initialization
            var fitnessClass = new FitnessClass
            {
                ClassTitle = classTitle,
                ClassDescription = classDescription,
                MinimumAge = minimumAge,
                DaysClassOffered = daysClassOffered,
                ClassTimings = classTimings,
                StartDate = startDate,
                EndDate = endDate,
                Instructor = instructor,
                ClassSize = classSize
                
            };
            fitnessClasses.Add(fitnessClass);
            return fitnessClass;
        }
        /// <summary>
        /// Creates a new Customer Account
        /// </summary>
        /// <param name="customerName">First and Last Name</param>
        /// <param name="customerAddress">Mailing Address</param>
        /// <param name="customerPhone">Phone Number</param>
        /// <param name="dateOfBirth">Date of Birth</param>
        /// <param name="classTitle">Select a Class Title</param>
        /// <param name="membershipType">Select a Membership Type</param>
        /// <returns>Newly created Account</returns>
        public static CustomerAccount CreateAccount(
        string customerName,
            string emailAddress,
            string customerPhone,
            string dateOfBirth
            )
        {
            //Object initialization
            var customerAccount = new CustomerAccount
            {
                CustomerName = customerName,
                EmailAddress = emailAddress,
                CustomerPhone = customerPhone,
                DateofBirth = dateOfBirth,
            };
            
            customerAccounts.Add(customerAccount);
            return customerAccount;
        }
        public static void BuyAClassPass(int customerID, TitleofClass className, ClassPassOption classPassType)

        {

            var customerAccount = customerAccounts.SingleOrDefault(a => a.CustomerID == customerID);

            if (customerAccount == null)

            {

                //Exception Handling here

                return;

            }
            customerAccount.BuyAClassPass(className, classPassType);
        }
        public static void BuyAMembership(int customerID, MembershipOption membershipOption)

        {

            var customerAccount = customerAccounts.SingleOrDefault(a => a.CustomerID == customerID);

            if (customerAccount == null)

            {

                //Exception Handling here

                return;

            }
            customerAccount.BuyAMembership(membershipOption);
        }
        public static void createTransaction(decimal amount, int customerID, TypeOfTransaction transactionType, string description = "")
        {
            var transaction = new Transaction
            {
                TransactionDate = DateTime.UtcNow,
                Description = description,
                Amount = amount,
                CustomerID = customerID,
                TransactionType = transactionType
            };
            transactions.Add(transaction);
        }
    }
}


      
    

    
        
        

        