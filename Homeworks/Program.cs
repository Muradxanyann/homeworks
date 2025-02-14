using System;

class Program
{
    static void Main()
    {
        //Task 1: Fibonacci Sequence Generator
        Console.WriteLine("Please input a number");
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
        }
        /*------------------------------------------------------------*/
        //Task 2: Reverse a Number
        Console.WriteLine("Please input a number");
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

        Console.WriteLine($"The reversed version of number {originalNumber} is {reverse}");
        /*------------------------------------------------------------*/
        //Task 3: Sum of Digits
        Console.WriteLine("Please input a number");
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

        Console.WriteLine($"The sum of digits in number {originalNumber} is {sum}");
        /*------------------------------------------------------------*/
        //Task 4: Multiplication Table
        Console.WriteLine("Please input a number");
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
        }
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
        /*------------------------------------------------------------*/
        //Task 6: Collatz Conjecture
        Console.WriteLine("Please input a number");
        string input = Console.ReadLine();
        int number, count = 0;
        if (!int.TryParse(input, out number))
        {
            Console.WriteLine("Parsing failed!!!");
            return;
        }
        
        while (number != 1)
        {
            count++;
            if (number % 2 == 0) number /= 2;
            else number = 3 * number + 1;
        }

        Console.WriteLine($"The loop was executed {count} times");
        // Task 7: Number Pyramid
        Console.WriteLine("Please input a number");
        string input = Console.ReadLine();
        int number, count = 0;
        if (!int.TryParse(input, out number))
        {
            Console.WriteLine("Parsing failed!!!");
            return;
        }

        for (int i = 0; i < number; i++)
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write(i);
            }

            Console.WriteLine();
        }
        //Task 9: Finding the Longest Word in a Sentence
        string sentence = Console.ReadLine();
        int count = 0, maxCount = 0, index = 0; 
        
        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i] != ' ') count++;
            else
            {
                if (count > maxCount)
                {
                    maxCount = count;
                    index = i - maxCount;
                }
                count = 0;
            }
        }

        if (count > maxCount)
        {
            maxCount = count;
            index = sentence.Length - maxCount;
        }
        
        string sub = sentence.Substring(index, maxCount);
        Console.WriteLine($"the Longest Word in a Sentence has  " +
                          $"length {maxCount} and the longest Word is {sub}");
        /*------------------------------------------------------------*/
        // Task 10: Maze Solver (Grid Navigation)
        char[,] map =
        {
            {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'}
        };
        char player = 'P';
        int userX = 5, userY = 5;
        Random rand = new Random();
        map[rand.Next(1,map.GetLength(0) - 1), rand.Next(1,map.GetLength(1) - 1)] = 'X';
        while (map[userX, userY] != 'X')
        {
            
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);  
                }

                Console.WriteLine();
            }
            Console.SetCursorPosition(userY, userX);
            Console.Write('P');

            ConsoleKeyInfo charKey = Console.ReadKey();
            switch (charKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if (map[userX - 1, userY] != '#')
                    {
                        userX--;
                    } 
                    break;
                case ConsoleKey.DownArrow :
                    if (map[userX + 1 , userY] != '#')
                    {
                        userX++;
                    } 
                    break;
                case ConsoleKey.LeftArrow:
                    if (map[userX, userY - 1] != '#')
                    {
                        userY--;
                    } 
                    break;
                case ConsoleKey.RightArrow:
                    if (map[userX, userY + 1] != '#')
                    {
                        userY++;
                    } 
                    break;
            }
            Console.Clear();
            
        }

        Console.WriteLine("Congratulation you found X");

    }
}