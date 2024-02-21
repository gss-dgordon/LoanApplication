using src.Loan;
using System;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Enter the amount financed: ");
                double amountFinanced = double.Parse(Console.ReadLine());

                Console.Write("Enter the rate of interest %: ");
                double roi = double.Parse(Console.ReadLine());

                Console.Write("Enter the term in years: ");
                int term = int.Parse(Console.ReadLine());

                var loan = new Loan(amountFinanced, roi, term);
                Console.Write(loan.GetAmortizationSchedule());

                Console.Write("Do Another Calculation? (Y/N): ");
            } while(Console.ReadLine().Equals("Y", StringComparison.CurrentCultureIgnoreCase));
        }
    }
}