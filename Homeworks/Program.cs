using System;

//Task 1: Student Management System
/*Task: Create a class Student with:
Fields: name, studentID, and gradeLevel.
    Add a method ShowStudentInfo() to display the details.
    In Main(), create a few Student objects and display their details.*/
class Student
{
    public string Name { get; set; }
    public int StudentId { get; }
    public int GradeLevel { get; private set; }

    public Student(string name, int studentId, int gradeLevel)
    {
        this.Name= name;
        this.StudentId = studentId;
        this.GradeLevel = gradeLevel;
    }

    public void ShowStudentInfo()
    {
        Console.WriteLine($"Name: {Name}\nStudent ID: {StudentId}\nGrade Level: {GradeLevel}\n");
    }
}

class Programm
{
    static void Main(string[] args)
    {
        Student[] students = new Student[]
        {
            new Student("Armen", 1, 1),
            new Student("Artak", 2, 2),
            new Student("Karen", 3, 7),
            new Student("Serj", 4, 9),
        };
        foreach (var student in students)
        {
            student.ShowStudentInfo();
        }
        
    }
}
/*-------------------------------------------------------------------------------------------------------*/

//Task 2: Flight Reservation System
/*Task: Create a class FlightTicket with:
Fields: passengerName, flightNumber, and seatNumber.
    Add a constructor to initialize these fields.
    In Main(), create a few tickets and print the details.*/
    
class FlightTicket
{
    public string PassengerName { get; set; }
    public int FlightNumber { get; private set; }
    public int SeatNumber { get; private set; }


    public FlightTicket(string passengerName, int flightNumber, int seatNumber)
    {
        PassengerName = passengerName;
        FlightNumber = flightNumber;
        SeatNumber = seatNumber;
    }

    public void TicketDetail()
    {
        Console.WriteLine($"Passenger Name: {PassengerName}\nFlight Number: {FlightNumber}\nSeatNumber: {SeatNumber}");
        Console.WriteLine(new string('-', 30));
    }
}

class Program
{
    static void Main(string[] args)
    {
        FlightTicket[] tickets = 
        {
            new FlightTicket("Tom", 111, 1),
            new FlightTicket("Jerry", 112, 2),
            new FlightTicket("Rick", 113, 3),
        };
        foreach (var ticket in tickets)
        {
            ticket.TicketDetail();
        }
    }
    
}
/*-------------------------------------------------------------------------------------------------------*/
//Task 3: File Download Simulation
/*Task: Create a class FileDownload with:
Constructor that prints "Download started".
    Add a destructor that prints "Download completed".
    In Main(), create an object inside a method and observe when the destructor is called.*/
    
class FileDownload
{
    public FileDownload()
    {
        Console.WriteLine("Download started");
    }
    
    ~FileDownload(){
        Console.WriteLine("Download completed");
    }
}

class Program
{
    static void CreateAndDestroy()
    {
        FileDownload file = new FileDownload();
    }

    static void Main(string[] args)
    {
        CreateAndDestroy();
    }
}
/*-------------------------------------------------------------------------------------------------------*/
//Task 4: Weather Forecast System
    /*  Task: Create a class WeatherReport with:
    Fields: temperature, humidity, and weatherCondition.
    In Main(), create an array of WeatherReport objects for different cities and display the reports.*/

    class WeatherReport
    {
        public double Temperature { get;  set; }
        public int Humidity { get;  set; }
        public string WeatherCondition { get;  set; }

        public void WeatherInfo()
        {
            Console.WriteLine($"Tempriture: {Temperature}\nHumidity: {Humidity}\nWeatherCondition: {WeatherCondition}");
            Console.WriteLine(new string('-', 30));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WeatherReport[] London =
            {
                new WeatherReport { Temperature = 15.5, Humidity = 70, WeatherCondition = "Cloudy" },
                new WeatherReport { Temperature = 22.3, Humidity = 60, WeatherCondition = "Sunny" },
                new WeatherReport { Temperature = 10.8, Humidity = 80, WeatherCondition = "Rainy" }
            };
            foreach (var weather in London)
            {
                weather.WeatherInfo();
            }
           
        }    
    }
/*-------------------------------------------------------------------------------------------------------*/
//Task 5: Smartwatch Step Counter
    /*Task: Create a class Smartwatch with:
    Fields: ownerName and stepCount.
        Add methods AddSteps(int steps) and ShowSteps().
        In Main(), create a smartwatch object, simulate adding steps, and display the total..*/

    using System.Net.NetworkInformation;

    class Smartwatch
    {
        public string OwnerName { get; set; }
        public int StepCount { get;  set; }

        public void AddSteps(int steps)
        {
            StepCount += steps;
        }

        public void ShowSteps()
        {
            Console.WriteLine($"Steps: {StepCount}");    
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Smartwatch person1 = new Smartwatch();
            //person1.AddSteps(100);
            person1.ShowSteps();
        }
    }
/*-------------------------------------------------------------------------------------------------------*/
    //Task 6: Movie Rating System
    /*Task: Create a class Movie with:
    Private field _rating.
        Add a property Rating that:
    Allows setting a value between 1 and 5.
        Prints a warning if an invalid value is entered.
        In Main(), test the property with valid and invalid values.*/

    class Movie
    {
        private int _rating;

        public int Rating
        {
            get { return _rating; }
            set
            {
                if (value < 1 || value > 5)
                {
                    Console.WriteLine("Invalid rating, choose from 1 to 5");
                    return;
                }
                _rating = value;
            }
        }

        public Movie(int rating)
        {
            Rating = rating;
        }

        public void ShowRating()
        {
            Console.WriteLine($"Rating: {Rating}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Movie movie1 = new Movie(7);
            Movie movie2 = new Movie(3);
            movie1.ShowRating();
            movie2.ShowRating();
        }
    }
/*-------------------------------------------------------------------------------------------------------*/

    //Task 7: Fitness Tracker System
    /*Task: Create a class WorkoutSession with:
    Fields: exerciseType and durationInMinutes.
        Add a method ShowWorkoutDetails().
        In Main(), create and display different workout sessions.*/

    class WorkoutSession
    {
        public string ExerciseType{get; set;}
        public int DurationInMinutes{get; set;}

        public WorkoutSession(string exerciseType, int durationInMinutes)
        {
            ExerciseType = exerciseType;
            DurationInMinutes = durationInMinutes;
        }

        public void ShowWorkoutDetails()
        {
            Console.WriteLine($"Exercise Type : {ExerciseType}\nDurition: {DurationInMinutes} minutes\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WorkoutSession[] sessions =
            {
                new WorkoutSession("Bench press", 10),
                new WorkoutSession("Biceps curl", 10),
            };
            foreach (var sesion in sessions)
            {
                sesion.ShowWorkoutDetails();
            }
        }
    }
    /*-------------------------------------------------------------------------------------------------------*/
    //Task 8: E-Commerce Product System
    /*Task: Create a class Product with:
    Fields name, price, and stockQuantity.
        Add a constructor that uses this to differentiate between parameters and fields.
        In Main(), create a product and display its details.*/

    class Product
    {
        private int _stockQuatity;
        public string Name { get; set; }
        public double Price { get; set; }

        public int StockQuantity
        {
            get { return _stockQuatity; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("In stock value can`t be negative, using default value 0");
                    this._stockQuatity = 0;
                    return;
                }
                _stockQuatity = value;
            }
        }

        public Product(string name, double price, int stockQuantity)
        {
            this.Name = name;
            this.Price = price;
            this.StockQuantity = stockQuantity;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Product name: {Name}\nPrice: {Price}\nIn stock: {StockQuantity}");
            Console.WriteLine(new string('-', 30));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("Potato", 200, 10);
            Product product2 = new Product("Orange", 200, -12);
            product1.ShowDetails();
            product2.ShowDetails();
        }
    }
    /*-------------------------------------------------------------------------------------------------------*/
    //Task 9: Game Character System
    /*Task: Create a partial class.
    Create a partial class Character in two separate files:
    One part contains fields characterName and level.
        The other contains a method ShowCharacterInfo().
        In Main(), create a Character object and call ShowCharacterInfo().*/
    /*-------------------------------------------------------------------------------------------------------*/
    //Task 10: Simulating Course Enrollment
    /*Task: Create a class Course with:
    Fields: courseName, instructor, and maxStudents.
        Use a constructor to initialize these fields.
        Add a method ShowCourseDetails().
        In Main(), create a few courses and display their details.*/

    enum Teachers
    {
        Ms_Grigorian = 1,
        Mr_Smith,
        Mr_Hakobian
    }
    class Course
    {
        public string CourseName { get; set; }
        public Teachers MyTeachers { get; set; }
        public int MaxStudents { get; set; }

        public Course(string courseName, Teachers myTeachers/*1 - 3 only*/, int maxStudents)
        {
            CourseName = courseName;
            MyTeachers = myTeachers;
            MaxStudents = maxStudents;
        }

        public void ShowCourseDetails()
        {
            Console.WriteLine($"Course name: {CourseName}\nTeacher: {MyTeachers}\nMax Students: {MaxStudents}");
            Console.WriteLine(new string('-', 30));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course("Math", Teachers.Ms_Grigorian, 100);
            course.ShowCourseDetails();
        }
    }