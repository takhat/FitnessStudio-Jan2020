using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace FitnessStudioApp
{
    /// <summary>
    /// Class pass types and respective prices in USD
    /// </summary>
    public enum ClassPassOption
    {
        FreeTrial = 0,
        SingleClassPass = 20,
        TenClassPass = 180,
        TwentyClassPass = 350, 
    };

    /// <summary>
    /// Membership options and respective prices in USD
    /// </summary>
    public enum MembershipOption
    {
        OneWeekUnlimitedFreeTrial = 0,
        MonthlyUnlimitedClasses = 200,
        QuarterlyUnlimitedClasses = 500,
        SixMonthsUnlimitedClasses = 900,
        AnnualUnlimitedClasses = 1600
    };

    public class CustomerAccount
    {
        #region Properties

        /// <summary>
        /// Unique Customer ID auto generated
        /// </summary>
        public int CustomerID { get; set; }
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
        public TitleOfClass ClassTitle { get; set; }
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
            CustomerSince = DateTime.UtcNow;
        }
        #endregion
        #region Methods
        public void BuyAClassPass
            (TitleOfClass className, ClassPassOption classPassType)

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

