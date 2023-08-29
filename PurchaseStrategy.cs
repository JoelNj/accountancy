using System;
using ClaumyAssignement;

namespace ClaumyAssignement
{
	public abstract class PurchaseStrategy
	{
        private Purchase purchase;

        public PurchaseStrategy(Purchase purchase)
        {
            this.purchase = purchase;
        }

        public abstract double calculeRefund(double rateOfVat);

        public Purchase getPurchase()
        {
            return purchase;
        }
    }
}




