/* Task 1: Custom List Implementation
Task: Create a custom list based on an array with dynamic size adjustment.
Implement an indexer for element access, a Length property, and methods for adding 
and removing elements. Ensure proper validation when accessing indices. */

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

class Person
{
    private static int _id = 0;
    public int Id {get;}
    public  string Name { get; set;}

    public Person()
    {
        Name = "Unknown";
        Id = ++_id;
    }
    public Person(string name)
    {
        Name = name;
        Id = ++_id;
    }

    public void ShowPersonInfo()
    {
        System.Console.WriteLine($"Name: {Name} || Id: {Id}");
    }
}

class CustomerList 
{
    private Person[] _people;
    private int _size;
    public int Length => _size; 

    public CustomerList (int capacity = 3)
    {
        _people = new Person[capacity];
        _size = 0;
    } 

    public Person this[int index]
    {
        get
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException($"Index must be beetwen 0 - {Length - 1}");
            }
            return _people[index];
        }
        set
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException($"Setting Index must be beetwen 0 - {Length - 1}");
            }
            _people[index] = value;
        }
    }

    public  void ShowListInfo()
    {
        
        for (int i = 0; i < Length; i++)
        {
            
            _people[i]?.ShowPersonInfo();
        }
    }


    public void Resize()
    {
        int newSize = _people.Length * 2;
        Person[] NewArray= new Person[newSize];
        Array.Copy(_people, NewArray, _size);
        _people = NewArray;
    }

    public void Add (Person person)
    {
        if (_size == _people.Length)
        {
            Resize();
        }
        _people[_size++] = person;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _size)
            throw new IndexOutOfRangeException($"Index must be between 0 and {_size - 1}");

        for (int i = index; i < Length - 1; i++)
        {
            _people[i] = _people[i + 1];
        }
        _people[--_size] = default!;
    }
}

class Program 
{
    static void Main(string[] args)
    {
        CustomerList list  = new CustomList(5);
        list.Add(new Person("Ashot"));
        list.ShowListInfo();
    }
}

/* Task 2:  Multilevel Secure Data Storage
Task: Design a secure storage system where data is accessed using indexers.
 Implement different access levels for reading and writing data.
 The system should enforce proper access control based on the caller’s role. */

        enum UserRole
        {
            Admin,
            User,
            Guest
        }
        class Data
        {
            public string FileName { get; set; }
            public int Size { get; set; }

            public Data (string fileName, int size)
            {
                FileName = fileName;
                Size = size;
            }
        }
        
        class SecureSystem
        {
            private Data[] _data;
            private  UserRole[] userRoles = new UserRole[3];

            public SecureSystem(int size) 
            {
                _data = new Data[size];
            }

            

    public Data this[UserRole role, int index]
    {
        get
        {
            if (index < 0 || index >= _data.Length)
                throw new IndexOutOfRangeException("Index out of range!");

            if (_data[index] == null)
                throw new NullReferenceException("Data is undefined!");

            if (role < userRoles[index])
                throw new UnauthorizedAccessException("Not enough role!");

            return _data[index];
        }
        set
        {
            if (role != UserRole.Admin)
                throw new UnauthorizedAccessException("Only admin can change value !");

            if (index < 0 || index >= _data.Length)
                throw new IndexOutOfRangeException("index out of range!");

            _data[index] = value;
        }
    }
 }

class Program 
{
    static void Main(string[] args)
    {
        SecureSystem storage = new SecureSystem(4);
        storage[UserRole.Admin, 0] = new Data("name", 10);
        //storage[UserRole.User, 0] = new Data("name", 10);
    }
}
/* Task 4:  Advanced Banking System with Transactions
Task: Design a banking system where accounts support deposit, withdrawal, and balance transfer.
Implement static utilities for currency conversion. 
Use ref parameters to modify balances and out parameters to return transaction details. */

 class BankSystem
{
    public string HolderName{ get; private set; }
    public decimal Balance { get; private set; }

    public BankSystem(string name, decimal balance = 0)
    {
        HolderName = name;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
        ShowBalance();
    }

    public void Withdraw(decimal amount)
    {
        if (amount > this.Balance)
        {
            throw new ArgumentException("Not enoguh resources");
        }
        this.Balance -= amount;
        ShowBalance();
    }

    public void Transfer(ref BankSystem obj, decimal amount,  out string transactionDetails, char currency = '#')
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero");
        }
        switch (currency)
        {
            case '#':
                if (amount > this.Balance)
                {
                     throw new ArgumentException("Not enoguh resources for transfer");
                }
                this.Balance -= amount;
                obj.Balance += amount;
                transactionDetails =$"Transferred {amount:F2} AMD from {HolderName} to {obj.HolderName}";
                break;
        
        case '$':
            if (amount * 390 > this.Balance)
            {
                throw new ArgumentException("Not enoguh resources for transfer");
            }
            this.Balance -= amount * 390;
            obj.Balance += amount;
            transactionDetails = $"Transferred {amount:F2} USD ({amount * 390:F2} AMD) from {HolderName} to {obj.HolderName}";
                   
            break;
        case '&':
            if (amount * 420 > this.Balance)
            {
                throw new ArgumentException("Not enoguh resources for transfer");
            }
            this.Balance -= amount * 420;
            obj.Balance += amount;
            transactionDetails = $"Transferred {amount:F2} EUR ({amount * 420:F2} AMD) from {HolderName} to {obj.HolderName}";
            break;
        
        default:
        {
            transactionDetails = default!;
            throw new ArgumentException("invalid currency");
        }
        }
            

        System.Console.WriteLine("Succesful transfer!");
        ShowBalance();
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Balance == {this.Balance :F2} AMD");
    }

    public static decimal  ConvertToUsd (decimal amountInDram)
    {
        return amountInDram / 390;
    }

    public static decimal  ConvertToEuro (decimal amountInDram)
    {
        return amountInDram / 420;
    }
}

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Please choose currency for tranfer: # - for AMD, $ - for Dollar, & - for euro");
        BankSystem obj1 = new BankSystem("Armen");
        string transactionDetails;
        obj1.Deposit(10000);
        BankSystem obj2 = new BankSystem("Artur");
        obj2.Deposit(10000);
        obj1.Transfer(ref obj2, 10, out transactionDetails, '$');
        System.Console.WriteLine(transactionDetails);
    }
} 

/* Task 5: Create a cache system that stores objects(documents) using an indexer. 
Implement automatic cleanup of stale objects based on time or memory constraints.
 The system should use a static member to track total cached objects. */

 class Document 
{
    public int MemoryUse{ get; private set; }
    public int TimePeriod{ get; private set; }
    
    public Document (int memoryUse, int timePeriod)
    {
        MemoryUse = memoryUse;
        TimePeriod = timePeriod;
    }

    public void ShowDocumentInfo()
    {
        System.Console.WriteLine($"Document memory using: {MemoryUse} || Execution time period: {TimePeriod}");
    }

}

class Cache
{
    private Document[] _documents;
    public static int _cachedFiles;
    public int Capacity {get; private set; }


    public Cache (int capacity = 5) 
    {
        if (capacity < 0) throw new ArgumentOutOfRangeException("Capacity must be positive");
        Capacity = capacity;
        _documents = new Document[Capacity];
        _cachedFiles++;
    } 

    public Document this[int index]
    {
        get 
        {
            if (index < 0 || index >= Capacity)
            {
                throw new ArgumentOutOfRangeException($"index must be in range 0 - {Capacity - 1 }");
            }
            return _documents[index];
        }

        set
        {
            if (index < 0 || index >= Capacity)
            {
                throw new ArgumentOutOfRangeException($"index must be in range 0 - {Capacity - 1 }");
            }
            _documents[index] = value;
        }

    }

    public void AllDocumentInfo()
    {
        foreach (var doc in _documents)
        {
            doc?.ShowDocumentInfo();
        }
    }
    public void CleanCache()
    {
        bool cleaned = false;
        for (int i = 0; i < Capacity; i++)
        {
            if (_documents[i] != null && (_documents[i].MemoryUse > 100 || _documents[i].TimePeriod > 1000))
            {
                _documents[i] = default!;
                cleaned = true;
            }
        }
        
        if (cleaned)
        {
            Console.WriteLine("Cache cleaned successfully.");
        }
        else
        {
            Console.WriteLine("No documents matched cleanup criteria.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Cache file1 = new Cache(5);
        file1[0] = new Document(100, 1200);
        file1.AllDocumentInfo();
    }
} 

/* Task 6: Custom Notification System
Task: Create a notification system where different users can register messages 
dynamically and retrieve them later. */

 class User
{
    public string Name { get; private set; }

    public User (string name) => Name = name;

    public async Task<string> GetDataAsync(string notification, int seconds)
    {
        await Task.Delay(seconds * 1000); 
        return notification;
    }
}

class Program 
{
    static async Task Main(string[] args)
    {
        User user = new User ("Ashot");
        string result = await user.GetDataAsync("You need to have a dinner", 10);
        System.Console.WriteLine(result);
    }
} 

