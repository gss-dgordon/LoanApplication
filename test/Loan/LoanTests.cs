using src.Loan;

namespace test.LoanTests
{
    [TestClass]
    public class LoanTests
    {
        [TestMethod]
        public void Constructor_Sets_Values_Correctly()
        {
            // Arrange
            double amountFinanced = 10000;
            double roi = 5.00;
            int term = 2;

            // Act
            var loan = new Loan(amountFinanced, roi, term);

            // Assert
            Assert.AreEqual(amountFinanced, loan.AmountFinanced);
            Assert.AreEqual(roi, loan.RateOfInterest);
            Assert.AreEqual(term, loan.Term);
        }

        [TestMethod]
        public void CalculateInterest_Returns_Correct_Interest()
        {
            // Arrange
            double amountFinanced = 10000;
            double roi = 5.00;
            int term = 2;
            var loan = new Loan(amountFinanced, roi, term);
            // Act
            double interest = loan.CalculateInterest();
            // Assert
            Assert.AreEqual(amountFinanced * roi, interest);
        }   

        [TestMethod]
        public void CalculateMonthlyPayment_Returns_Correct_Payment()
        {
            // Arrange
            double amountFinanced = 10000;
            double roi = 5.00;
            int term = 2;
            var loan = new Loan(amountFinanced, roi, term);
            // Act
            double monthlyPayment = loan.CalculateMonthlyPayment();
            // Assert
            Assert.AreEqual((amountFinanced * (roi / 1200)) / (1 - Math.Pow(1 + roi / 1200, term * -12)), monthlyPayment);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Throws_Exception_For_Negative_AmountFinanced()
        {
            var loan = new Loan(-10000, 5, 12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Throws_Exception_For_Negative_RateOfInterest()
        {
            var loan = new Loan(10000, -5, 12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Throws_Exception_For_Negative_TermMonths()
        {
            var loan = new Loan(10000, 5, -12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Throws_Exception_For_Zero_TermMonths()
        {
            var loan = new Loan(10000, 5, 0);
        }
    }
}
