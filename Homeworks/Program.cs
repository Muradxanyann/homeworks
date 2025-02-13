using System;

class Program
{
    static void Main()
    {
        //Task 1: Fibonacci Sequence Generator
        /*Console.WriteLine("Please input a number");
        int first = 0, second = 1, temp = 0;
        string input = Console.ReadLine();
        int num;
        if (!int.TryParse(input, out num))
        {
            Console.WriteLine("Parsing failed!!!");
            return;
        }

        Console.Write($"First {num} numbers in Fibonachii sequence {first}, {second}, ");
        for (int i = 2; i < num; i++)
        {
            temp = second;
            second += first;
            first = temp;
            Console.Write(second + ", ");
        }*/
        /*------------------------------------------------------------*/
        //Task 2: Reverse a Number
        /*Console.WriteLine("Please input a number");
        string input = Console.ReadLine();
        int reverse = 0;
        int number;
        if (!int.TryParse(input, out number))
        {
            Console.WriteLine("Parsing failed!!!");
            return;
        }

        int originalNumber = number;
        while(number != 0)
        {
            reverse = reverse * 10 + number % 10;
            number /= 10;
        }

        Console.WriteLine($"The reversed version of number {originalNumber} is {reverse}");*/
        /*------------------------------------------------------------*/
        //Task 3: Sum of Digits
        /*Console.WriteLine("Please input a number");
        string input = Console.ReadLine();
        int sum = 0;
        int number;
        if (!int.TryParse(input, out number))
        {
            Console.WriteLine("Parsing failed!!!");
            return;
        }
        int originalNumber = number;
        while(number != 0)
        {
            sum += number % 10;
            number /= 10;
        }

        Console.WriteLine($"The sum of digits in number {originalNumber} is {sum}");*/
        /*------------------------------------------------------------*/
        //Task 4: Multiplication Table
        /*Console.WriteLine("Please input a number");
        string input = Console.ReadLine();
        int number;
        if (!int.TryParse(input, out number))
        {
            Console.WriteLine("Parsing failed!!!");
            return;
        }

        Console.WriteLine($"The Multiplication Table of number {number}:");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{i} * {number} = {i * number}");
        }*/
        /*------------------------------------------------------------*/
        //Task 5: Prime Number Checker
        string input = Console.ReadLine();
        int number;
        if (!int.TryParse(input, out number))
        {
            Console.WriteLine("Parsing failed!!!");
            return;
        }

        for (int i = 2; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                Console.WriteLine($"The number {number} isn`t prime");
                break;
            } 
        }
        Console.WriteLine($"The number {number} is prime");
        
        

    }
}