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
        string input = Console.ReadLine();
        int number;
        int weak = 0, day = 0;
        if (int.TryParse(input, out number))
        {
            weak = number / 7;
            day = number % 7;
            Console.WriteLine(($"{number} day is equal {weak} weak and {day} day "));
        }
    }
}