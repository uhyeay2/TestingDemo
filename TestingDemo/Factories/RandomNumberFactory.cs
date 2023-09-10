using TestingDemo.Interfaces;

namespace TestingDemo.Factories
{
    /*
        This class is an example of one which is tightly-coupled. At a first glance, you may think there is convenience
        in having a constructor that requires no parameters. You can initialize this class without needing to initialize
        the dependencies (RandomCharacterFactory) that it relies on. However, this comes at a cost.

        Since the RandomCharacterFactory is coupled to this class, we cannot control the output in a test. Any test that
        we create for this class will inherently be an integration test, since it will be testing this class integrated
        with the RandomCharacterFactory that it depends on.

        The most testing we could accomplish on this class would be to ensure that it always returns one of any of the
        expected outputs. We cannot specifically ensure that if we get '0' from the RandomNumberFactory that we will 
        return "Zero" - this cannot be confirmed without manually debugging the code and seeing what happens at run time.
    */
    public class RandomNumberFactory : IRandomStringFactory
    {
        private readonly IRandomCharacterFactory _randomNumberFactory;

        public RandomNumberFactory()
        {
            var numbers = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

            _randomNumberFactory = new RandomCharacterFactory(new Random(), numbers);
        }

        public string GetRandomString()
        {
            var randomNumber = _randomNumberFactory.GetRandomCharacter();

            return randomNumber switch
            {
                '0' => "Zero",
                '1' => "One",
                '2' => "Two",
                '3' => "Three",
                '4' => "Four",
                '5' => "Five",
                '6' => "Six",
                '7' => "Seven",
                '8' => "Eight",
                '9' => "Nine",
                _ => "Error",
            };
        }
    }
}
