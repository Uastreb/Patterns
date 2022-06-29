using System;

namespace Coding.Exercise
{
    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            var obj1 = func();
            var obj2 = func();

            return ReferenceEquals(obj1, obj2);
        }
    }

    public class Program
    {
        public static void Main(object[] args)
        {

        }
    }
}

