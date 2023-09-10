using Xunit;

namespace TestingDemo.Tests
{
    public class CalculatorTests
    {
        /*
            This is an example of a unit test. We are testing a single class/method which has no dependencies (references to another class).            
        */
        [Fact]
        public void GetSumOfNumbers_Given_ZeroOneTwo_ShouldReturn_Three()
        {
            // Initialize the class we are testing
            var calculator = new Calculator();

            // Call the method we are testing
            var result = calculator.GetSumOfNumbers(0, 1, 2);

            Assert.Equal(3, result);
        }
    }
}
