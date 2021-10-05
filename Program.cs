using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RemoveToTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write string: ");
            string stringToReduceToTwo = Console.ReadLine();

            string longestString = FindLongestStringOfTwo(stringToReduceToTwo);

            Console.WriteLine($"Length: {longestString.Length}\nString: {longestString}");

        }

        private static char[] FindDistinctCharacters(string stringToFindCharacters)
        {          
            char[] stringCharacters = stringToFindCharacters.ToCharArray();
            if(stringToFindCharacters == "")
            {
                return stringCharacters;
            }
            List<char> stringCharactersDistinct = new List<char> {stringCharacters[0]};
            foreach (char stringCharacter in stringCharacters)
            {

                if (!stringCharactersDistinct.Contains(stringCharacter))
                {
                    stringCharactersDistinct.Add(stringCharacter);
                }

            }

            return stringCharactersDistinct.ToArray();
        }

        private static string FindLongestStringOfTwo(string stringToReduceToTwo)
        {
            char[] stringCharactersDistinct = FindDistinctCharacters(stringToReduceToTwo);
            string longestString = "";

            for (int i = 0; i < stringCharactersDistinct.Length; i++)
            {

                for (int j = i + 1; j < stringCharactersDistinct.Length; j++)
                {

                    string regexPatternNotSingleCharacters = $@"[^{stringCharactersDistinct[i]}{stringCharactersDistinct[j]}]";
                    string regexPatternCharCombination = $@"[{stringCharactersDistinct[i]}][{stringCharactersDistinct[j]}]";
                    string tempString = Regex.Replace(stringToReduceToTwo, regexPatternNotSingleCharacters, String.Empty);
                    string tempStringCheck = Regex.Replace(tempString, regexPatternCharCombination, String.Empty);

                    if (tempStringCheck == "" || ( tempStringCheck.Length == 1 && tempStringCheck[0] == stringCharactersDistinct[i]))
                    {

                        if (tempString.Length > longestString.Length)
                        {
                            longestString = tempString;
                        }

                    }

                }

            }

            return longestString;
        }
    }
}
