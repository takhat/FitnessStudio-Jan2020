using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace FitnessStudioApp
{

    public enum TypeOfTransaction
    {
        ClassPass,
        Membership
    }


    public class Transaction

    {
        private static int lastTransactionID = 0;
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public TypeOfTransaction TransactionType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int CustomerID { get; set; }


        public Transaction()
        {
            TransactionID = ++lastTransactionID;
        }

    }
}
