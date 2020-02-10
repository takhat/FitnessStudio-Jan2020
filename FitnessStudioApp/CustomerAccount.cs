using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessStudioApp
{
    class CustomerAccount
    {

        #region Properties
        private static int lastCustomerID = 0;
        public int CustomerID { get; private set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        //public DateFormat DateofBirth { get; set; }
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

    } 
}

