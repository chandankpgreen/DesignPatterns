using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    abstract class AbstractFurnitureFactory
    {
        public abstract Chair GetChair();
        public abstract CoffeeTable GetCoffeeTable();
        public abstract Sofa GetSofa();
    }

    class ConcreteModernFurnitureFactory : AbstractFurnitureFactory
    {
        public override Chair GetChair()
        {
            return new ModernChair();
        }

        public override CoffeeTable GetCoffeeTable()
        {
            return new ModernCoffeeTable();
        }

        public override Sofa GetSofa()
        {
            return new ModernSofa();
        }
    }

    class ConcreteVictorianFurnitureFactory : AbstractFurnitureFactory
    {
        public override Chair GetChair()
        {
            return new VictorianChair();
        }

        public override CoffeeTable GetCoffeeTable()
        {
            return new VictorianCoffeeTable();
        }

        public override Sofa GetSofa()
        {
            return new VictorianSofa();
        }
    }

    class ConcreteClassicFurnitureFactory : AbstractFurnitureFactory
    {
        public override Chair GetChair()
        {
            return new ClassicChair();
        }

        public override CoffeeTable GetCoffeeTable()
        {
            return new ClassicCoffeeTable();
        }

        public override Sofa GetSofa()
        {
            return new ClassicSofa();
        }
    }


    abstract class Chair
    {

    }
    abstract class CoffeeTable
    {

    }
    abstract class Sofa
    {

    }

    class VictorianChair : Chair
    {

    }
    class ModernChair: Chair
    {

    }
    class ClassicChair: Chair
    {

    }

    class VictorianCoffeeTable : CoffeeTable
    {

    }
    class ModernCoffeeTable : CoffeeTable
    {

    }
    class ClassicCoffeeTable : CoffeeTable
    {

    }

    class VictorianSofa : Sofa
    {

    }
    class ModernSofa : Sofa
    {

    }
    class ClassicSofa : Sofa
    {

    }
}
