using System;
using System.Reflection.Metadata;

     /*Create a Contact class with:
    Name, PhoneNumber, and Email properties.
    A method DisplayInfo() to print contact details.
    A Main() method where the user can create 3 contacts and display them.
    Store contacts in an array and allow searching by name.
    #1#*/
/*public class Contact
{
    public string Name;
    public string PhoneNumber;
    public string Email;

    public Contact(string name, string phoneNumber, string email )
    {
        this.Name = name;
        this.PhoneNumber = phoneNumber;
        this.Email = email;
    }

     public  void DisplayInfo()
    {
        Console.WriteLine($"Hello {Name}\nYour number: {PhoneNumber}\nYour email: {Email}");
    }
    
}
class Program
{
    static void Main()
    {
        Contact[] contactArray = new Contact[3]
        {
            new Contact("Gor", "+37411223344", "gor.email@gmail.com"),
            new Contact("Armen", "+37411556677", "armen.email@gmail.com"),
            new Contact("Karen", "+37411889900", "karen.email@gmail.com")
        };
        foreach (var contact in contactArray)
        {
            contact.DisplayInfo();
        }

        Console.WriteLine("Input name to search:");
        string input = Console.ReadLine();
        foreach (var contact in contactArray)
        {
            if (contact.Name.ToLower() == input.ToLower())
            {
                Console.WriteLine($"The name was found!!!\n{contact.Name}`s phone number is: {contact.PhoneNumber}\n" +
                                  $"And email: {contact.Email}");
                return;
            }
            
        Console.WriteLine($"The {input} is not found in your contacts!!!");
            
        }
    }
}*/
/*--------------------------------------------------------------------------------------------------------
//Task 2: Student Management
/*Task: Create a Student class with:
    Name, Age, and Grade properties.
    A DisplayDetails() method.
    In Main(), create 5 students, store them in an array, and display their details.*/
     /*public class Student
     {
         private string Name;
         private int Age;
         private double GradeProperties;

         public Student(string name, int age, double properties)
         {
             this.Name = name;
             this.Age = age;
             this.GradeProperties = properties;
         }

         public void DisplayDetails()
         {
             Console.WriteLine($"Name: {Name}\nAge: {Age}\nGrade Proparties: {GradeProperties}");
         }
     }
     class Program{
         static void Main(string[] args)
         {
             Student[] students = new Student[5]
             {
                 new Student("Armen", 20, 9.1),
                 new Student("Sona", 21, 8.5),
                 new Student("Karine", 22, 7.8),
                 new Student("Emma", 23, 8.9),
                 new Student("Levon", 19, 9.5)
             };
             int count = 1;
             foreach (var i in students)
             {
                 Console.WriteLine($"Student {count++} Info");
                 i.DisplayDetails();
                 Console.WriteLine();
             }
         }
     }*/
     //Task 3: Bank Account
     /*Task: Create a BankAccount class with:
         AccountNumber, HolderName, Balance.
         Methods Deposit(amount) and Withdraw(amount), ensuring balance never goes negative.
         In Main(), allow the user to create an account and perform deposits/withdrawals.
         Prevent withdrawal if insufficient funds and show an error message.*/
     public class BankAccount
     {
         private int AccountNumber;
         private string HolderName;
         private double Balance;

         public BankAccount(int accountNumber, string holderName, double balance)
         {
             this.AccountNumber = AccountNumber;
             this.HolderName = holderName;
             this.Balance = balance;
         }
         public void Deposit(double deposit)
         {
             this.Balance += deposit;
             Console.WriteLine($"Credit Aproved!!!\n Your balance: {Balance}$ ");
         }

         public void Withdraw(double withdraw)
         {
             if (this.Balance - withdraw < 0)
             {
                 Console.WriteLine($"Operation failed, your balance is not enough, Your balance: {Balance}");
                 return;
             }

             this.Balance -= withdraw;
             Console.WriteLine($"Purchase Aproved!!!\n Your balance: {Balance}$ ");
             
         }
     }

     class Program
     {
         static void Main(string[] args)
         {
             BankAccount user = new BankAccount(1, "someName", 100);
             user.Deposit(10);
             user.Withdraw(120);
         }
     }