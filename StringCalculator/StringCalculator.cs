using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace StringCalculator
{

    public class Calculator
    {
        public int Add(string numbers)
        {
            char[] customDelimiter = GetDelimiters(numbers);

            String[] strings = numbers.Split(customDelimiter);
            var sum = 0;
            foreach(var s in strings)
            {
                if (int.TryParse(s, out int number))
                {

                    if (number < 0)
                    {
                        throw new Exception("negatives not allowed" + number.ToString());
                    }
                    sum += number;
                }

            }

            return sum;
        }

        public static char[] GetDelimiters(string numbers)
        {
            var delimiters = new List<char> { ',', '\n' };
            if(numbers.StartsWith("//"))
            {
                var delimiterDeclaration = numbers.Split('\n').First();
                char  delimiter = delimiterDeclaration.Substring(2,1).Single();
                delimiters.Add(delimiter);                
            }
 
            return delimiters.ToArray();
        }
    }

  }
