using MiniProj.Functionality;


namespace MiniProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBImport.LoadCompanies();
            DBImport.LoadApplications();

            DBImport.PrintSomething();
        }
    }
}
