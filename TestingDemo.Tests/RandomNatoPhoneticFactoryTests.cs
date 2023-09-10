using Xunit;
using Moq;
using TestingDemo.Factories;
using TestingDemo.Interfaces;

namespace TestingDemo.Tests
{
    public class RandomNatoPhoneticFactoryTests
    {
        /*
            Instead of using InlineData, we can use MemberData to reference an IEnumereable<object[]> It might look a little confusing at first, but
            it's basically just an array of Test Cases. Each Test Case is an object[] which represents the character and string that we will pass in
            each time we run this test method.
        */
        public static readonly IEnumerable<object[]> LettersAndExpectedNatoPhonetic = new[]
        {
            new object[] { 'A', "Alpha" },      new object[] { 'a', "Alpha" },
            new object[] { 'B', "Bravo" },      new object[] { 'b', "Bravo" },
            new object[] { 'C', "Charlie" },    new object[] { 'c', "Charlie" },
            new object[] { 'D', "Delta" },      new object[] { 'd', "Delta" },
            new object[] { 'E', "Echo" },       new object[] { 'e', "Echo" },
            new object[] { 'F', "Foxtrot" },    new object[] { 'f', "Foxtrot" },
            new object[] { 'G', "Golf" },       new object[] { 'g', "Golf" },
            new object[] { 'H', "Hotel" },      new object[] { 'h', "Hotel" },
            new object[] { 'I', "India" },      new object[] { 'i', "India" },
            new object[] { 'J', "Juliett" },    new object[] { 'j', "Juliett" },
            new object[] { 'K', "Kilo" },       new object[] { 'k', "Kilo" },
            new object[] { 'L', "Lima" },       new object[] { 'l', "Lima" },
            new object[] { 'M', "Mike" },       new object[] { 'm', "Mike" },
            new object[] { 'N', "November" },   new object[] { 'n', "November" },
            new object[] { 'O', "Oscar" },      new object[] { 'o', "Oscar" },
            new object[] { 'P', "Papa" },       new object[] { 'p', "Papa" },
            new object[] { 'Q', "Quebec" },     new object[] { 'q', "Quebec" },
            new object[] { 'R', "Romeo" },      new object[] { 'r', "Romeo" },
            new object[] { 'S', "Sierra" },     new object[] { 's', "Sierra" },
            new object[] { 'T', "Tango" },      new object[] { 't', "Tango" },
            new object[] { 'U', "Uniform" },    new object[] { 'u', "Uniform" },
            new object[] { 'V', "Victor" },     new object[] { 'v', "Victor" },
            new object[] { 'W', "Whiskey" },    new object[] { 'w', "Whiskey" },
            new object[] { 'X', "X-ray" },      new object[] { 'x', "X-ray" },
            new object[] { 'Y', "Yankee" },     new object[] { 'y', "Yankee" },
            new object[] { 'Z', "Zulu" },       new object[] { 'z', "Zulu" }
        };

        [Theory]
        [MemberData(nameof(LettersAndExpectedNatoPhonetic))]
        public void GetRandomString_Given_RandomCharacterFactoryReturnsCharacter_ShouldReturn_ExpectedOutput(char character, string expected)
        {
            // Initialize a Mock of the IRandomCharacter Dependency
            var mockCharacterFactory = new Mock<IRandomCharacterFactory>();

            // Setup what we want the GetRandomCharacter to return
            mockCharacterFactory.Setup(mock => mock.GetRandomCharacter()).Returns(character);

            // Initialize the class we are going to test, using the Mocked Dependency
            var randomNatoPhoneticFactory = new RandomNatoPhoneticFactory(mockCharacterFactory.Object);

            // Call the method we are testing
            var result = randomNatoPhoneticFactory.GetRandomString();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData('0')]
        [InlineData('1')]
        [InlineData('2')]
        [InlineData('3')]
        [InlineData('4')]
        [InlineData('5')]
        [InlineData('6')]
        [InlineData('7')]
        [InlineData('8')]
        [InlineData('9')]
        public void GetRandomString_Given_RandomCharacterFactory_ReturnsNonLetter_ShouldReturn_EmptyString(char character)
        {
            // Initialize a Mock of the IRandomCharacter Dependency
            var mockCharacterFactory = new Mock<IRandomCharacterFactory>();

            // Setup what we want the GetRandomCharacter to return
            mockCharacterFactory.Setup(mock => mock.GetRandomCharacter()).Returns(character);

            // Initialize the class we are going to test, using the Mocked Dependency
            var randomNatoPhoneticFactory = new RandomNatoPhoneticFactory(mockCharacterFactory.Object);

            // Call the method we are testing
            var result = randomNatoPhoneticFactory.GetRandomString();

            Assert.Empty(result);
        }
    }
}
