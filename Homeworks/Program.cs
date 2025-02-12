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
        /*int side1 = Convert.ToInt32(Console.ReadLine());
        int side2 = Convert.ToInt32(Console.ReadLine());
        int side3 = Convert.ToInt32(Console.ReadLine());
        if (side1 == side2 && side1 == side3)
            Console.WriteLine("This triangle is Equilateral");
        else if ((side1 == side2 && side1 != side3) || (side2 == side3 && side2 != side1)) 
            Console.WriteLine("This triangle is Isosceles ");
        else Console.WriteLine("This triangle is Scalene");*/
        //TASK 15: Check Uppercase or Lowercase
        /*char input = Convert.ToChar(Console.ReadKey());
        if (char.IsUpper(input)) 
            Console.WriteLine("Inputed char is upper case");
        else Console.WriteLine("Inputed char is lower case");*/
        // TASK 16: Find BMI (Body Mass Index)
        /*int weight = Convert.ToInt32(Console.ReadLine());
        double height = Convert.ToDouble(Console.ReadLine());
        double bmi = Convert.ToDouble(weight / (height * height));
        if (bmi < 18.5) Console.Write($"Your BMI is {bmi} and you have Underweight");
        else if (bmi >= 18.5 && bmi <= 24.9) Console.Write($"Your BMI is {bmi} and you have Normal waight");
        else if (bmi >= 25 && bmi <= 29.9) Console.Write($"Your BMI is {bmi} an you have Overweight");
        else Console.Write("You have Obease");*/
        // Task 17: Set or Clear the K-th Bit of a Number

    }
}