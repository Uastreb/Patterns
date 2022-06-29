using System;
using System.Text;

namespace MyStringBuilder
{
    public class MyStringBuilder
    {
        private readonly StringBuilder _text;

        #region Ctors

        public MyStringBuilder()
        {
            _text = new StringBuilder();
        }

        public MyStringBuilder(int capacity)
        {
            _text = new StringBuilder(capacity);
        }

        public MyStringBuilder(string value)
        {
            _text = new StringBuilder(value);
        }

        public MyStringBuilder(int capacity, int maxCapacity)
        {
            _text = new StringBuilder(capacity, maxCapacity);
        }

        public MyStringBuilder(string value, int capacity)
        {
            _text = new StringBuilder(value, capacity);
        }

        public MyStringBuilder(string value, int startIndex, int length, int capacity)
        {
            _text = new StringBuilder(value, startIndex, length, capacity);
        }

        #endregion

        #region Append

        public void Append(string value)
        {
            _text.Append(value);
        }

        public void Append(bool value)
        {
            _text.Append(value);
        }

        public void Append(byte value)
        {
            _text.Append(value);
        }

        public void Append(char value)
        {
            _text.Append(value);
        }

        public void Append(char[] value)
        {
            _text.Append(value);
        }

        public void Append(decimal value)
        {
            _text.Append(value);
        }

        public void Append(double value)
        {
            _text.Append(value);
        }

        public void Append(float value)
        {
            _text.Append(value);
        }

        public void Append(int value)
        {
            _text.Append(value);
        }

        public void Append(long value)
        {
            _text.Append(value);
        }

        public void Append(object value)
        {
            _text.Append(value);
        }

        public void Append(sbyte value)
        {
            _text.Append(value);
        }

        public void Append(short value)
        {
            _text.Append(value);
        }

        public void Append(uint value)
        {
            _text.Append(value);
        }

        public void Append(ulong value)
        {
            _text.Append(value);
        }

        public void Append(ushort value)
        {
            _text.Append(value);
        }

        public void Append(char value, int repeatCount)
        {
            _text.Append(value, repeatCount);
        }

        public void Append(char[] value, int startIndex, int charCount)
        {
            _text.Append(value, startIndex, charCount);
        }

        public void Append(string value, int startIndex, int count)
        {
            _text.Append(value, startIndex, count);
        }

        #endregion

        #region AppendLine

        public void AppendLine()
        {
            _text.AppendLine();
        }
        public void AppendLine(string value)
        {
            _text.AppendLine(value);
        }

        #endregion

        #region Operators

        public static MyStringBuilder operator + (MyStringBuilder a, string b)
        {
            a._text.Append(b);

            return a;
        }

        public static implicit operator string(MyStringBuilder myStringBuilder) => myStringBuilder._text.ToString();
        public static explicit operator MyStringBuilder(string text) => new MyStringBuilder(text);

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new MyStringBuilder();

            a += "safasfsa";

            a = (MyStringBuilder)"fsasafs";
            
            Console.WriteLine(a);

            Console.ReadLine();
        }
    }
}
