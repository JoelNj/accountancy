using System;
namespace ClaumyAssignement
{
#pragma warning disable format
    public class LandStrategy:PurchaseStrategy
#pragma warning restore format
    {
		public LandStrategy(Purchase p):base(p)
		{

		}

        public override double calculeRefund(double rateOfVat)
        {
            double compute = base.getPurchase().getAmount() / ((100 + rateOfVat) / 100);
            double refund = base.getPurchase().getAmount() - compute;
            return refund;
        }
    }
}

