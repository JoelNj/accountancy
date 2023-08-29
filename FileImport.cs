using System;
using System.IO;
namespace ClaumyAssignement
{
	public class FileImport
	{

		private String path;
		public FileImport(String path)
		{
			this.path = path; 
		}

		public Boolean checkIfFileExist()
		{
			if (File.Exists(path))
			{
				return true; 
			}
			return false; 
			
		}

		public void importData(String FileName,Portofolio portofolio)
		{
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            String wholePath = path + "/" + FileName + "." + "text";
              
            try
            {
                // Read all lines from the text file and store them in an array
                string[] lines = File.ReadAllLines(wholePath);

                // Process each line
                foreach (string line in lines)
                {
                  
                    String[] column = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int projectId = Int32.Parse(column[0]);
                    String transactionType = column[1];
                    double amount = Double.Parse(column[2]);

                    foreach (Project p in portofolio.getListOfProjects())
                    {
                        int transactionId = p.getTransactions().Count+1;
                        if (p.Id == projectId)
                        {
                            if(!transactionType.Equals("S") && !transactionType.Equals("R") && !transactionType.Equals("L"))
                            {
                                break;
                            }
                            if (transactionType.Equals("S"))
                            {

                                Transaction sale = new Sale(transactionId, amount, "S");
                                p.addTransaction(sale);
                            }
                            else if (transactionType.Equals("R"))
                            {
                                Purchase purchase = new Purchase(transactionId, amount, "R");
                                purchase.setPurchaseStrategy(new RenovationStrategy(purchase));
                                p.addTransaction(purchase);
                            }
                            else
                            {

                                Purchase purchase = new Purchase(transactionId, amount, "L");
                                purchase.setPurchaseStrategy(new LandStrategy(purchase));
                                p.addTransaction(purchase);

                            }
                        }
                        }

                    }

                
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found. Please check the file path.");
            }
            catch (IOException)
            {
                Console.WriteLine("An error occurred while reading the file.");
            }
        }
		
	}
}

