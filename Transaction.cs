using System;
using System.Xml.Linq;

namespace ClaumyAssignement
{
	public abstract class Transaction
	{
        private int id;
        private String transactionType;
        private double amount;

        public Transaction(int id, double amount , String transactionType)
        {
            this.id = id;
            this.amount = amount;
            this.transactionType = transactionType; 
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public String TransactionType
        {
            get { return transactionType; }
            set { transactionType = value; }
        }

     

        public double getAmount()
        {
            return this.amount;
        }
    }
}




