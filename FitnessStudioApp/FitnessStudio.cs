using Microsoft.VisualBasic;
        
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Transactions;
using System.ComponentModel.DataAnnotations;

namespace FitnessStudioApp
{
    public static class FitnessStudio
    {
        private static FitnessStudioContext db = new FitnessStudioContext();
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
            db.FitnessClasses.Add(fitnessClass);
            db.SaveChanges();
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
            DateTime dateOfBirth
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
            
            db.CustomerAccounts.Add(customerAccount);
            db.SaveChanges();
            return customerAccount;
        }
        /// <summary>
        /// Buy a class Pass
        /// </summary>
        /// <param name="customerID">Unique Customer ID</param>
        /// <param name="className">Class Name</param>
        /// <param name="classPassType">Class Pass buying options</param>
        /// <exception cref="ArgumentException"/>
        public static void BuyAClassPass(int customerID, TitleofClass className, ClassPassOption classPassType)

        {


            var classPassAmounts = (int[])Enum.GetValues(typeof(ClassPassOption));
            var classPassAmount = classPassAmounts[Convert.ToInt32(classPassType)]; 
            var customerAccount = db.CustomerAccounts.SingleOrDefault(a => a.CustomerID == customerID);

            if (customerAccount == null)

            {
                throw new ArgumentException("Customer ID is invalid. Try again!");
            }
            customerAccount.BuyAClassPass(className, classPassType);
            createTransaction(classPassAmount, customerID, TypeOfTransaction.ClassPass);
            db.SaveChanges();
        }
        
        /// <summary>
        /// Buy a Membership
        /// </summary>
        /// <param name="customerID">Unique Customer ID</param>
        /// <param name="membershipOption">Membership Types</param>
        /// <exception cref="ArgumentException"/>
        public static void BuyAMembership(int customerID, MembershipOption membershipOption)

        {
            var membershipAmounts = (int[])Enum.GetValues(typeof(MembershipOption));
            var membershipAmount = membershipAmounts[Convert.ToInt32(membershipOption)];
            var customerAccount = db.CustomerAccounts.SingleOrDefault(a => a.CustomerID == customerID);

            if (customerAccount == null)

            {
                throw new ArgumentException("Customer ID is invalid. Try again!");
            }
            customerAccount.BuyAMembership(membershipOption);
            createTransaction(membershipAmount, customerID, TypeOfTransaction.Membership);
            db.SaveChanges();
        }
        public static void createTransaction(decimal amount, int customerID, TypeOfTransaction transactionType, string description = "")
        {
            var transaction = new Transaction
            {
                TransactionDate = DateTime.UtcNow,
                Description = description,
                Amount = amount,
                CustomerID = customerID,
                TransactionType = transactionType,
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
        public static IEnumerable<Transaction> GetAllTransactionsByCustomerID(int customerID)
        {
            return db.Transactions.Where(t => t.CustomerID == customerID).OrderByDescending(t => t.TransactionDate);
        }
        public static IEnumerable<CustomerAccount> GetAccountInfoByEmailAddress(string emailAddress)
        {
            return db.CustomerAccounts.Where(a => a.EmailAddress == emailAddress);
        }
        public static IEnumerable<CustomerAccount> GetAccountInfoByCustomerID(int customerID)
        {
            return db.CustomerAccounts.Where(a => a.CustomerID == customerID);
        }
    }
}


      
    

    
        
        

        