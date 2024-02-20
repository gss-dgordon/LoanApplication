using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Loan
{
    public class Loan
    {
        private double _amountFinanced;
        private double _roi;
        private int _term;
        private double _interestPaid;

        public double AmountFinanced
        {
            get { return _amountFinanced; }
            set { _amountFinanced = value; }
        }
        public double RateOfInterest
        {
            get { return _roi; }
            set { _roi = value; }
        }
        public int Term
        {
            get { return _term; }
            set { _term = value; }
        }
        public double InterestPaid
        {
            get { return _interestPaid; }
            set { _interestPaid = value; }
        }
        public Loan(double amountFinanced, double roi, int term)
        {
            _amountFinanced = amountFinanced > 0 ? amountFinanced : throw new ArgumentOutOfRangeException();
            _roi = roi > 0 ? roi : throw new ArgumentOutOfRangeException();
            _term = term > 0 ? term : throw new ArgumentOutOfRangeException();
            _interestPaid = CalculateInterest();
        }
        public double CalculateInterest()
        {
            return (_roi * _amountFinanced) / (1 - Math.Pow((1 + _roi), (_term * 12) * -1));
        } 

        public double CalculateMonthlyPayment()
        {
            return (_amountFinanced * (_roi / 1200)) / (1 - Math.Pow(1 + _roi / 1200, _term * -12));
        }

        public string GetAmortizationSchedule()
        {
            double monthlyPayment = CalculateMonthlyPayment();
            string schedule = $"Monthly Payment: {Math.Round(monthlyPayment, 2)}\n";
            schedule += "Month\tPayment\tInterest\tPrincipal\tBalance\n";
            double balance = _amountFinanced;
            double interest;
            double principal;
            for (int i = 1; i <= _term * 12; i++)
            {
                interest = balance * (_roi / 1200);
                principal = monthlyPayment - interest;
                balance = balance - principal > 0 ? balance - principal : 0;
                schedule += $"{i}\t{Math.Round(monthlyPayment,2)}\t{Math.Round(interest,2)}\t{Math.Round(principal,2)}\t{Math.Round(balance,2)}\n";
            }
            return schedule;
        }
    }
}
