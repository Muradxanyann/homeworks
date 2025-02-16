using System;
using System.Reflection.Metadata;
using System.Threading.Channels;

/*
Create a Contact class with:
    Name, PhoneNumber, and Email properties.
    A method DisplayInfo() to print contact details.
    A Main() method where the user can create 3 contacts and display them.
    Store contacts in an array and allow searching by name.*/
    
public class Contact
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
}
/*--------------------------------------------------------------------------------------------------------*/
//Task 2: Student Management
/*Task: Create a Student class with:
    Name, Age, and Grade properties.
    A DisplayDetails() method.
    In Main(), create 5 students, store them in an array, and display their details.*/
     public class Student
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
     }
/*--------------------------------------------------------------------------------------------------------*/
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

         public BankAccount(int accountNumber, string holderName, double balance = 0)
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
/*--------------------------------------------------------------------------------------------------------*/
     //Task 4: Book Library
     /*Task: Create a Book class with:
         Title, Author, IsAvailable properties.
         A method BorrowBook() that sets IsAvailable = false.
         A method ReturnBook() that sets IsAvailable = true.
         In Main(), create 3 books, borrow one, and display availability status.
         Allow user interaction (choose which book to borrow/return).*/
     public class Book
     {
         private string Title;
         private string Author;
         private bool IsAvailable;

         public Book(string title, string author, bool Available)
         {
             this.Title = title;
             this.Author = author;
             this.IsAvailable = Available;
         }

         public bool isAvailable(string title)
         {
             if (this.Title.ToLower() == title.ToLower() && this.IsAvailable != false)
             {
                 this.IsAvailable = false;
                 Console.WriteLine("Enjoy your book, you have 15 days to read :)");
                 return true;
             }

             Console.WriteLine("This book isn`t available!!!");
                 return false;
         }

         public void ReturnBook(string title)
         {
             this.IsAvailable = true;
             Console.WriteLine("We hope that it was the right book for you:)");
             return;
         }
     }

     public class Program
     {
         static void Main(string[] args)
         {
             Book[] books = new Book[3]
             {
                 new Book("The Great Gatsby", "F. Scott Fitzgerald", true),
                 new Book("One Indian Girl", "Chetan Bhagat", false ),
                 new Book("A Million Mutinies Now", "V.S. Naipaul", true),
             };
             Console.WriteLine("Hi dear, which book do you prefer to borrow");
             string input = Console.ReadLine();
             foreach (var book in books)
             {
                 if (book.isAvailable(input) == true)
                 {
                     return;
                 }
             }
         }
     } 
     /*--------------------------------------------------------------------------------------------------------*/
     //Task 5: Online Shopping Cart
     /*Task: Create a Product class with:
         Name, Price, and Quantity.
         A method TotalPrice() that returns Price * Quantity.
         In Main(), allow the user to add multiple products to a shopping cart and calculate the total cost.
         If more than 5 items are purchased, apply a 10% discount.*/

     public class Product
     {
         /* Es xndri vra shat em xorace, heto hisha piti stugvie :)*/
         public string Name;
         public double Price;
         private int Quantity;

         public double TotalPrice()
         {
             if (this.Quantity == 0)
             {
                 Console.WriteLine("Your product bag is empty!!!");
                 return 0;
             }
             return Price * Quantity;
         } 
     }

     public class Program
     {
         static void Main(string[] args)
         {
             Console.WriteLine("Welcome to our grocery, here are our product list:");
             Product[] products = new Product[5]
             {
                 new Product { Name = "Apple", Price = 1.2 },
                 new Product { Name = "Banana", Price = 0.8 },
                 new Product { Name = "Milk", Price = 2.5 },
                 new Product { Name = "Bread", Price = 1.5 },
                 new Product { Name = "Eggs", Price = 3.0 }
             };
             foreach (var product in products)
             {
                 Console.WriteLine($"{product.Name} - {product.Price}$");
             }
             
             
              const int bagSize = 10;
              int choosenProducts = 0;
              double totalSum = 0;
             Console.WriteLine("The size of your bag is 10");
             Product[] productsBag = new Product[10];
             for (int i = 0; i < productsBag.Length; i++)
             {
                 Console.WriteLine("Please, select the product");
                 string input = Console.ReadLine();
                 bool found = false;
                 foreach (var product in products)
                 {
                     if (product.Name.Equals(input, StringComparison.OrdinalIgnoreCase)) // es funkcian gpt -ic em verce
                     {
                         Console.WriteLine($"Product '{input}' is available.");
                         totalSum += product.Price;
                         found = true;
                         if (choosenProducts < bagSize) choosenProducts++;
                         else
                         {
                             Console.WriteLine("Your bag is full");
                             return;
                         }
                         break;
                     }
                 }

                 if (found)
                 {
                     Console.WriteLine($"The product has been added in your shoping bag, " +
                                       $"you can add {bagSize - choosenProducts} more products");
                     Console.WriteLine("If you want to continue shoping enter '+' else(chekout) '-'");
                     char userAnswer = Convert.ToChar(Console.ReadLine());
                     if (userAnswer == '-')
                     {
                         //Chekout
                         if (choosenProducts > 5)
                         {
                             Console.WriteLine($"Total sum: {totalSum - totalSum / 10}$");    
                         }
                         Console.WriteLine($"Total sum: {totalSum}$");
                         return;
                     };
                 }
                 else
                 {
                     Console.WriteLine("Product not found.");
                 }
             }
         }
     }
     /*--------------------------------------------------------------------------------------------------------*/
     // Task 6: Employee Payroll System
     /*Task: Create an Employee class with:
         Name, Position, SalaryPerHour, and HoursWorked.
         A method CalculateSalary() that returns SalaryPerHour * HoursWorked.
         In Main(), create 3 employees, calculate their salaries, and display them.
         If an employee works over 40 hours, pay overtime (1.5x rate)*/
     public class Payroll
     {
         public string Name;
         private double SalaryPerHour;
         public int HouseWorked;

         public Payroll(string name, double salaryPerHour, int houseWorked )
         {
             this.Name = name;
             this.SalaryPerHour = salaryPerHour;
             this.HouseWorked = houseWorked;
         }

         public double CalculateSalary()
         {
             if (HouseWorked == 0)
             {
                 Console.WriteLine("Shut er petq mtacel...");
                 return 0;
             }
             return HouseWorked * SalaryPerHour;
         }
     }

     public class Program
     {
         static void Main(string[] args)
         {
             Payroll[] payrolls = new Payroll[]
             {
                 new Payroll ("Worker1", 10, 8),
                 new Payroll ("Worker2 ", 8, 6),
                 new Payroll ("Worker3 ", 15, 7)
             };
             for (int i = 0; i < payrolls.Length; i++)
             {
                 double salary = 0;
                 salary = payrolls[i].CalculateSalary();
                 if (payrolls[i].HouseWorked * 5 > 40) Console.WriteLine($"Worker {payrolls[i].Name} salary with bonuses{salary * 1,5}$");
                 else Console.WriteLine($"Worker {payrolls[i].Name} salary:{salary}$");
             }
         }
     }
/*--------------------------------------------------------------------------------------------------------*/
     //Task 7: Ticket Booking System
     /*Task: Create a MovieTicket class with:
         MovieName, SeatNumber, IsBooked.
         A method BookTicket() that marks it as booked.
         In Main(), create 5 seats, allow the user to book one, and prevent double booking.
         Show all available seats before booking*/
     public class MovieTicket
     {
         private string MovieName;
         public int SeatNumber;
         public bool IsBooked;

         public MovieTicket(string movieName, int seatNumber, bool isBooked = false)
         {
             this.MovieName = movieName;
             this.SeatNumber = seatNumber;
             this.IsBooked = isBooked;
         }

         public bool BookTicket(int seatNumber)
         {
             if (seatNumber == 0 || seatNumber > 5) return false;
             this.IsBooked = true;
             return true;
         }
     }

     public class Programm
     {
         static void Main(string[] args)
         {
             string movie = "Game of Thrones";
             MovieTicket[] bookingSystem = new MovieTicket[5];
             for (int i = 0; i < bookingSystem.Length; i++)
             {
                 bookingSystem[i] = new MovieTicket(movie, i + 1);
             }

             while (true)
             {
                 // Tpum enq azat texery
                 Console.WriteLine("Available sets");
                 for (int i = 0; i < bookingSystem.Length; i++)
                 {
                     if (bookingSystem[i].IsBooked == false) Console.WriteLine($"The seet {i + 1} is available");
                 }

                 //Booking proccess
                 Console.WriteLine("Which seat do you want to book");
                 int choice = Convert.ToInt32(Console.ReadLine());
                 if (choice >= 1 && choice <= bookingSystem.Length)
                 {
                     bookingSystem[choice - 1].BookTicket(choice);
                     Console.WriteLine($"Seat {choice} is booked: Input '+' to book another one, Or '0' to quit");
                     char key = Convert.ToChar(Console.ReadLine());
                     if (key == '0') break;

                 }

             }

         }
     }
     /*--------------------------------------------------------------------------------------------------------* /
     //Task 8: School System
     /*Task: Create a School Management System with:
        Student class (Name, Age, Grade).
         Teacher class (Name, Subject, YearsOfExperience).
         School class that stores students & teachers in an array.
         Show students with the highest grade and teachers with less than 2 years experience.
         */
     public class Student
     {
         public string Name;
         public int Age;
         public double Grade;

         public Student(string name, int age, double grade)
         {
             this.Name = name;
             this.Age = age;
             this.Grade = grade;
         }
     }

     public class Teacher
     {
         public string Name;
         public string Subject;
         public int YearsOfExperience;

         public Teacher(string name, string subject, int years)
         {
             this.Name = name;
             this.Subject = subject;
             this.YearsOfExperience = years;
         }
     }

     public class School
     {
         static void Main(string[] args)
         {
             Student[] students = new Student[]
             {
                 new Student ("Alice", 17, 95) ,
                 new Student ( "Bob",  18,  88 ),
                 new Student ( "Charlie" ,16,  95 ),
                 new Student (  "David", 17,   82 )
             };
             Teacher[] teachers = new Teacher[]
             {
                 new Teacher ( "Mr. Smith","Math", 1 ),
                 new Teacher ( "Ms. Johnson", "English", 5 ),
                 new Teacher ( "Mr. Brown",  "History", 2 ),
                 new Teacher ( "Mrs. White", "Science", 7)
             };
             Console.WriteLine("Students with highest grades");
             foreach (var i in students)
             {
                 if (i.Grade > 90 ) Console.WriteLine($"{i.Name} - {i.Grade}");
             }
             Console.WriteLine("teachers with less than 2 years experience");
             foreach (var i in teachers)
             {
                 if (i.YearsOfExperience < 2 ) Console.WriteLine($"{i.Name} - {i.YearsOfExperience}");
             }
         }
     }
     /*--------------------------------------------------------------------------------------------------------*/
     //Task 9: Car Rental System
     /*Task: Create a Car class with:
         Model, Year, IsRented.
         Methods RentCar() and ReturnCar().
         In Main(), create a fleet of 5 cars, let users rent and return cars.
         Prevent renting an already rented car.*/

     public class Car
     {
         public string Model;
         private int Year;
         private bool IsRented;


         public Car(string model, int year, bool isRented = false)
         {
             this.Model = model;
             this.Year = year;
             this.IsRented = isRented;
         }

         public bool RentCar()
         {
             if (this.IsRented)
             {
                 Console.WriteLine("This model is alredy taken");
                 return false;
             };
             this.IsRented = true;
             return true;
         }
         
         public bool ReturnCar()
         {
             this.IsRented = false;
             return true;
         }
     }

     class Program
     {
         static void Main(string[] args)
         {
             Car[] cars = new Car[]
             {
                 new Car("BMW", 2014),
                 new Car("Audi", 2013),
                 new Car("Merceders", 2012),
                 new Car("Porche", 2022),
                 new Car("Lexus", 2020)
             };
             
             while (true)
             {
                 Console.WriteLine("input the model:");
                 string input = Console.ReadLine();
                 bool carFound = false;
                 
                 foreach (var car in cars)
                 {
                     if (car.Model.Equals(input, StringComparison.OrdinalIgnoreCase))
                     {
                         carFound = true;
                         if (car.RentCar())
                         {
                             Console.WriteLine($"Enjoy your {car.Model}, you have 10 days!");
                         }
                         break;
                     }
                 }

                 if (!carFound)
                 {
                     Console.WriteLine("We don't have this model.");
                 }
                 
                 Console.WriteLine("Would you like to borrow another one: '1' - yes, '0' - no");
                 int userAnswer = Convert.ToInt32(Console.ReadLine());
                 if (userAnswer <= 0 || userAnswer > 1) break;
             }
             
         }
     }