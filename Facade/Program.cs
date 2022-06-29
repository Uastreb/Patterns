using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coding.Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new MagicSquareGenerator();
            var b = a.Generate(3);

            b.ForEach(i =>
            {
                i.ForEach(j =>
                {
                    Console.Write(j);
                });
                Console.WriteLine();
            });

            b.ForEach(i =>
            {
                var sum = 0;

                i.ForEach(j =>
                {
                    sum += j;
                });

                Console.WriteLine(sum);
            });

            Console.ReadLine();

        }
    }
    public class Generator
    {
        private static readonly Random random = new Random();

        public List<int> Generate(int count)
        {
            return Enumerable.Range(0, count)
              .Select(_ => random.Next(1, 6))
              .ToList();
        }
    }

    public class Splitter
    {
        public List<List<int>> Split(List<List<int>> array)
        {
            var result = new List<List<int>>();

            var rowCount = array.Count;
            var colCount = array[0].Count;

            // get the rows
            for (int r = 0; r < rowCount; ++r)
            {
                var theRow = new List<int>();
                for (int c = 0; c < colCount; ++c)
                    theRow.Add(array[r][c]);
                result.Add(theRow);
            }

            // get the columns
            for (int c = 0; c < colCount; ++c)
            {
                var theCol = new List<int>();
                for (int r = 0; r < rowCount; ++r)
                    theCol.Add(array[r][c]);
                result.Add(theCol);
            }

            // now the diagonals
            var diag1 = new List<int>();
            var diag2 = new List<int>();
            for (int c = 0; c < colCount; ++c)
            {
                for (int r = 0; r < rowCount; ++r)
                {
                    if (c == r)
                        diag1.Add(array[r][c]);
                    var r2 = rowCount - r - 1;
                    if (c == r2)
                        diag2.Add(array[r][c]);
                }
            }

            result.Add(diag1);
            result.Add(diag2);

            return result;
        }
    }

    public class Verifier
    {
        public bool Verify(List<List<int>> array)
        {
            if (!array.Any()) return false;

            var expected = array.First().Sum();

            return array.All(t => t.Sum() == expected);
        }
    }

    public class MagicSquareGenerator
    {
        private void ExecuteSeveralTimes(int count, int size, List<List<int>> matrix)
        {
            var generator = new Generator();
            matrix.Add(generator.Generate(size));

            count -= 1;
            if (count <= 0)
            {
                return;
            }

            ExecuteSeveralTimes(count, size, matrix);
        }

        public List<List<int>> Generate(int size)
        {
            var generator = new Generator();

            var matrix = new List<List<int>>();

            matrix.Add(generator.Generate(size));
            matrix.Add(generator.Generate(size));
            matrix.Add(generator.Generate(size));

            var verifier = new Verifier();
            var splitter = new Splitter();

            //ExecuteSeveralTimes(size, size, matrix);
            var splitMatrix = splitter.Split(matrix);
            var check = verifier.Verify(splitMatrix);
           
            

            return splitMatrix;
        }
    }
}
