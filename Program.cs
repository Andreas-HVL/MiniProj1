using MiniProj.Functionality;


namespace MiniProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            try
            {
                // Initialize runtime data
                DBImport.LoadCompanies();
                DBImport.LoadApplications();
            }
            catch (Exception ex)
            {
                Console.WriteLine("The program encountered a critical error during initialization and must shut down.");
                Console.WriteLine($"Error: {ex.Message}");
                Environment.Exit(1); // Force the program to exit with an error code in case of failure to init runtime data
            }
            
            do
            {
                int blankIndex = 0;

                Console.WriteLine("Do you want to \n1: Update at blank companies\n2: Look at updated companies\n3: Update application status\n4: Look at application status\n0: Exit");
                var menuChoice = InputReader.SingleKey(5);
                switch (menuChoice)
                {
                    case '0':
                        Environment.Exit(0);
                        break;

                    case '1':
                        Console.Clear();
                        MenuOptions.UpdateBlanks(blankIndex);
                        break;

                    case '2':
                        Console.Clear();
                        MenuOptions.PrintUpdated();
                        break;

                    case '3':
                        Console.Clear();
                        MenuOptions.UpdateApplications();
                        break;

                    case '4':
                        Console.Clear();
                        MenuOptions.CheckApplications();
                        break;
                }
            } while (running = true);
            

        }
    }
}
