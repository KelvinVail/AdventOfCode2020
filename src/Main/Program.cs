using System;
using System.Globalization;
using System.Linq;
using Day01;

namespace Main
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\..\Day01\PuzzleInput.txt");
            var expenses = lines.Select(line => int.Parse(line, NumberStyles.Integer, CultureInfo.CurrentCulture)).ToList();

            var expenseReport = new ExpenseReport();
            expenseReport.SetExpenses(expenses);

            Console.WriteLine(expenseReport.Fix());

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
