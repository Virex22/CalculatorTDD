using System.Reflection.Metadata.Ecma335;

namespace StackUnitTests
{
    internal static class Calculator
    {
        internal static object Add(string numbers)
        {
            if (numbers == null || numbers == "")
                return 0;

            var arrayNumbers = formatNumbers(numbers).Split(GetDelimiter(numbers), '\n');
            
            if (numbers.Contains("-"))
                throwNegativeArgumentException(arrayNumbers);

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

        private static string formatNumbers(string numbers)
        {
            if (numbers.StartsWith("//"))
                numbers = numbers.Substring(4);
            return numbers;
        }
        
        private static void throwNegativeArgumentException(string[] numbers)
        {
            string number = numbers.Where(number => Convert.ToInt32(number) < 0).First();
            throw new ArgumentException($"string contains [{number}], which does not meet rule. Entered number should not be negative.");
        }

    }
}