using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input file to procces: ");
            string fileName = Console.ReadLine();
            Console.WriteLine("Input filter: ");
            string filter = Console.ReadLine();
            try
            {
                SearchWord srch = new SearchWord(fileName, filter);
                srch.WriteResults();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            Console.ReadKey();
        }
    }
}
