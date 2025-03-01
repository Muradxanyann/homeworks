using System;
using System.Numerics;
// Task 1: Water Tank System
// Concept: Simulate water tanks where water can be transferred or consumed.
// Requirements
// Implement a WaterTank class:
// Capacity (double, liters)
// CurrentLevel (double, liters)
// Overload + operator: Combine two water tanks (capped at the capacity limit).
// Overload - operator: Consume water from the tank (cannot go below 0).
// Override ToString() to display tank levels.

/*class WaterTank
{
     double Capacity = 10000;
    double CurrentLevel { get; set; }

    public WaterTank()
    {
        Capacity = 10000;
        CurrentLevel = 0;
    }
    public WaterTank(double CurrentLevel)
    {
        this.CurrentLevel = CurrentLevel;
    
    }

    public override string ToString() 
    {
        return $"Capacity: {Capacity}, CurrentLevel: {CurrentLevel}";
    }
    public static void Transfer(WaterTank obj1 ,WaterTank obj2 ,double amount)
    {
        if(obj1.CurrentLevel < amount)
        {
            Console.WriteLine("Not enough water");
            return;
        }
        if (obj2.CurrentLevel + amount > obj2.Capacity )
        {
            Console.WriteLine("Not enough capacity");
        }
        obj1.CurrentLevel -= amount;
        obj2.CurrentLevel += amount;
    }

    public static WaterTank operator +(WaterTank obj, double amount)
    {
        if (obj.CurrentLevel + amount > obj.Capacity)
        {
            Console.WriteLine("Not enough cap");
            return obj;
        }
        return new WaterTank(obj.CurrentLevel + amount);
    }

    public static WaterTank operator -(WaterTank obj, double amount)
    {
        if (obj.CurrentLevel - amount < obj.Capacity)
        {
            Console.WriteLine("Not enough water");
            return obj;
        }
        return new WaterTank(obj.CurrentLevel - amount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Capacity is always 10.000 L");
        WaterTank obj1 = new WaterTank();
        WaterTank obj2 = new WaterTank();
        obj1 = obj1 + 1000;
        obj2 = obj2 + 2000;
        WaterTank.Transfer(obj1, obj2, 10000);
        Console.WriteLine(obj1);
        Console.WriteLine(obj2);
    }
}*/

/*Task 2: Digital Ink Reservoir
   Concept: Simulate an ink reservoir in a digital pen where ink can be added or removed when writing.
   Requirements
Implement a InkReservoir class:
Color (string)
InkAmount (double, in milliliters)
Overload + operator:
Combine two ink reservoirs (if they have the same color).
If colors differ, prevent merging.
Overload - operator:
Subtract ink from a reservoir (simulating ink usage).
Prevent negative ink levels.
Override ToString() to return reservoir details.*/
class InkReservoir
{
    public string Color { get; private set; }
    public double InkAmount { get; private set; }
    
    public override string ToString()
    {
        return $"Color: {Color}, InkAmount: {InkAmount}";
    }

    public InkReservoir(string color, double inkAmount)
    {
        if (inkAmount < 0)
            throw new Exception("Ink amount cannot be negative.");
        
        Color = color;
        InkAmount = inkAmount;
    }

    public static InkReservoir operator +(InkReservoir obj1, InkReservoir obj2)
    {
        if (obj1.Color != obj2.Color)
        {
            throw new Exception("Cant merge different colors");
        }

        return new InkReservoir(obj1.Color, obj1.InkAmount + obj2.InkAmount);
    }
    public static InkReservoir operator -(InkReservoir obj1, double amount)
    {
        if (amount < 0 || amount > obj1.InkAmount)
        {
            throw new Exception("Cant remove negative amount");
        }

        return new InkReservoir(obj1.Color, obj1.InkAmount - amount);
    }
    
    
        
}