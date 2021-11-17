using System;
using System.Linq;

namespace LongestIncreasingSubsequence
{
    public static class LongestIncreasingSubsequence
    {
        
        /// <summary>
        /// A simple method to take a sequence of numbers and returns longest increasing sequeance
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetLongestIncreasingSubsequence(string input)
        {

            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var stringArray = input.Split(Constants._delimater);

            if (stringArray.Length == 1)
                return stringArray[0];

            if (!AreAllIntegers(stringArray))
                return string.Empty;

            var numberArray = ConvertToLongArray(stringArray);

            int longestLength, resultIndex, tempIndex;

            longestLength = resultIndex = tempIndex = 0;

            for (int i = 0; i < numberArray.Length; i++)
            {
                if (i > 0 && numberArray[i - 1] >= numberArray[i])
                {
                    tempIndex = i;
                }

                var indexRange = i - tempIndex + 1;

                if (longestLength < indexRange)
                {
                    longestLength = indexRange;
                    resultIndex = i;
                }
            }

            var startIndex = resultIndex - longestLength + 1;

            var endIndex = resultIndex + 1;

            var tempOutput = numberArray.Skip(startIndex).Take(endIndex - startIndex);

            var output = string.Join(Constants._delimater, tempOutput);

            return output;
        }

        /// <summary>
        /// A method to make sure all values in sequence are numbers
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static Boolean AreAllIntegers(string[] input)
        {
            foreach (var value in input)
            {
                bool isInteger = int.TryParse(value, out int i);

                if (!isInteger)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// This method converts string array into long array
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static long[] ConvertToLongArray(string[] input)
        {
            return Array.ConvertAll(input, s => long.Parse(s));
        }

    }
}
