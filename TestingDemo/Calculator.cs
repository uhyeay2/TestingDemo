namespace TestingDemo
{
    /*
        This class is a simple class to show an example of unit testing. This is a good example because the
        Calculator class has no references to any other classes. When we call the GetSumOfNumbers() method
        we won't be depending on any logic from any other classes.     
    */
    public class Calculator
    {        
        public int GetSumOfNumbers(params int[] numbers)
        {
            var sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }
    }
}
