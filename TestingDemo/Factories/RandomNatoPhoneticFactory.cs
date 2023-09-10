using TestingDemo.Interfaces;

namespace TestingDemo.Factories
{
    /*
        This class is another example of one which can be unit tested since the dependency is passed into the constructor. 
        We can create a Unit Test by passing a Mock RandomCharacterFactory into the constructor and ensuring that if it returns
        'A' or 'a' that we return "Alpha". We could also ensure that if we get an unexpected output that we return an empty string.

        We could also create an Integration Test by passing in the actual implementation of the RandomCharacterFactory. This would ensure
        that this class integrates with its dependency without any issues. There is a lot of value to having tests which ensure all the
        separate pieces of your application flow together properly.

        If you're wondering why bother with unit tests and think that Integration Tests should be enough, then here is something to consider:
        When you are using an integration test, if the RandomCharacterFactory has an unexpected error and throws an exception, then that would
        cause your integration test for this RandomNatoPhoneticFactory to fail due to the thrown exception. This can cause you to think the error
        could be coming from this class until you do further investigation and find where the exception was really found. If you have Unit Tests
        as well as Integration Tests, then seeing that the unit tests for RandomCharacterFactory are failing also will help you identify the true
        cause of the unexpected errors.
    */
    public class RandomNatoPhoneticFactory : IRandomStringFactory
    {
        private readonly IRandomCharacterFactory _randomLetterFactory;

        public RandomNatoPhoneticFactory(IRandomCharacterFactory randomCharacterFactory)
        {
            _randomLetterFactory = randomCharacterFactory;
        }

        public string GetRandomString()
        {
            var randomLetter = _randomLetterFactory.GetRandomCharacter();

            switch (randomLetter)
            {
                case 'A' or 'a': return "Alpha";
                case 'B' or 'b': return "Bravo";
                case 'C' or 'c': return "Charlie";
                case 'D' or 'd': return "Delta";
                case 'E' or 'e': return "Echo";
                case 'F' or 'f': return "Foxtrot";
                case 'G' or 'g': return "Golf";
                case 'H' or 'h': return "Hotel";
                case 'I' or 'i': return "India";
                case 'J' or 'j': return "Juliett";
                case 'K' or 'k': return "Kilo";
                case 'L' or 'l': return "Lima";
                case 'M' or 'm': return "Mike";
                case 'N' or 'n': return "November";
                case 'O' or 'o': return "Oscar";
                case 'P' or 'p': return "Papa";
                case 'Q' or 'q': return "Quebec";
                case 'R' or 'r': return "Romeo";
                case 'S' or 's': return "Sierra";
                case 'T' or 't': return "Tango";
                case 'U' or 'u': return "Uniform";
                case 'V' or 'v': return "Victor";
                case 'W' or 'w': return "Whiskey";
                case 'X' or 'x': return "X-ray";
                case 'Y' or 'y': return "Yankee";
                case 'Z' or 'z': return "Zulu";
                default: return string.Empty;
            }
        }
    }
}
