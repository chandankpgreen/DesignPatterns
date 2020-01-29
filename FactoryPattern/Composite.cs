using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
   interface Graphic
    {
        void Move(int x, int y);
        void Draw();
    }
    class Dot : Graphic
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Dot(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Draw()
        {
            Console.WriteLine("Draw a dot at x, y.");
        }

        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }
    }
    class Circle2: Dot
    {
        public int Radius { get; set; }

        public Circle2(int x, int y, int radius): base(x, y)
        {
           
            Radius = radius;
            
        }
        public new void Draw()
        {
            Console.WriteLine("Draw a Circle at x, y with Radius.");
        }

    }

    class CompoundGraphic : Graphic
    {
        List<Graphic> children;
        public void Draw()
        {
            Console.WriteLine("Draw the compoud graphic using all children");
        }
        public void AddChild(Graphic graphic)
        {
            this.children.Add(graphic);
        }

        public void RemoveChild(Graphic graphic)
        {
            this.children.Remove(graphic);
        }

        public void Move(int x, int y)
        {
            foreach (var child in children)
            {
                child.Move(x, y);
            }
        }
    }


}
