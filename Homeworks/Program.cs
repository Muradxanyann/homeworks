using System;
using System.Threading.Channels;

//Task 1: Basic Calculator
/*Task: Write a program with methods for basic math operations:
Add(int a, int b), Subtract(int a, int b), Multiply(int a, int b), Divide(int a, int b)
Read 2 numbers from user input, read operation code and then display the result.
    Close the program if received X from the user.
    Use recursion to make the calculator run until it gets the X.*/

public static class MyMethods
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
    public static int Subtract(int a, int b)
    {
        return a - b;
    }
    public static long Multiply(int a, int b)
    {
        return (long)a * b;
    }
    public static int Devide(int a, int b, out double fraction)
    {
        if (b == 0)
        {
            Console.WriteLine("Error, can`t devide number to 0");
            fraction = 0;
            return 0;
        }
        fraction = a % b;
        return a / b;
    }
    
}

static class Calculator
{
    public static long BasicCalcualtor(int num1, int num2, char userOperand)
    {
        switch (userOperand)
        {
            case '+':
                return MyMethods.Add(num1, num2);
            case '-':
                return MyMethods.Subtract(num1, num2);
            case '*':
                return MyMethods.Multiply(num1, num2);
            case '/':
                double remainder;
                int result = MyMethods.Devide(num1, num2, out remainder);
                Console.WriteLine($"Quotient: {result}, Remainder: {remainder}");
                return result;
            default:
                Console.WriteLine("Invalid operator");
                return 0;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        char userAnwer = ' ';
        while (char.ToUpper(userAnwer) != 'X')
        {
            Console.WriteLine("Please input numbers");
            string userX = Console.ReadLine();
            string userY = Console.ReadLine();

            if (!int.TryParse(userX, out int num1) || (!int.TryParse(userY, out int num2)))
            {
                Console.WriteLine("Parsing faled");
                return;
            }

            Console.WriteLine("Please choose the operand:  \'+' \'-' \'*' \'/'");
            char operand = Convert.ToChar(Console.ReadLine());
            long result = Calculator.BasicCalcualtor(num1, num2, operand);
            Console.WriteLine($"Result: {result}");
            Console.WriteLine("If you want to use this calculator, enter any key, except /'X'");
            userAnwer = Console.ReadKey(true).KeyChar;
        }
    }
}
/*-------------------------------------------------------------------------------------------*/
//Task 2:  Swap Two Numbers
/* Task: Write a program to swap 2 numbers:
Write a method to swap the values of two integers.
    Use ref in method parameters.
    Read 2 numbers from user input and validate the input values.   */
class Program
{
    public static void ChangeValues(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Please input numbers");
        string userX = Console.ReadLine();
        string userY = Console.ReadLine();

        if (!int.TryParse(userX, out int a) || (!int.TryParse(userY, out int b)))
        {
            Console.WriteLine("Parsing faled");
            return;
        }

        Console.WriteLine($"Before swapping a - {a}, b -{b}");
        ChangeValues(ref a, ref b);
        Console.WriteLine($"After swapping a - {a}, b -{b}");
    }
}
/*-------------------------------------------------------------------------------------------*/
//Task3: Write a program to find max from input numbers array:
/* Write a method to find the maximum value from an array of input numbers.
    Use ref and params in method parameters.
    Read numbers from user input.  */
class Program
{
    public static int MaxValue(params int[]array)
    {
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max) max = array[i];
        }

        return max;
    }
    static void Main(string[] args)
    {
        int[] array = new int[5];
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"Please input value for element {i + 1}");
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        int max = MaxValue(array);
        Console.WriteLine($"Max value in array is {max}");
    }
}
/*-------------------------------------------------------------------------------------------*/
    //Task 4: Convert Temperature
/*Task: Write a program for temperature conversion:
Write a method that converts Celsius to Fahrenheit and Kelvin.
    Use ref and out in method parameters.
    Call it with a user-provided Celsius value.*/

    class Program
    {
        public static double ConvertToFahrenheit(double Celsius, out double kelvin)
        {
            kelvin = Celsius + 273.15;
            return Celsius * 1.8 + 32;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (!Double.TryParse(input, out double celsius))
            {
                Console.WriteLine("Parsing failed");
                return;
            }
            double fahrenheit = ConvertToFahrenheit(celsius, out double kelvin);
            Console.WriteLine($"{celsius}C to fahreniheit {fahrenheit} to kelvin {kelvin}");
        }    
    }
    /*-------------------------------------------------------------------------------------------*/
    //Task 5: Calculate Area and Perimeter
    /*Task: Write a program for circle basic calculations:
    Write a method that calculates area and perimeter of a circle from radius.
        Use ref and out in method parameters.
        Call it with a user-provided radius value.*/
    class Program
    {
        public static double AreaCalc(double radius, out double parimeter)
        {
            const double pi = 3.14;
            double area = pi * (radius * radius);
            parimeter = 2 * pi * radius;
            return area;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (!Double.TryParse(input, out double radius))
            {
                Console.WriteLine("Parsing failed");
                return;
            }

            double area = AreaCalc(radius, out double parimeter);
            Console.WriteLine($"Radius: {radius} - Area: {area :F2} - Parimeter: {parimeter:F2}");
        }
    }
    /*-------------------------------------------------------------------------------------------*/
    //Task 6: Sum of Any Numbers
    /*Task: Write a program for numbers sum calculation:
    Write a method that calculates the sum of the numbers in an array.
        Use params in method parameters.
        Read numbers from user input.*/
    class Program
    {
        public static int Sum(params int[]array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
        static void Main(string[] args)
        {
            int[] array = new int[5];
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Please input value for element {i + 1}");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            int sum = Sum(array);
            Console.WriteLine($"Sum value in array is {sum}");
        }
    }

    /*-------------------------------------------------------------------------------------------*/
    //Task 7: Solve Quadratic Equation
    /*Task: Write a program for solving Quadratic Equation:
    Write a method that calculates two roots using the quadratic formula: x = [-b ± √(b2 - 4ac)]/2a.
        Use ref and out in method parameters.
        Call it with a user-provided a, b and c values.*/
     class Program
    {
        public static bool SolveQuadratic(double a, double b, double c, out double root1, out double root2)
        {
            root1 = 0;
            root2 = 0;
            double discriminant = b * b - 4 * a * c;
            if (a == 0)
            {
                Console.WriteLine("A cannot be 0).");
                return false;
            }

            if (discriminant < 0)
            {
                Console.WriteLine("No roots .");
                return false;
            }

            double sqrtDisc = Math.Sqrt(discriminant);

            root1 = (-b + sqrtDisc) / (2 * a);
            root2 = (-b - sqrtDisc) / (2 * a);

            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter coefficients for the quadratic equation (ax^2 + bx + c = 0):");
            string inputA = Console.ReadLine();
            string inputB = Console.ReadLine();
            string inputC = Console.ReadLine();

            if (!double.TryParse(inputA, out double a) ||
                !double.TryParse(inputB, out double b) ||
                !double.TryParse(inputC, out double c))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            if (SolveQuadratic(a, b, c, out double root1, out double root2))
            {
                Console.WriteLine($"Root 1: {root1:F2}");
                Console.WriteLine($"Root 2: {root2:F2}");
            }
        }
    }
    /*-------------------------------------------------------------------------------------------*/
    //Task 8: Fibonacci Sequence
    /*Task: Write a program that returns n-th number from Fibonacci Sequence:
    Write a recursive method that returns the n-th number in Fibonacci Sequence.
        Call it with a user-provided n.*/
    class Program
    {
        public static int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fib(n - 1) + Fib(n - 2);
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int n))
            {
                Console.WriteLine("Parsing failed");
                return;
            }

            int fibNum = Fib(n);
            Console.WriteLine(fibNum);
        }
    }
    /*-------------------------------------------------------------------------------------------*/
   // Task 9: Time Converter
    /*Task: Write a program that converts seconds to time:
    Write a method that converts totalSeconds into hours, minutes, and seconds.
        Use ref and out in method parameters.
        Call it with a user-provided totalSeconds.*/
    class Program
    {
        public static void  totalSeconds(int totalSec, out int hours, out int minutes, out int seconds)
        {
            hours = totalSec / 3600;
            minutes = (totalSec % 3600) / 60;
            seconds = minutes % 60;
            Console.WriteLine($"{totalSec} seconds - {hours} hours, {minutes} minutes and {seconds} seconds");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please input seconds and this program will convert to hours, minutes, seconds ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int totalSec))
            {
                Console.WriteLine("Parsing faled");
                return;
            }
            
            totalSeconds(totalSec, out int hours, out int minutes, out int seconds);

        }
    }
    /*-------------------------------------------------------------------------------------------*/
    //Task 10:  Find the Longest Word
    /*Task: Write a program to find the longest word from the input words array:
    Write a method that returns the longest word from the input words array.
        Use params in method parameters.
        Call it with a user-provided words array.*/
    class Program
    {
        public static string LongestWord(params string[] str)
        {
            string longestWord = str[0];
            int maxLength = str[0].Length;
            for (int i = 1; i < str.Length; i++)
            {
                if (maxLength < str[i].Length)
                {
                    maxLength = str[i].Length;
                    longestWord = str[i];
                }
            }
            return longestWord;
        }
        static void Main(string[] args)
        {
            string someString = Console.ReadLine();
            string[] array = someString.Split(' ');
            string longestWord = LongestWord(array);
            Console.WriteLine($"Longest word is {longestWord}");
        }
    }

    