using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessStudioApp
{
    enum TitleofClass
    {
        CrossFit,
        HathaYoga,
        MatPilates,
        PowerYoga,
        Swimming,
        ZumbaFitness,
        FlexFit
    };
    enum TypeOfMembership
    {
        FreeTrial = 0,
        SingleClassPass = 20,
        TenClassPass = 180,
        TwentyClassPass = 350,
        MonthlyFlexFitPass = 200,
        QuarterlyFlexFitPass = 500,
        AnnualFlexFitPass = 900
    };
    class CustomerAccount
    {
        

        #region Properties
        private static int lastCustomerID = 0;
        public int CustomerID { get; private set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string DateofBirth { get; set; }
        //public int ClassID { get; set; }
        public TitleofClass ClassTitle { get; set; }
        public TypeOfMembership MembershipType { get; set; }
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
        public void SignUp(TitleofClass ClassName, TypeOfMembership Price)

        {
            ClassTitle = ClassName;
            MembershipType = Price;
        }
        #endregion

    }
}

