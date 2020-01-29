using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // Factory
            Creator[] creators = new Creator[2];
            creators[0] = new ProductACreator();
            creators[1] = new ProductBCreator();
            var producta = creators[0].Create();
            var productb = creators[1].Create();


            ////Abstract factory

            AbstractFurnitureFactory[] abstractFurnitureFactories = new AbstractFurnitureFactory[3];
            abstractFurnitureFactories[0] = new ConcreteClassicFurnitureFactory();
            abstractFurnitureFactories[1] = new ConcreteModernFurnitureFactory();
            abstractFurnitureFactories[2] = new ConcreteVictorianFurnitureFactory();

            var classicChair = abstractFurnitureFactories[0].GetChair();
            var classicSofa = abstractFurnitureFactories[0].GetSofa();

            /// Builder

            Director director = new Director();
            var carBuilder = new CarBuilder();
            director.SetBuilder(carBuilder);
            director.ConstructSportsCar();
            director.ConstructSUV();
            
            var car = carBuilder.ReturnProduct();

            var manualBuilder = new CarManualBuilder();
            director.SetBuilder(manualBuilder);
            director.ConstructSportsCar();
            director.ConstructSUV();
            var manual = manualBuilder.ReturnProduct();

            /// Prototype

            Shape[] shapes = new Shape[4];
            var circle = new Circle(23);
            circle.X = 200;
            circle.Y = 300;
            shapes[0] = circle;
            shapes[1] = circle.Clone();

            var rectangle = new Rectangle(10, 30);
            rectangle.X = 400;
            rectangle.Y = 500;
            shapes[2] = rectangle;
            shapes[3] = rectangle.Clone();

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.X);
            }

            //Adapter

            var sqPegAdapter = new SquarePegAdapter(new SquarePeg() { Side =10});
            var roundPeg = new RoundHole() { Radius = 10};
            Console.WriteLine(roundPeg.Fits(sqPegAdapter));

            // Bridge

            var tv = new Tv();
            var remote = new Remote(tv);
            remote.TogglePower();

            var radio = new Radio();
            remote = new Remote(radio);

            // Composite pattern

            var compoundGraphic = new CompoundGraphic();
            compoundGraphic.AddChild(new Dot(5, 10));
            compoundGraphic.AddChild(new Circle2(50, 100, 200));

            compoundGraphic.Move(400, 300);


            ///Decorator
            ///
            IFileHandler fileHandler = new TextFileHandler("D:\\MyText.txt");
            var bytes = fileHandler.ReadData();
            fileHandler.WriteData(fileHandler.ReadData(), "D:\\PlainText.txt");

            fileHandler = new CompressFileDecorator(fileHandler);
            fileHandler.WriteData(fileHandler.ReadData(), "D:\\CompressedText.txt");

            fileHandler = new EncryptFileDecorator(fileHandler);
            fileHandler.WriteData(fileHandler.ReadData(), "D:\\EncryptedText.txt");


            Console.ReadKey();

            // Flyweight
            var treeType = TreeFactory.GetTreeType("Banana", "Green", "Solid");
            var tree = new Tree(200, 300, treeType);


        }


    }
}

