using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Day01;
using Day02;

namespace Main
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\..\Day02\Input.txt");
            var passwords = lines.Select(line => new Password(line)).ToList();

            Console.WriteLine(passwords.Count(p => p.IsValid()));
        }

        private static void Day01()
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\..\Day01\PuzzleInput.txt");
            var expenses = lines.Select(line => int.Parse(line, NumberStyles.Integer, CultureInfo.CurrentCulture)).ToList();

            var expenseReport = new ExpenseReport();
            expenseReport.SetExpenses(expenses);

            Console.WriteLine(expenseReport.Fix(3));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
