using System;
using System.Collections.Generic;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var ep = new ExpressionProcessor();

            ep.Variables.Add('x', 3);

            var result1 = ep.Calculate("1+2+3");
            var result2 = ep.Calculate("1+2+xy");
            var result3 = ep.Calculate("10-2-x");

            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);

            Console.ReadKey();
        }
    }

    public class ExpressionProcessor
    {
        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        public int Calculate(string expression)
        {
            var result = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                var character = expression[i];

                if (char.IsNumber(character))
                {
                    result = GetNumerick(expression, ref i);

                    continue;
                }

                if (character == '+')
                {
                    i += 1;
                    result += GetNumerick(expression, ref i);

                    continue;
                }

                if (character == '-')
                {
                    i += 1;
                    result -= GetNumerick(expression, ref i);

                    continue;
                }

                result = GetNumerick(expression, ref i);
            }

            return result;
        }

        public int GetNumerick(string expression, ref int i)
        {
            var character = expression[i];

            if (!char.IsNumber(character))
            {
                if (Variables.ContainsKey(character))
                {
                    return Variables[character];
                }

                return 0;
            }

            for (int j = i; j < expression.Length; j++)
            {
                if (j == expression.Length - 1)
                {
                    var numberText = expression.Substring(i, j - i <= 0 ? 1 : j -1);
                    var number = int.Parse(numberText);
                    i = j;

                    return number;
                }

                if (!char.IsNumber(expression[j]))
                {
                    var numberText = expression.Substring(i, j - i);
                    var number = int.Parse(numberText);
                    i = j - 1;

                    return number;
                }
            }

            return 0;
        }
    }
}
