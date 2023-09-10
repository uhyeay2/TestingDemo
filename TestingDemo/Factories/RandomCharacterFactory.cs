using TestingDemo.Interfaces;

namespace TestingDemo.Factories
{
    /*
        This class is an example of a class that has been created in a way that it can be unit tested.
        Notice that the class does not initialize its dependencies but instead has them passed into the constructor.

        By doing this we are de-coupling the application. We could use this Factory to generate random Letters, Numbers,
        or any other selection of characters by changing the CharacterPool we pass in.
    
        We will also be able to create unit tests which will Mock the Random class and allow us to ensure we get the expected
        result when our dependency (Random class) returns different values.
    */
    public class RandomCharacterFactory : IRandomCharacterFactory
    {
        // Constructor takes in the Random and char[] Dependencies that this class needs in order to function.
        public RandomCharacterFactory(Random random, char[] characterPool)
        {
            _random = random;
            _characterPool = characterPool;
        }

        private readonly Random _random;

        private readonly char[] _characterPool;

        public char GetRandomCharacter()
        {
            if (!_characterPool.Any())
            {
                return ' ';
            }

            var index = _random.Next(0, _characterPool.Length);

            return _characterPool[index];
        }
    }
}
