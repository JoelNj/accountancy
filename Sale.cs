using System;
namespace ClaumyAssignement
{
    public class Sale : Transaction
    {
   
        public Sale(int id, double amount, string transactionType) : base(id, amount, transactionType)
        {
            
        }
    }
}

