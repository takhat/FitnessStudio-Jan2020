using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace FitnessStudioApp
{
    enum YesNo
    {
        Yes,
        No
    };
    /// <summary>
    /// Class pass types and respective prices in USD
    /// </summary>
    enum ClassPassOption
    {
        FreeTrial = 0,
        SingleClassPass = 20,
        TenClassPass = 180,
        TwentyClassPass = 350, 
    };

    /// <summary>
    /// Membership options and respective prices in USD
    /// </summary>
    enum MembershipOption
    {
        OneWeekUnlimitedFreeTrial = 0,
        MonthlyUnlimitedClasses = 200,
        QuarterlyUnlimitedClasses = 500,
        SixMonthsUnlimitedClasses = 900,
        AnnualUnlimitedClasses = 1600
    };

    class CustomerAccount
    {
        #region Properties
        /// <summary>
        /// Constructor variable
        /// </summary>
        private static int lastCustomerID = 0;
        /// <summary>
        /// Unique Customer ID auto generated
        /// </summary>
        public int CustomerID { get; private set; }
        /// <summary>
        /// Customer First and Last Name
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Customer email address
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Customer phone number
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// Customer Date of birth
        /// </summary>
        public DateTime DateofBirth { get; set; }
        /// <summary>
        /// Class Types
        /// </summary>
        public TitleofClass ClassTitle { get; set; }
        /// <summary>
        /// Class Pass types
        /// </summary>
        public ClassPassOption TypeOfClassPass { get; set; }
        /// <summary>
        /// Membership Types
        /// </summary>
        public MembershipOption TypeOfMembership { get; set; }
        /// <summary>
        /// Membership Expiration Date
        /// </summary>
        public DateTime MembershipExpires { get; set; }
        /// <summary>
        /// Customer Account Created Date
        /// </summary>
        public DateTime CustomerSince { get; set; }
        #endregion
        #region Constructor
        public CustomerAccount()
        {
            CustomerID = ++lastCustomerID;
            CustomerSince = DateTime.UtcNow;
        }
        #endregion
        #region Methods
        public void BuyAClassPass
            (TitleofClass className, ClassPassOption classPassType)

        {
            ClassTitle = className;
            TypeOfClassPass = classPassType;

        }

        public void BuyAMembership(MembershipOption membershipOption)
        {
            TypeOfMembership = membershipOption;
            if (membershipOption == MembershipOption.AnnualUnlimitedClasses)
            {
                MembershipExpires = DateTime.UtcNow.AddYears(1);
            }
            else if (membershipOption == MembershipOption.MonthlyUnlimitedClasses)
            {
                MembershipExpires = DateTime.UtcNow.AddMonths(1);
            }
            else if (membershipOption == MembershipOption.OneWeekUnlimitedFreeTrial)
            {
                MembershipExpires = DateTime.UtcNow.AddDays(7);
            }
            else if (membershipOption == MembershipOption.QuarterlyUnlimitedClasses)
            {
                MembershipExpires = DateTime.UtcNow.AddMonths(3);
            }
            else if (membershipOption == MembershipOption.SixMonthsUnlimitedClasses)
            { 
                MembershipExpires = DateTime.UtcNow.AddMonths(6);
            } 
        }

    #endregion
}
}

