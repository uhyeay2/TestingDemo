using Xunit;
using Moq;
using TestingDemo.Factories;

namespace TestingDemo.Tests
{
    public class RandomCharacterFactoryTests
    {
        #region Integration Tests

        /*
            This test would be considered an integration test due to the fact that we are testing our class while integrated with a real instance of the 
            Random class. There is value in this test, because we are able to ensure that everything is functioning together properly. However, we are 
            limited in a way since we cannot set up our test to assert the exact character that is returned.
        */

        [Theory]
        [InlineData("abcdefg")]
        [InlineData("123456")]
        [InlineData("xyz")]
        [InlineData("#")]
        public void GetRandomCharacter_ShouldReturn_AnyExpectedCharacter(string expectedCharacters)
        {
            // Initialize the class using concrete implementation of Random class and the expected
            var randomCharacterFactory = new RandomCharacterFactory(new Random(), expectedCharacters.ToArray());

            // Call the method we are testing
            var result = randomCharacterFactory.GetRandomCharacter();

            Assert.True(expectedCharacters.Contains(result));
        }

        #endregion

        #region Unit Tests

        /*
            The two tests in this region I would consider to be Unit Tests. We use a Mock<Random> for the dependency on the Random class instead of the concrete
            implementation. By using Moq (nuget package) we are able to control what happens when we use the Random class. Instead of getting a random number,
            we are able to use the .Setup() method to say what we want the random.Next() method to return.

            At first using Moq can feel weird, it's almost like you're giving yourself the answer sometimes. However, over time you will notice that you are
            separating out your classes, and you are able to test your logic independently of whatever other classes that logic may depend on. This can be
            highly valuable for making sure one unit of work is doing its job properly when its dependencies are behaving the way they are expected to.

            With the first test in this section we are able to assert that we return the correct element from our character pool using the 'random' number 
            that we get from the Random class. This could not be accomplished with an integration test (using a real instance of the Random class).
        */

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void GetRandomCharacter_Given_RandomReturnsIndex_ShouldReturn_CharacterPool_ElementAtIndex(int index)
        {
            // Initialize Dependencies for RandomCharacterFactory
            var characterPool = new[] { '0', '1', '2', '3', '4', '5' };
            var mockRandom = new Mock<Random>();

            // Use the Mock<Random> to 'Setup' what will be returned when the RandomCharacterFactory calls _random.Next(0, _characterPool.Length)
            mockRandom.Setup(mock => mock.Next(0, characterPool.Length)).Returns(index);

            // Initialize our class that we are going to unit test.
            var randomCharacterFactory = new RandomCharacterFactory(mockRandom.Object, characterPool);

            // We will expect the factory to return the element of CharacterPool at whatever index the _random.Next() method returns
            var expected = characterPool[index];

            // Call the method we are testing
            var result = randomCharacterFactory.GetRandomCharacter();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetRandomCharacter_Given_CharacterPoolIsEmpty_ShouldReturn_WhiteSpace()
        {
            // Initialize Dependencies for RandomCharacterFactory
            var characterPool = Array.Empty<char>();
            var mockRandom = new Mock<Random>();

            // Initialize the RandomCharacterFactory with an empty Character array.
            var randomCharacterFactory = new RandomCharacterFactory(mockRandom.Object, characterPool);

            // Call the method we are testing
            var result = randomCharacterFactory.GetRandomCharacter();

            Assert.Equal(' ', result);
        }

        #endregion
    }
}
