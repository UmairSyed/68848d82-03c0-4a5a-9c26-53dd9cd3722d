using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LongestIncreasingSubsequence
{
    public static class LongestIncreasingSubsequence
    {
        public static string Get (string input)
        {
            //Return empty if string is empty or null
            if (string.IsNullOrWhiteSpace(input))
                return "";

            var stringArray = input.Split(" ");

            if (stringArray.Length == 1)
                return stringArray[0];

            //Checking if all values are numbers
            if (!AreAllIntegers(stringArray))
                return "";

            //Convert string array into long array
            var numberArray = ConvertToLongArray(stringArray);

            int longestLength, resultIndex, tempIndex;

            longestLength = resultIndex = tempIndex = 0;

            for (int i = 0; i < numberArray.Length; i++)
            {
                if (i > 0 && numberArray[i - 1] >= numberArray[i])
                {
                    tempIndex = i;
                }

                if (longestLength < i - tempIndex + 1)
                {
                    longestLength = i - tempIndex + 1;
                    resultIndex = i;
                }
            }

            var startIndex = resultIndex - longestLength + 1;

            var endIndex = resultIndex + 1;

            var tempOutput = numberArray.Skip(startIndex).Take(endIndex - startIndex);

            var output = string.Join(" ", tempOutput);
            
            return output;
        }

        private static Boolean AreAllIntegers (string[] input)
        {
            foreach (var value in input)
            {
                bool isInteger = int.TryParse(value, out int i);

                if (!isInteger)
                    return false;
            }

            return true;
        }

        private static long[] ConvertToLongArray(string[] input)
        {
            return Array.ConvertAll(input, s => long.Parse(s));
        }

    }
}
