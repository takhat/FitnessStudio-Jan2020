using Microsoft.VisualBasic;
        
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FitnessStudioApp
{
    static class FitnessStudio
    {
        private static List<CustomerAccount> customerAccounts = new List<CustomerAccount>();
        private static List<Classes> fitnessClasses = new List<Classes>();
      
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
        public static Classes CreateClass(
            TitleofClass classTitle,
            string classDescription,
            int minimumAge,
            DayOfWeek daysClassOffered,
            string classTimings,
            DateTime startDate,
            DateTime endDate,
            string instructor,
            int classSize,
            int spacesAvailable)
        {
            //Object initialization
            var fitnessclass = new Classes
            {
                ClassTitle = classTitle,
                ClassDescription = classDescription,
                MinimumAge = minimumAge,
                DaysClassOffered = daysClassOffered,
                ClassTimings = classTimings,
                StartDate = startDate,
                EndDate = endDate,
                Instructor = instructor,
                ClassSize = classSize,
                SpacesAvailable = spacesAvailable
            };
            fitnessClasses.Add(fitnessclass);
            return fitnessclass;
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
            string customerAddress,
            string customerPhone,
            //DateFormat dateOfBirth,
            TitleofClass classTitle,
            TypeOfMembership membershipType)
        {
            //Object initialization
            var customerAccount = new CustomerAccount
            {
                CustomerName = customerName,
                CustomerAddress = customerAddress,
                CustomerPhone = customerPhone,
                //DateofBirth = dateOfBirth,
                ClassTitle = classTitle,
                MembershipType = membershipType
            };
            customerAccounts.Add(customerAccount);
            return customerAccount;
        }
     
    }
}


      
    

    
        
        

        