using System;

namespace Coding.Exercise
{
    class Program
    {
        public static void Main()
        {
            var a = new Triangle(new RasterRenderer()).ToString();

            Console.ReadKey();
        }
    }

    public abstract class Shape
    {
        protected IRenderer _renderer;
        public string Name { get; set; }

        public Shape(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public override string ToString()
        {
            return $"Drawing {Name} as {_renderer.WhatToRenderAs}";
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base (renderer)
        {
            Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer)
        {
            Name = "Square";
        }
    }

   public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs => "lines";
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs => "pixels";
    }
}
