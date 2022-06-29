using System;

namespace Coding.Exercise
{

    public class Point
    {
        public int X, Y;
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            return new Line()
            {
                End = new Point(),
                Start = new Point()
            };
        }
    }

    static class Programm
    {
        public static void Main()
        {
            var fistPoint = new Line() { Start = new Point() { X = 3, Y = 2 }, End = new Point() { X = 5, Y = 2 } };
            var secondPoint = fistPoint.DeepCopy();

            secondPoint.End.X = 10;

            Console.WriteLine($"{fistPoint.Start.X}:{fistPoint.Start.Y}  {fistPoint.End.X}:{fistPoint.End.Y}");
            Console.WriteLine($"{secondPoint.Start.X}:{secondPoint.Start.Y}  {secondPoint.End.X}:{secondPoint.End.Y}");

            Console.ReadLine();
        }
    }
}
