using src.LoanService;

namespace test.LoanService
{
    [TestClass]
    public class LoanService_GetHello()
    {
        [TestMethod]
        public void GetHello_Returns_Hello_World()
        {
            // Arrange
            string expected = "Hello World!";
            // Act
            string actual = src.LoanService.LoanService.getHello();
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}