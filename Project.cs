using System;
namespace ClaumyAssignement
{
	public class Project
	{

        private int id;
        private String name;
        private String type;

        private List<Transaction> transactions;  

        public Project(int id, String name, String type)
		{
            this.id = id;
            this.name = name;
            this.type = type;
            this.transactions = new List<Transaction>();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        public void addTransaction(Transaction t)
        {
            transactions.Add(t);

        }

        public void displayAllSalesTransaction()
        {
            if (transactions.Count != 0)
            {
                foreach(Transaction t in transactions)
                {
                    if (t.GetType().Name.Equals("Sale"))
                    {
                        Console.WriteLine("S   " + t.getAmount().ToString());
                    }
                }

            }
        }

        public void displayAllPurchasesTransaction()
        {
           
            if (transactions.Count != 0)
            {
                foreach (Transaction t in transactions)
                {
                    if (t.GetType().Name.Equals("Purchase"))
                    {
                        Console.WriteLine(t.TransactionType+"  " + t.getAmount().ToString());
                    }

                }

            }
        }

        public void displaySummaryOfTransaction()
        {
            Console.WriteLine("prj id " + " " + "Sum salary " + " " + "Sum Purchase " + "      " +  "Sum Refunds " + "   " + "Sum profit ");
            Console.WriteLine(this.Id + " " + this.sumSales() + " " + this.sumPurchases() + " " + this.sumRefunds() + " " + this.Profit());
        }


        public  double sumSales()
        {
            double sum = 0;
            if (transactions.Count != 0)
            {
                foreach (Transaction t in transactions)
                {
                    if (t.GetType().Name.Equals("Sale"))
                    {
                        sum += t.getAmount();
                    }
                }
            }
            return sum; 
        }

        public double sumPurchases()
        {
            double sum = 0;
            if (transactions.Count != 0)
            {
                foreach (Transaction t in transactions)
                {
                    if (t.GetType().Name.Equals("Purchase"))
                    {
                        sum += t.getAmount();
                    }
                }
            }
            return sum;
        }

        public double sumRefunds()
        {
            double sum = 0;
            if (transactions.Count != 0)
            {
                foreach (Transaction t in transactions)
                {
                    if (t.GetType().Name.Equals("Purchase"))
                    {
                        Purchase p = (Purchase)t;
                        sum +=p.getPurchaseStrategy().calculeRefund(20);
                    }
                }
            }
            return sum;
        }

        public double Profit()
        {
            double sum = this.sumSales()-this.sumPurchases()+this.sumRefunds();
            return sum;
        }

    }

        


}


