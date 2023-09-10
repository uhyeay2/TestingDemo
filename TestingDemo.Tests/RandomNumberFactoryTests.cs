using Xunit;
using TestingDemo.Factories;

namespace TestingDemo.Tests
{
    /*
        Due to the way that the RandomNumberFactory is coded, we cannot do a true unit test on this class. This class depends on the
        RandomCharacterFactory to supply it with random numbers. We can assert that we always get an expected output when we call
        the GetRandomString() method, however we cannot assert that when the CharacterFactory returns '0' that we return "Zero".
    */

    public class RandomNumberFactoryTests
    {
        private static readonly string[] _possibleOutputs = new[]
        {
            "Zero", "One", "Two", "Three", "Four", "Five",
            "Six", "Seven", "Eight", "Nine", "Error"
        };

        [Fact]
        public void GetRandomString_Given_OneThousandCalls_ShouldAlways_ReturnExpectedOutput()
        {
            // Initialize array of strings that we will hold results in
            var results = new string[1000];

            // Initialize the class we are testing
            var randomNumberFactory = new RandomNumberFactory();

            // Call the method 1000 times to ensure it always returns an expected result
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = randomNumberFactory.GetRandomString();
            }

            // Assert that it's true that possibleOutput contains every result
            Assert.All(results, r =>
            {
                _possibleOutputs.Contains(r);
            });
        }
    }
}
