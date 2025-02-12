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
        /*------------------------------------------------------------*/
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
        /*------------------------------------------------------------*/
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
        /*------------------------------------------------------------*/
        // Task 14:  Find the Type of Triangle
        /*int side1 = Convert.ToInt32(Console.ReadLine());
        int side2 = Convert.ToInt32(Console.ReadLine());
        int side3 = Convert.ToInt32(Console.ReadLine());
        if (side1 == side2 && side1 == side3)
            Console.WriteLine("This triangle is Equilateral");
        else if ((side1 == side2 && side1 != side3) || (side2 == side3 && side2 != side1))
            Console.WriteLine("This triangle is Isosceles ");
        else Console.WriteLine("This triangle is Scalene");*/
        /*------------------------------------------------------------*/
        //TASK 15: Check Uppercase or Lowercase
        /*char input = Convert.ToChar(Console.ReadKey());
        if (char.IsUpper(input))
            Console.WriteLine("Inputed char is upper case");
        else Console.WriteLine("Inputed char is lower case");*/
        /*------------------------------------------------------------*/
        // TASK 16: Find BMI (Body Mass Index)
        /*int weight = Convert.ToInt32(Console.ReadLine());
        double height = Convert.ToDouble(Console.ReadLine());
        double bmi = Convert.ToDouble(weight / (height * height));
        if (bmi < 18.5) Console.Write($"Your BMI is {bmi} and you have Underweight");
        else if (bmi >= 18.5 && bmi <= 24.9) Console.Write($"Your BMI is {bmi} and you have Normal waight");
        else if (bmi >= 25 && bmi <= 29.9) Console.Write($"Your BMI is {bmi} an you have Overweight");
        else Console.Write("You have Obease");*/
        /*------------------------------------------------------------*/
        // Task 17: Set or Clear the K-th Bit of a Number
        /*Console.WriteLine("please input the number and index");
        int num = Convert.ToInt32(Console.ReadLine());
        int index = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Choose the operation 1 - for set bit, 2 - for clear");
        int operation = Convert.ToInt32(Console.ReadLine());
        if (operation == 1)
            num |= (1 << index);
        else if (operation == 2)
            num &= ~(1 << index);
        Console.WriteLine(num);*/
        /*------------------------------------------------------------*/
        // Task 18: Check if a String Starts or Ends With a Specific Character
        /*string input = Console.ReadLine();
        char sym = Console.ReadKey().KeyChar;
        char[] arr = input.ToCharArray();
        Console.WriteLine();
        if (arr[0] == sym && arr[^1] == sym)
            Console.WriteLine($"the input is starts and ends with {sym} ");
        else Console.WriteLine($"the input is not starts and ends with {sym} ");*/
        /*------------------------------------------------------------*/
        //Task 19: Create a 2D Array and Fill It with Numbers
        int[,] array = new int[3, 3];
        Random rand = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = rand.Next(100);
            }
        }

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + "\t");
            }

            Console.WriteLine();
        }
        /*------------------------------------------------------------*/
        //Task 20: Create a Jagged Array and Fill It with Numbers 
        int[][] array = new int[3][];
        Random rand = new Random();
        int arrLength = 0;
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"Input length for array {i + 1}");
            arrLength = Convert.ToInt32(Console.ReadLine());
            array[i] = new int[arrLength];
            for (int j = 0; j < array[i].Length; j++)
            {
                array[i][j] = rand.Next(100);
            }
        }
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j] + "\t");
            }
            Console.WriteLine();
        }

       
    }
}