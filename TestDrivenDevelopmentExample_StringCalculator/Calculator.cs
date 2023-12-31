﻿
namespace TestDrivenDevelopmentExample_StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            var delimiters = new List<char> { ',', '\n' };

            if (numbers.StartsWith("//"))
            {
                var splitOnFirstNewLine = numbers.Split(new[] {'\n'}, 2);
                var customDelimiter = splitOnFirstNewLine[0].Replace("//", string.Empty).Single();
                delimiters.Add(customDelimiter);
                numbers = splitOnFirstNewLine[1];
            }

            var splitNumbers = numbers
                .Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var negativeNumbers = new List<int>();

            foreach(var potentiallyNegativeNumber in splitNumbers)
            {
                if(potentiallyNegativeNumber < 0)
                {
                    negativeNumbers.Add(potentiallyNegativeNumber);
                }
            }

            if (negativeNumbers.Any())
            {
                throw new Exception("Negatives not allowed: " + string.Join(",", negativeNumbers));
            }

            return splitNumbers.Sum();
        }
    }
}
