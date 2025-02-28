using System;
using System.Linq;
using System.Text;

 /*Task 1: Bank Account System with Custom Object Comparisons
 Task: Develop a BankAccount class that supports:
 1. Custom String Representation (ToString() Override)
 Format: "Account: [AccountNumber], Balance: [Balance] USD"
 2. Equality Check (Equals() and GetHashCode())
 Two accounts are equal if they have the same AccountNumber.
 3. Overloaded + and - Operators for Transactions
 + should deposit money.
 - should withdraw money but prevent overdraft.
 4. Comparison Operators (>, <, >=, <=)
 Compare accounts based on balance.*/

 class BankAccount
 {
     public int AccountNumber{get; private set;}
     public string CustomerName{get; set;}
     public decimal Balance {get; private set;}

     public BankAccount(int accountNumber, string customerName, decimal balance = 0)
     {
         AccountNumber = accountNumber;
         CustomerName = customerName;
         Balance = balance;
     }

     public override string ToString()
     {
         return $"Customer name: {CustomerName}\nAccount number: {AccountNumber}\nBalance: {Balance}$\n";
     }

     public override bool Equals(object? obj)
     {
         if (obj is BankAccount other)
         {
             return this.AccountNumber == other.AccountNumber;
         }
         return false;
     }

     public override int GetHashCode()
     {
         return HashCode.Combine(this.AccountNumber, this.Balance, this.CustomerName);
     }

     public static BankAccount operator +(BankAccount account1, int deposit)
     {
         account1.Balance += deposit;
         return account1;
     }

     public static BankAccount operator -(BankAccount account1, int withdraw)
     {
         if(account1.Balance < withdraw)
         {
             System.Console.WriteLine("Balance cant be negative");
             return account1;
         }
         account1.Balance -= withdraw;
         return account1;
     }

     public static bool operator > (BankAccount account1, BankAccount account2)
     {
         return account1.Balance > account2.Balance;
     }

     public static bool operator < (BankAccount account1, BankAccount account2)
     {
         return account1.Balance < account2.Balance;
     }

     public static bool operator >= (BankAccount account1, BankAccount account2)
     {
         return account1.Balance >= account2.Balance;
     }

     public static bool operator <= (BankAccount account1, BankAccount account2)
     {
         return account1.Balance <= account2.Balance;
     }


 }


class Program
 {
     static void Main()
     {
         BankAccount account = new BankAccount(1, "Joe");
         account += 1000;
         system.console.writeline(account);

     }
 }
/*-----------------------------------------------------------------------------------------------------------*/
/*Task 2:  3D Vector Class with Overloaded Operators
Task: Create a Vector3D class representing a three-dimensional vector. Implement the following:
1. Override ToString()
Format: "(X, Y, Z)"
2. Overload Arithmetic Operators
+ to add vectors.
- to subtract vectors.
* to multiply by a scalar.
/ to divide by a scalar (handle division by zero).
3. Overload Equality Operators (==, !=)
Two vectors are equal if all components are equal.
4. Implement Equals() and GetHashCode() Consistently
5. Overload true and false Operators
A vector is "true" if it's non-zero, otherwise "false".
6. Overload >, <, >=, <= Based on Magnitude*/


class Vector3D
{
    public int X {get; set;}
    public int Y {get; set;}
    public int Z {get; set;}

    public Vector3D(int x, int y, int z)
    {
        X = z;
        Y = y;
        Z = z;
    }

    public override string ToString()
    {
        return $"3D Vectors coordinates: X: {X}, Y: {Y}, Z: {Z}";
    }

    public static Vector3D operator +(Vector3D vec1, Vector3D vec2)
    {
        return new Vector3D(vec1.X + vec2.X, vec1.Y + vec2.Y,vec1.Z + vec2.Z);
    }

    public static Vector3D operator -(Vector3D vec1, Vector3D vec2)
    {
        return new Vector3D(vec1.X - vec2.X, vec1.Y - vec2.Y,vec1.Z - vec2.Z);
    }

    public static Vector3D operator *(Vector3D vec1, Vector3D vec2)
    {
        return new Vector3D(vec1.X * vec2.X, vec1.Y * vec2.Y,vec1.Z * vec2.Z);
    }

    public static Vector3D operator /(Vector3D vec1, Vector3D vec2)
    {
        if (vec2.X == 0 || vec2.Y == 0 || vec2.Z == 0)
        {
            System.Console.WriteLine("Cant divide by 0");
            return new Vector3D(0,0,0);
        }
        return new Vector3D(vec1.X - vec2.X, vec1.Y - vec2.Y,vec1.Z - vec2.Z);
    }

    public static bool operator ==(Vector3D vec1, Vector3D vec2)
    {
        return vec2.X == vec1.X && vec2.Y == vec1.Y && vec2.Z == vec1.Z;
    }
    public static bool operator !=(Vector3D vec1, Vector3D vec2)
    {
        return vec2.X != vec1.X || vec2.Y != vec1.Y || vec2.Z != vec1.Z;
    }
    public static bool operator true(Vector3D vec1)
    {
        return vec1.X != 0 && vec1.Y != 0 && vec1.Z !=0;
    }

    public static bool operator false(Vector3D vec1)
    {
        return vec1.X == 0 || vec1.Y == 0 || vec1.Z ==0;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Vector3D other)
        {
            return (Vector3D)obj == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X,Y,Z);
    }


}

/*-----------------------------------------------------------------------------------------------------------*/
/*Task 3:  Implement a BigInt Class in C#
Task: Implement a custom BigInt class in C# to handle arbitrarily large integers using strings or arrays.
    Class Definition:
Create a BigInt class with an appropriate private field (e.g., a string) to store large numbers.
    Constructors:
A constructor that takes a string as input and initializes the BigInt object.
    A constructor that takes an int for small numbers.
    Properties:
A Length property that returns the number of digits in the BigInt.
    Overloaded Operators:
Implement +, -, *, and ==, !=, <, >, <=, >= for BigInt objects.
    Ensure the subtraction operator works correctly for positive and negative results.
    Implement multiplication without directly converting to int or long.
    Methods:*/
    
class BigInt
{
    private int[] numbers;
    private bool isNegative;

    public BigInt(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new Exception("The input can`t be empty");
        }

        isNegative = input[0] == '-';
        string cleaned = isNegative ? input.Substring(1) : input;

        if (!cleaned.All(char.IsDigit))
        {
            throw new Exception("String must be contain only digits");
        }

        numbers = new int[cleaned.Length];
        for (int i = 0; i < cleaned.Length; i++)
        {
            numbers[i] = cleaned[cleaned.Length - 1 - i] - '0';
        }
    }

    public BigInt(int number) : this(number.ToString()) { } // karch tvi depqum kanchuma verevi constructorin
    
    public BigInt(int[] numbers, bool isNegative = false)
    {
        this.numbers = numbers;
        this.isNegative = isNegative;
    }
    public int Length
    {
        get { return numbers.Length; }
    }

    public static int[] AddArray(int[]array1, int[]array2)
    {
        int max = (array1.Length > array2.Length) ? array1.Length : array2.Length ;
        int[] result = new int[max + 1];
        int carry = 0;

        for (int i = 0; i < max; i++)
        {
            int digitA = i < array1.Length ? array1[i] : 0;
            int digitB = i < array2.Length ? array2[i] : 0;
            int sum = digitA + digitB + carry;
            result[i] = sum % 10;
            carry = sum / 10;
        }

        if (carry > 0)
            result[max] = carry;

        return result[^1] == 0 ? result[..^1] : result;
    }
    
    public static int[] SubtractArrays(int[] a, int[] b, bool isNegative)
    {
        int[] result = new int[a.Length];
        int borrow = 0;

        for (int i = 0; i < a.Length; i++)
        {
            int diff = a[i] - (i < b.Length ? b[i] : 0) - borrow;
            if (diff < 0)
            {
                diff += 10;
                borrow = 1;
            }
            else borrow = 0;

            result[i] = diff;
        }

        return result[^1] == 0 ? result[..^1] : result;
    }

    public static int[] MultiplyArrays(int[] array1, int[] array2)
    {
        int max = (array1.Length > array2.Length) ? array1.Length : array2.Length;
        int[] result = new int[max + 2];
        int carry = 0;
        int sum = 0;
        int totalSum = 0;
        for (int i = array1.Length - 1; i >= 0; i--)
        {
            for (int j = array2.Length - 1; j >= 0; j--)
            {
                int mult = array1[i] * array2[j] + carry;
                sum =sum * 10 + mult % 10; 
                carry = mult / 10;
            }

            totalSum += sum;
        }
        return result;
    }// kisat em toxum, qanzi el chi stacvum mtacel
    
    

    public static BigInt operator +(BigInt obj1, BigInt obj2)
    {
        if (obj1.isNegative == obj2.isNegative)
        {
            return new BigInt(AddArray(obj1.numbers, obj2.numbers),obj1.isNegative);
        }

        return new BigInt(SubtractArrays(obj1.numbers, obj2.numbers,obj1.isNegative));
    }
    public static BigInt operator -(BigInt obj1, BigInt obj2)
    {
        return new BigInt(SubtractArrays(obj1.numbers, obj2.numbers,obj1.isNegative));
    }

    public static bool operator ==(BigInt obj1, BigInt obj2)
    {
        return obj1.numbers.Length == obj2.numbers.Length;
    }
    public static bool operator !=(BigInt obj1, BigInt obj2)
    {
        return obj1.numbers.Length != obj2.numbers.Length;
    }
    public static bool operator > (BigInt obj1, BigInt obj2)
    {
        if (obj1.isNegative != obj2.isNegative) return obj2.isNegative;
        if (obj1.numbers.Length != obj2.numbers.Length)
        {
            return obj1.numbers.Length > obj2.numbers.Length;
        }
        for (int i = obj1.numbers.Length - 1; i >= 0; i--)
        {
            if (obj1.numbers[i] < obj2.numbers[i]) return false;
        }

        return true;
    }
    public static bool operator < (BigInt obj1, BigInt obj2)
    {
        if (obj1.isNegative != obj2.isNegative) return obj1.isNegative;
        if (obj1.numbers.Length != obj2.numbers.Length)
        {
            return obj1.numbers.Length < obj2.numbers.Length;
        }
        for (int i = obj1.numbers.Length - 1; i >= 0; i--)
        {
            if (obj1.numbers[i] < obj2.numbers[i]) return true;
        }

        return false;
    }
    
    public override string ToString()
    {
        if (numbers.Length == 0)
            return "0";

        StringBuilder sb = new StringBuilder();
        if (isNegative)
            sb.Append('-');

        for (int i = numbers.Length - 1; i >= 0; i--)
            sb.Append(numbers[i]);

        return sb.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        BigInt num1 = new BigInt("12345");
        BigInt num2 = new BigInt("-6789");

        BigInt sum = num1 + num2; 
        Console.WriteLine(sum);
    }
}