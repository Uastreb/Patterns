using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using static Composite.Program;

namespace Composite
{
    public class Program
    {
        static void Main(string[] args)
        {
            ManyValues manyValues = new ManyValues();
            manyValues.Add(1);
            manyValues.Add(2);

            SingleValue singleValue = new SingleValue();

            singleValue.Value = 2;

            var t  = singleValue.Sum();
            var e = manyValues.Sum();

            Console.ReadKey();
        }

        public interface IValueContainer : IEnumerable<int>
        {

        }

        public class SingleValue : IValueContainer
        {
            public int Value;

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IEnumerator<int> GetEnumerator()
            {
                yield return Value;
            }
        }

        public class ManyValues : List<int>, IValueContainer
        {

        }
    }

    public static class ExtensionMethods
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach (var c in containers)
                foreach (var i in c)
                    result += i;
            return result;
        }
    }

}
