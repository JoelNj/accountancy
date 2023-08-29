using System;
namespace ClaumyAssignement
{
	public class Menu
	{
        private Portofolio p;
        public Menu(Portofolio p)
        {
            this.p = p;
        }

        public  void display()
        {
            Console.WriteLine("Press 1 to  Add Project in the portofolio.");
            Console.WriteLine("Press 2 to display all existing project in the portofolio ");
            Console.WriteLine("Press 3 to seleect a project in the portofolio ");
            Console.WriteLine("Press 4  to add transaction in a project  ");
            Console.WriteLine("Press 5  provide the id of the project that you want to remove  ");
            Console.WriteLine("Press 6  Display All Sale");
            Console.WriteLine("Press 7 Display All purchase  ");
            Console.WriteLine("Press 8 Display  summary for the given transaction");
            Console.WriteLine("Press 9 Display  summary for total portofolio");
            Console.WriteLine("Press 10 to import data in projects ");

        }

        public  void operation(int number)
        {
           
            
            switch (number)
            {
                case 1:

                    Console.WriteLine("you have pressed 1 , Add a project in the portofolio  ");
                    Console.WriteLine("------------------------------------------------------------------------------");

                    Console.WriteLine("Provide a name for your project : ");
                    String ProjectName = Console.ReadLine();

                    while (ProjectName.Equals("") || ProjectName == null)
                    {
                        Console.WriteLine("Provide a correct name for your project ");
                        ProjectName = Console.ReadLine();
                    }
                    Console.WriteLine("Provide a type for your project , it should be new build or renovation  or type exit to leave this menu ");
                    String type = Console.ReadLine();

                    while (!type.Equals("new build") && !type.Equals("renovation") && !type.Equals("exit"))
                    {
                        Console.WriteLine("Provide a  correct  type for your project : it should be new build or renovation or type exit to leave this menu  ");
                        type = Console.ReadLine();
                    }

                    int numberOfProject = this.p.getListOfProjects().Count;
                    int projectId = numberOfProject + 1;
                    Project project = new Project(projectId, ProjectName, type);
                    this.p.addProject(project);
                    Console.WriteLine("You have successfully added the project in the database ");
                    this.messageForOperation();
                    break;
                   
                case 2:
                    Console.WriteLine("you have pressed 2 , Below is the list of all projects in the portofolio ");
                    Console.WriteLine("-------------------------------------------------------------------------");
                    this.p.displayAllProject();
                    this.messageForOperation();
                    Console.WriteLine("-------------------------------------------------------------------------");
                    break;
                    
                case 3:

                    Console.WriteLine("you have pressed 3 , To select a project in  the portofolio ");
                    Console.WriteLine("------------------------------------------------------------------------------");

                    Console.WriteLine("Give the id of the project that you are looking for  : ");
                    int numberEnterByUser = int.Parse(Console.ReadLine());
                    Project p = this.p.getOneProject(numberEnterByUser);
                    Console.WriteLine("Project id  project name  project type ");
                    Console.WriteLine(this.p.displayProjectInformationt(p));
                    this.messageForOperation();
                    Console.WriteLine("-------------------------------------------------------------------------");
                    break;

                case 4:

                    Console.WriteLine("you have pressed 4 ,Select first the  project and then add transaction to that ");
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.WriteLine("select project id  ");
                    int myProject = int.Parse(Console.ReadLine());


                    while (this.p.getOneProject(myProject) == null)
                    {

                        Console.WriteLine("this project doesn't exist select an other id ");
                        Console.WriteLine("select project id  ");
                        myProject = int.Parse(Console.ReadLine());

                    }

                    Project proje = this.p.getOneProject(myProject);
                    Console.WriteLine("Press S for sales and P for Purchase ");
                    String userOperation = Console.ReadLine();

                    while (!userOperation.Equals("S") && !userOperation.Equals("P"))
                    {
                        Console.WriteLine("Press S for sales and P for Purchase ");
                        userOperation = Console.ReadLine();
                    }

                    Console.WriteLine("Provide the transaction Amount");
                    double transactionAmount = Double.Parse(Console.ReadLine());


                    if (userOperation.Equals("S"))
                    {
                        Sale sale = new Sale(1, transactionAmount, "S");
                        proje.addTransaction(sale);
                    }
                    else
                    {
                        Console.WriteLine("Choose Purchase type L for Land and R for Renovation ");
                        String purchaseType = Console.ReadLine();

                        while (!purchaseType.Equals("L") && !purchaseType.Equals("R"))
                        {
                            Console.WriteLine("Please ,Choose Purchase type L for Land and R for Renovation ");
                            purchaseType = Console.ReadLine();
                        }
                        Purchase purchase;
                        if (purchaseType.Equals("L"))
                        {
                            purchase = new Purchase(1, transactionAmount, "L");
                            purchase.setPurchaseStrategy(new LandStrategy(purchase));
                            proje.addTransaction(purchase);
                        }
                        else
                        {
                            purchase = new Purchase(1, transactionAmount, "R");
                            purchase.setPurchaseStrategy(new RenovationStrategy(purchase));
                            proje.addTransaction(purchase);
                        }

                    }
                    this.messageForOperation();
                    break;

                case 5:
                    Console.WriteLine("you have pressed 5 , You have to provide the id of the project that you want to remove  ");
                    Console.WriteLine("------------------------------------------------------------------------------");
                    int IdOfProject = int.Parse(Console.ReadLine());

                    while (this.p.getOneProject(IdOfProject) == null)
                    {
                        Console.WriteLine("The value of the project that you provide is incorrect , please provide good number ");
                        IdOfProject = int.Parse(Console.ReadLine());
                    }
                    this.p.removeProject(this.p.getOneProject(IdOfProject));
                    this.messageForOperation();
                    break;

                case 6:
                    Console.WriteLine("you have pressed 6 , You have to provide the id for displaying all sale transaction for the  given project ");
                    Console.WriteLine("------------------------------------------------------------------------------");
                    int Id = int.Parse(Console.ReadLine());

                    while (this.p.getOneProject(Id) == null)
                    {
                        Console.WriteLine("The value of the project that you provide is incorrect , please provide good number ");
                        Id = int.Parse(Console.ReadLine());
                    }
                    Project projectToDisplaySale = this.p.getOneProject(Id);
                    projectToDisplaySale.displayAllSalesTransaction();
                    this.messageForOperation();
                    break;
                case 7:
                    Console.WriteLine("you have pressed 7 , You have to provide the id for displaying all Purchase transaction for the  given project ");
                    Console.WriteLine("------------------------------------------------------------------------------");
                    int Ide = int.Parse(Console.ReadLine());

                    while (this.p.getOneProject(Ide) == null)
                    {
                        Console.WriteLine("The value of the project that you provide is incorrect , please provide good number ");
                        Id = int.Parse(Console.ReadLine());
                    }
                    Project projectToDisplayPurchase = this.p.getOneProject(Ide);
                    projectToDisplayPurchase.displayAllPurchasesTransaction(); 
                    this.messageForOperation();
                    break;
                case 8:
                    Console.WriteLine("you have pressed 8 , You have to provide the id for displaying all  transactions for the  given project ");
                    Console.WriteLine("------------------------------------------------------------------------------");
                    int Ided = int.Parse(Console.ReadLine());

                    while (this.p.getOneProject(Ided) == null)
                    {
                        Console.WriteLine("The value of the project that you provide is incorrect , please provide good number ");
                        Id = int.Parse(Console.ReadLine());
                    }
                    Project projectToDisplayAllTransaction = this.p.getOneProject(Ided);
                    projectToDisplayAllTransaction.displaySummaryOfTransaction();
                    this.messageForOperation();
                    break;
                case 9:
                    Console.WriteLine("you have pressed 9 , You have to provide the id for displaying all  transactions for the  given project ");
                    Console.WriteLine("------------------------------------------------------------------------------");
                    this.p.displaySummaryOfProjectInPortofolio();
                    this.messageForOperation();
                    break;
                case 10:
                    Console.WriteLine("you have pressed 10 , select write the name of the file to import without the extension   ");
                    Console.WriteLine("------------------------------------------------------------------------------");
                    String fileToImportName = Console.ReadLine();
                    new FileImport("/Users/nj/ImportFolder").importData(fileToImportName, this.p);
                    this.messageForOperation();
                    break;
                default:
                    break;

            };

        }
        public void messageForOperation()
        {
            Console.WriteLine("choose your operation based on the menu ");

            
            try
            {
                int numberEnterByUser = int.Parse(Console.ReadLine());
                this.operation(numberEnterByUser);
            }
            catch (Exception  ex )
            {
                Console.WriteLine(ex.Message);
            }

        }
   

    }
}

