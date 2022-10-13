using System.Reflection.Metadata.Ecma335;

namespace StackUnitTests
{
    internal static class Calculator
    {
        internal static object Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var arrayNumbers = FormatNumbers(numbers).Split(GetDelimiter(numbers), '\n');
            
            if (numbers.Contains("-"))
                ThrowNegativeArgumentException(arrayNumbers);

            return arrayNumbers
                .Where(number => Convert.ToInt32(number) <= 1000)
                .Sum(stringNumber => Convert.ToInt32(stringNumber));
        }
        
        private static char GetDelimiter(string numbers)
        {
            if (numbers.StartsWith("//")) 
                return numbers[2];
            return ',';
        }

        private static string FormatNumbers(string numbers)
        {
            if (numbers.StartsWith("//"))
                numbers = numbers.Substring(4);
            return numbers;
        }
        
        private static void ThrowNegativeArgumentException(string[] numbers)
        {
            string number = numbers.Where(number => Convert.ToInt32(number) < 0).First();
            throw new ArgumentException($"string contains [{number}], which does not meet rule. Entered number should not be negative.");
        }

    }
}