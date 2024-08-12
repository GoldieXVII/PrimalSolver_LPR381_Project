using PrimalSolver;

GettingData gd = new GettingData();
PrimalOG pOG  = new PrimalOG();
string [,] data = gd.readFile();

if(data[0, 0] != null)
{
    if (data[0, 0].Equals("max"))
    {
        Console.WriteLine("\nMax Prob");
        pOG.maxOG(data);
    }
    else if (data[0, 0].Equals("min"))
    {
        Console.WriteLine("\nMin Prob");
        pOG.minOG(data);
    }
    else
    {
        Console.WriteLine("Specify if its a min or a max in the text file");
    }
}
else
{
    Console.WriteLine("No data present");
}