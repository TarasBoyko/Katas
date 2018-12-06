using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            }

            char[] delimiters;
            if (numbers.StartsWith("//"))
            {
                delimiters = new char[] { numbers[2] };
                numbers = numbers.Substring(4); // skip "//" {separator character} "\n"
            }
            else
            { 
                delimiters = new char[] { ',', '\n' };
            }

            
            
            int result = 0;

            List<string> negativeNumbers = new List<string>();
            foreach (string conjunction in numbers.Split(delimiters) )
            {
                if ( Convert.ToInt32(conjunction) < 0 )
                {
                    negativeNumbers.Add(conjunction);
                }
                result += Convert.ToInt32(conjunction);
            }

            if ( negativeNumbers.Count != 0)
            {
                //throw new ArgumentException();
                throw new ArgumentException("negatives not allowed [" + string.Join(", ", negativeNumbers) + "]");
            }

               
            return result;
        }
    }
}
