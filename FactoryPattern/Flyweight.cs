using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns
{
    class TreeType
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string  Texture { get; set; }

        public TreeType(string name, string color, string texture)
        {
            Name = name;
            Color = color;
            Texture = texture;
        }
       
    }
    class Tree
    {
        public int X { get; set; }
        public int Y { get; set; }
        TreeType treeType { get; set; }

       public  Tree(int x, int y, TreeType treetype)
        {
            X = x;
            Y = y;
            treeType = treetype;
        }
        public void Draw(int x, int y)
        {
            Console.WriteLine($"Drawing tree at coordinates {x} and {y}");
        }
    }

    class TreeFactory
    {
        public static List<TreeType> TreeTypes { get; set; }
        public static TreeType GetTreeType(string name, string color, string texture)
        {
            var foundTreeType = TreeTypes.FirstOrDefault(x => x.Color == color && x.Name == name && x.Texture == texture);
            
            if (foundTreeType == null)
            {
                var newTreeType = new TreeType(name, color, texture);
                TreeTypes.Add(newTreeType);
                return newTreeType;
            }
            else
            {
                return foundTreeType;
            }
        }
    }
}
