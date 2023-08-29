using System;
using System.Xml.Linq;

namespace ClaumyAssignement
{
	public class Purchase:Transaction
    {
        PurchaseStrategy purchaseStrategy;

        public void setPurchaseStrategy(PurchaseStrategy purchaseStrategy)
        {
            this.purchaseStrategy = purchaseStrategy;
        }
        public Purchase(int id, double amount, string transactionType) : base(id, amount, transactionType)
        {
             

        }

        public PurchaseStrategy getPurchaseStrategy()
        {
            return this.purchaseStrategy;
        }
	}
}

