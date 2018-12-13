using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata1
{
    // Provides methods for calculation expressions in special string format.
    public class StringCalculator
    {
        // Returns the amount of number list in special string format.
        // The format: ("//" [delimiter1][delimiter2]... \n number1 some_delimiter number2 some_delimiter ...) or
        //             (number1 delimiter number2 delimiter (where "delimiter" is ',' or '\n'))
        // @inputString specifies string in the special string format, that will be calculated.
        public virtual int Add(string inputString)
        {
            if (inputString == null)
            {
                throw new NullReferenceException();
            }
            if (inputString.Length == 0)
            {
                return 0;
            }

            Regex argReges;
            string customDelimitersMark = "//";
            List<int> nums = new List<int>(); // number list
            string numberInRegex = "-?\\d+?"; // pattern for a number in a regular expression
            
            // determine the regular expression
            if (inputString.StartsWith(customDelimitersMark))
            {
                // determine predefined delimiters
                argReges = new Regex("^//(\\[(?<delimiter>(.|\\n)+?)\\])+?\\n");
                List<string> delimitersList = new List<string>();
                foreach (Capture element in argReges.Match(inputString).Groups["delimiter"].Captures)
                {
                    if ( !delimitersList.Contains(element.Value) )
                    {
                        delimitersList.Add(element.Value);
                    }
                }

                // determine delimiters, which separate the numbers
                List<char> SpecialRegexSymbols2 = new List<char> { '\\', '^', '$', '*', '+', ')', '(', '[', ']', '?', '/', '|', '.', ',', '{', '}' };
                string actualDelimiters = "(";

                for ( int ii = 0; ii < delimitersList.Count; ii++)
                {
                    int delimiterLength = delimitersList[ii].Length;

                    for ( int jj = 0; jj < SpecialRegexSymbols2.Count; jj++)
                    {
                        delimitersList[ii] = delimitersList[ii].Replace(SpecialRegexSymbols2[jj].ToString(), "\\" + SpecialRegexSymbols2[jj].ToString());
                    }
                }
                for (int i = 0; i < delimitersList.Count - 1; i++)
                {
                    actualDelimiters += delimitersList[i] + "|";
                }
                actualDelimiters += delimitersList[delimitersList.Count-1] + ")";
                
                // form full regular expression
                argReges = new Regex("^//(\\[(?<delimiter>(.|\\n)+?)\\])+?\\n" + "(?<firstNumber>" + numberInRegex + ")(" + actualDelimiters + "(?<otherNumbers>" + numberInRegex + "))*$");
            }
            else
            {
                string defaultDelimitersInRegex = ",|\n"; // default delimiters separated by '|'. To screen '|' use '\|'.
                argReges = new Regex("^(?<firstNumber>" + numberInRegex + ")((" + defaultDelimitersInRegex + ")(?<otherNumbers>" + numberInRegex + "))*$");
            }

            if (argReges.Matches(inputString).Count != 1) // if inputString is not correct form
            {
                throw new ArgumentException();
            }

            // parse the numbers
            GroupCollection groups = argReges.Match(inputString).Groups;
            nums.Add(Convert.ToInt32(groups["firstNumber"].Value));
            for (int i = 0; i < groups["otherNumbers"].Captures.Count; i++)
            {
                nums.Add(Convert.ToInt32(groups["otherNumbers"].Captures[i].Value));
            }

            // determine the amount of the numbers
            int result = 0;
            List<string> negativeNumbers = new List<string>();
            foreach (int element in nums )
            {
                if ( element < 0 )
                {
                    negativeNumbers.Add(element.ToString());
                }
                if ( element <= 1000 )
                {
                    result += element;
                }  
            }

            if ( negativeNumbers.Count != 0)
            {
                throw new ArgumentException("negatives not allowed [" + string.Join(", ", negativeNumbers) + "]");
            }
   
            return result;
        }
    }
}
