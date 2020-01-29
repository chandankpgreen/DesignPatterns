using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Color { get; set; }

        public Shape()
        {

        }
        public Shape(Shape source)
        {
            this.X = source.X;
            this.Y = source.Y;
            this.Color = source.Color;
        }

        public abstract Shape Clone();
       
    }

    class Rectangle : Shape
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public Rectangle(int length, int width)
        {
            this.Length = length;
            this.Width = width;
        }
        public Rectangle(Rectangle rectangle): base(rectangle)
        {
            this.Length = rectangle.Length;
            this.Width = rectangle.Width;
        }

        public override Shape Clone()
        {
            return new Rectangle(this);

        }
    }

    class Circle: Shape
    {
        public int Radius { get; set; }
        public Circle(int radius)
        {
            this.Radius = radius;
        }
        public Circle(Circle circle): base(circle)
        {
            this.Radius = circle.Radius;
        }
        public override Shape Clone()
        {
            return new Circle(this);

        }
    }
}
