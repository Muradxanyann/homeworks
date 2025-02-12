using System;

class Program
{
    static void Main()
    {
        //Task 11: Check If a Number Is Positive, Negative, or Zero 
        /*
        string input = Console.ReadLine();
        int number;
        if (int.TryParse(input, out number))
        {
            if (number > 0) Console.Write($"The number {number} is positive");
            else if (number < 0) Console.Write($"The number {number} is negative");
            else Console.Write($"The number {number} is non-positve && non-negative, its equal to zero");
        }*/
        //Task 12: Check Leap Year
        /*
        string input = Console.ReadLine();
        int year;
        if (int.TryParse(input, out year))
        {
            if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
                Console.Write($"The year {year} is a leep");
            else Console.Write($"The year {year} is not a leep");
        }
    }*/
        //Task 13: Convert Days to Weeks and Days
        /*string input = Console.ReadLine();
        int number;
        int weak = 0, day = 0;
        if (int.TryParse(input, out number))
        {
            weak = number / 7;
            day = number % 7;
            Console.WriteLine(($"{number} day is equal {weak} weak and {day} day "));
        }*/
        // Task 14:  Find the Type of Triangle
        int side1 = Convert.ToInt32(Console.ReadLine());
        int side2 = Convert.ToInt32(Console.ReadLine());
        int side3 = Convert.ToInt32(Console.ReadLine());
        if (side1 == side2 && side1 == side3)
            Console.WriteLine("This triangle is Equilateral");
        else if ((side1 == side2 && side1 != side3) || (side2 == side3 && side2 != side1)) 
            Console.WriteLine("This triangle is Isosceles ");
        else Console.WriteLine("This triangle is Scalene");
    }
}