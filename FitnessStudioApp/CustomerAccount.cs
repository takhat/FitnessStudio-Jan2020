using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessStudioApp
{
    enum YesNo
    {
        Yes,
        No
    };
    enum ClassPassOption
    {
        FreeTrial = 0,
        SingleClassPass = 20,
        TenClassPass = 180,
        TwentyClassPass = 350, 
    };

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
        private static int lastCustomerID = 0;
        public int CustomerID { get; private set; }
        public string CustomerName { get; set; }
        public string EmailAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string DateofBirth { get; set; }
        public TitleofClass ClassTitle { get; set; }
        public ClassPassOption TypeOfClassPass { get; set; }
        public MembershipOption TypeOfMembership { get; set; }
        public DateTime MembershipExpires { get; set; }
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
         
        }


        #endregion

    }
}

