using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProj.Functionality
{
    public static class MenuOptions
    {
        public static int UpdateBlanks(int index)
        {
            var nextTen = Loader.Blanks(index);
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true); // Read the key without displaying it
                    if (key.Key == ConsoleKey.Q)
                    {
                        break;
                    }
                }

                Console.WriteLine("\nSelect a Company to modify (If less than 10 companies available, don't press out of index, or press Q to go back");
                var companyChoice = InputReader.SingleKey(10);
                var selectedCompany = nextTen[companyChoice];
                

            }

            Console.Clear();
            return index + 10;
        }

        public static void PrintUpdated()
        {
            Console.WriteLine("NOT IMPLEMENTED\n\n");
        }
        
        public static void UpdateApplications()
        {
            Console.WriteLine("NOT IMPLEMENTED\n\n");
        }
        
        public static void CheckApplications()
        {
            Console.WriteLine("NOT IMPLEMENTED\n\n");
        }
    }
}
