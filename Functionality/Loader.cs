using MiniProj.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProj.Functionality
{
    public static class Loader
    {
        public static List<Company> Blanks(int j)
        {
            var blankCompanies = DBImport.blankCompanies;
            var currentCompanies = new List<Company>();

            if (blankCompanies == null || blankCompanies.Length == 0)
            {
                Console.WriteLine("No companies available");
                return currentCompanies;
            }
            else
            {
                int loopLimit = Math.Min(j + 10, blankCompanies.Length);
                for (int i = j; i < loopLimit; i++)
                {
                    currentCompanies.Add(blankCompanies[i]);
                    Console.WriteLine($"{(i-j) % 10}  {blankCompanies[i].Name}");
                }
                return currentCompanies;
            }
            
        }
    }
}
