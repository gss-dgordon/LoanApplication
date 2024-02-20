using src.Loan;
using System;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the amount financed: ");
            double amountFinanced = double.Parse(Console.ReadLine());

            Console.Write("Enter the rate of interest %: ");
            double roi = double.Parse(Console.ReadLine());

            Console.Write("Enter the term in years: ");
            int termMonths = int.Parse(Console.ReadLine());

            var loan = new Loan(amountFinanced, roi, termMonths);
            Console.Write(loan.GetAmortizationSchedule());

            Console.Write("Do Another Calculation? (Y/N): ");
            while(Console.ReadLine().ToUpper() == "Y")
            {
                Console.Write("Enter the amount financed: ");
                amountFinanced = double.Parse(Console.ReadLine());

                Console.Write("Enter the rate of interest %: ");
                roi = double.Parse(Console.ReadLine());

                Console.Write("Enter the term in years: ");
                termMonths = int.Parse(Console.ReadLine());

                loan = new Loan(amountFinanced, roi, termMonths);
                Console.Write(loan.GetAmortizationSchedule());

                Console.Write("Do Another Calculation? (Y/N): ");
            }
        }
    }
}