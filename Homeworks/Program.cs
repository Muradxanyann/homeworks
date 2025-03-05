using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

/* Task: Create a Person class with the following:
FirstName and LastName as auto-properties.
A read-only property FullName that is computed only once when accessed for the first time (lazy initialization).
Ensure FullName is stored internally and does not change if FirstName or LastName are modified. */

 class Person
{
    public string Name{get;set;}
    public string LastName{get;set;}

    private readonly Lazy<string> _fullName; 
    public string FullName => _fullName.Value;
    
    public Person (string name, string lastName) 
    {
        Name = name;
        LastName = lastName;
        _fullName = new Lazy<string> (() => $"{Name} {LastName}");
    }

    public void ShowInfo()
    {
        System.Console.WriteLine($"Name: {Name}\nLastname: {LastName}");
    }
}

class Program
{
    static void Main (string[] args)
    {
        Person person = new Person("Artak", "Galstyan");
        person.ShowInfo();
        System.Console.WriteLine(person.FullName);
    }
} 

/*-------------------------------------------------------------------------------------------*/

/* Task 2:  Property with Validation and Default Value
Task: Create a Product class that contains:
A Price property that:
Cannot be negative.
If set to a negative value, defaults to 0.
A Stock property that:
Cannot be negative.
If set to a negative value, defaults to 10. */

 class Product 
{
    private double _price;
    private int _stock;

    public double Price
    {
        get { return _price; }
        set
        {
            if(value < 0)
            {
                System.Console.WriteLine("Cant set negative value, using default value 0");
            }
            _price = value;
        }
    }

    public int Stock
    {
        get { return _stock; }
        set
        {
            if(value < 0)
            {
                System.Console.WriteLine("Cant set negative value, using default value 10");
                _price = 10;
            }
            _price = value;
        }
    }
} 

/* Task 3:  Computed Property with String Formatting
Task: Create a TimePeriod class with:
A property TotalSeconds (int).
A computed property FormattedTime that returns "HH:mm:ss" format. */

 class TimePeriod 
{
    private int _totalSeconds;

    public int TotalSeconds
    {
        get { return _totalSeconds; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Seconds cant be negative");
            }
            _totalSeconds = value;
        }
    }

    public string FormattedTime
    {
        get { return FormattedTimeCreator(_totalSeconds);}
    }

    public TimePeriod(int totalSeconds)
    {
        TotalSeconds = totalSeconds;
    }

    public string FormattedTimeCreator(int totalSec)
    {
        int hours = totalSec / 3600;
        int temp  = totalSec % 3600;
        int minutes = temp / 60;
        int seconds = temp % 60;

        return $"{hours :D2}:{minutes :D2}:{seconds:D2}";  
    }
}

class Program
{
    static void Main(string[] args)
    {
        TimePeriod time = new TimePeriod(3601);
        System.Console.WriteLine(time.FormattedTime);

    }
} 
/* ------------------------------------------------------------------------------- */
/* Task 4:  Student Grades
Task: Create a Students class that stores grades:
Implement an indexer where:
The key is a subject name.
The value is a grade.
If the subject doesn’t exist, return -1.
Use only arrays. */

class Student
{
    public string Name { get; set; }
    private string[] subjects;
    private int[] grades;

    public int this[string subjectName]
    {
        get 
        {
            for (int i = 0; i < subjects.Length; i++)    
            {
                if (subjectName == subjects[i])
                {
                    return grades[i];
                }
            }
            return -1;
        }
        set
        {
            for (int i = 0; i < subjects.Length; i++)
            {
                if (subjects[i] == subjectName)
                {
                    grades[i] = value;
                    return;
                }
            }

            
            for (int i = 0; i < subjects.Length; i++)
            {
                if (subjects[i] == null) 
                {
                    subjects[i] = subjectName;
                    grades[i] = value;
                    return;
                }
            }
        }
    }
    

    public Student (string studentName, int countOfSubjects)
    {
        Name = studentName;
        subjects = new string[countOfSubjects];
        grades = new int[countOfSubjects];
    }

    public void ShowStudentInfo()
    {
        Console.WriteLine($"Student: {Name}");
        for (int i = 0; i < subjects.Length; i++)
        {
            Console.WriteLine($"Subject: {subjects[i]} | Grade: {grades[i]}");
        }
    }

    
}
class Program 
{
    static void Main (string[] args)
    {
        Student student1 = new Student("Ashot", 3);

        student1["Math"] = 85;
        student1["Physics"] = 90;
        student1["History"] = 78;

        student1.ShowStudentInfo();
        
    }
}

/* -------------------------------------------------------------------------------- */
/* Task 5:  Multi-Parameter Indexer for 3D Space
Task: Create a Grid3D class that:
Stores values in a 3D space (x, y, z coordinates).
Uses an indexer with three integer parameters.
Throws an error if any index is out of bounds. */

 class Grid3D
{
    public int X{ get; set; }
    public int Y{ get; set; }

    public int Z{ get; set; }
    private int[,,] _cube;

    public int[,,]Cube => _cube;
    

    public Grid3D(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
        _cube = new int[X, Y, Z ];
    }

    public int this[int indexX, int indexY, int indexZ]
    {
        get 
        {
            if (indexX < 0 || indexX >= X || indexY < 0 || indexY >= Y || indexZ < 0 || indexZ >= Z)
            {
                throw new ArgumentOutOfRangeException("The coordinates must be within the range 0 <= index < size.");
            }
            return _cube[indexX, indexY, indexZ];
        }

        set
        {
            if (indexX < 0 || indexX >= X || indexY < 0 || indexY >= Y || indexZ < 0 || indexZ >= Z)
            {
                throw new ArgumentOutOfRangeException("The coordinates must be within the range 0 <= index < size.");
            }
            _cube[indexX, indexY, indexZ] = value;
        }
    }   

}

class Program 
{
    static void Main(string[] args)
    {
        Grid3D cube1 = new Grid3D(2,2,2);
        cube1[1,1,1] = 43;
        System.Console.WriteLine(cube1[1, 1,1]);
    }
} 

/* ------------------------------------------------------------------------------ */
/* Task: Create a ContactArray class that:
Stores contacts as Person objects.
Allows searching contacts by ID or Name using two separate indexers.
Returns null if no contact is found */

 class Person
{
    public string Name { get; set; }
    private static int _id  = 0;
    public int Id { get ;}
    public Person(string name)
    {
        Name = name;
        Id = ++_id;
    }

    public void ShowPersonInfo()
    {
        System.Console.WriteLine($"Name: {Name}\nId: {Id}");
    }

}

class Contacts 
{
    Person[] contacts;
    public Contacts(int contactsCount)
    {
        contacts = new Person[contactsCount];
    }

    public Person this[int index]
    {
        get 
        {
            if (index < 0 || index >= contacts.Length)
                throw new ArgumentOutOfRangeException($"index must be between 0 to {contacts.Length - 1} ");
            return contacts[index];
        }
        set 
        {
            if (index < 0 || index >= contacts.Length)
                throw new ArgumentOutOfRangeException($"index must be between 0 to {contacts.Length - 1} ");
            contacts[index] = value;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Contacts contacts = new Contacts(3);

        contacts[0] = new Person("Gugo");
        contacts[1] = new Person("Davo");
        contacts[2] = new Person("Armen");
        contacts[0].ShowPersonInfo();
        contacts[5].ShowPersonInfo();
    }
} 
