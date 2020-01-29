using System;
using System.Collections.Generic;
using System.Text;

abstract class Product
{

}

class ProductA : Product
{

}

class ProductB : Product
{

}

abstract class Creator
{
    public abstract Product Create();
}

class ProductACreator : Creator
{
    public override Product Create()
    {
        var a = new ProductA();
        Console.WriteLine("Created Product A");
        return a;
    }
}

class ProductBCreator : Creator
{
    public override Product Create()
    {
        var a = new ProductB();
        Console.WriteLine("Created Product A");
        return a;
    }
}