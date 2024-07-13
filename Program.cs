// See https://aka.ms/new-console-template for more information
using ClaumyAssignement;
Portofolio p = new Portofolio();
Menu m = new Menu(p);
m.display();
Console.WriteLine("choose your operation based on the menu ");
Console.WriteLine(   System.IO.Directory.GetCurrentDirectory());
#pragma warning disable format
#pragma warning restore format
try
{
    int numberEnterByUser = int.Parse(Console.ReadLine());
    m.operation(numberEnterByUser);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.Read();
