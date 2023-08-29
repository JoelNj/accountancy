using System;
namespace ClaumyAssignement
{
	public class RenovationStrategy:PurchaseStrategy
	{
		public RenovationStrategy(Purchase p):base(p)
		{
		}

        public override double calculeRefund(double rateOfVat)
        {
            return 0;
        }
    }
}

