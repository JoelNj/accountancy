using System;
namespace ClaumyAssignement
{
	public class Portofolio
	{

		private List<Project> projects; 
		public Portofolio()
		{
			this.projects = new List<Project>();
		}

		public void addProject(Project p )
		{
			while (getOneProject(p.Id) != null)
			{
				p.Id = p.Id + 1;
				Project pr = getOneProject(p.Id);
				if (pr == null)
				{
					break;
				}
            }
			projects.Add(p);
		}

        public void removeProject(Project p)
        {
            projects.Remove(p);
        }

		public List<Project> getListOfProjects()
		{
			return this.projects;
		}

		public void displayAllProject()
		{
			if (this.projects.Count!=0)
			{
				Console.WriteLine("Project id  project name  project type ");
                foreach (Project p in this.projects)
                {

                    Console.WriteLine(p.Id.ToString() + " "+ p.Name + " " + p.Type);
                }
            }
			else
			{
                Console.WriteLine("The portofolio is empty for the moment ");
            }
			
		}

		public Project getOneProject(int id)
		{
            if (this.projects.Count != 0)
            {
                foreach (Project p in this.projects)
                {
					if (p.Id == id)
					{
						return p;
                    }
                }
            }

            return null; 
		}

        public string  displayProjectInformationt(Project p )
        {
			if (p != null)
			{
				return p.Id.ToString() + " " + p.Name + " " + p.Type;
			}
			else
			{
				return "this project doesn't exist in the database";
			}

          
        }

        public void displaySummaryOfProjectInPortofolio()
        {
			double sumSales = 0;
			double sumPurchase = 0;
			double sumProfit = 0;
			double sumRefunds = 0; 

            if (this.projects.Count != 0)
            {
                foreach (Project p in this.projects)
                {
					sumSales += p.sumSales();
					sumPurchase += p.sumPurchases();
					sumProfit += p.Profit();
					sumRefunds += p.sumRefunds();
                 
                }
                Console.WriteLine("Sum Sales   Sum Purchases  Sum Refunds   Sum Refunds ");
                Console.WriteLine(sumSales + " " + sumPurchase + " " + sumRefunds + " " + sumProfit);
            }
			else
			{
                Console.WriteLine("There is no project in the database");
            }
        }
           

        }
    }


