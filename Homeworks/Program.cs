/*  using System;
using System.Reflection.PortableExecutable;
Задача 1: Модульная платежная система
Задача: Разработать систему обработки платежей, в которой поддерживаются несколько 
способов оплаты (кредитная карта, PayPal, банковский перевод).
Убедиться, что новые способы оплаты можно добавлять без изменения существующей логики.
Ограничить прямое изменение деталей транзакции, разрешив проверки валидности.
Внедрить автоматический расчет комиссии за транзакцию на основе способа оплаты.
Разрешить динамический выбор способов оплаты во время оформления заказа. */

class Person
{
    public string Name { get; private set; }
    private decimal _balance;
    public decimal Balance 
    {
        get { return _balance; }
        set 
        {
            if (value < 0)
            {
                throw new ArgumentException("Balance cannot be negative");
            }
            _balance = value;
        }
    }

    public Person(string name, decimal balance)
    {
        Name = name;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative");
        }
        Balance += amount;
    }
    public bool Withdraw(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative");
        }
        if (Balance < amount)
        {
            throw new ArgumentException("Not enough money");
        }
        Balance -= amount;
        return true;
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"Balance: {Balance}");
    }
}
abstract class PaymentMethod
{
    public abstract void ProcessPayment(Person person, decimal amount);
    public virtual decimal CalculateCommission(decimal amount)
    {
        return amount * 0.02m;
    }
}

class CreditCardPayment : PaymentMethod
{
    public override void ProcessPayment(Person person, decimal  amount)
    {
        decimal commission = CalculateCommission(amount);
        if (!person.Withdraw(amount + commission))
        {
            throw new ArgumentException("Not enough money");
        }
        Console.WriteLine($"Payment of {amount} with Credit card with commission {commission} was processed");
    }

    public override decimal  CalculateCommission(decimal amount)
    {
        return amount * 0.03m;   
    }
}

class PayPal : PaymentMethod
{
    public override void ProcessPayment(Person person, decimal amount)
    {
        decimal commission = CalculateCommission(amount);
        if (!person.Withdraw(amount + commission))
        {
            throw new ArgumentException("Not enough money");
        }
        Console.WriteLine($"Payment of {amount} with PayPal with commission {commission} was processed");
    }

    public override decimal CalculateCommission(decimal amount)
    {
        return amount * 0.05m;
    }
}

class BankTransfer : PaymentMethod
{
    public override void ProcessPayment(Person person, decimal amount)
    {
        decimal commission = CalculateCommission(amount);
        if (!person.Withdraw(amount + commission))
        {
            throw new ArgumentException("Not enough money");
        }
        Console.WriteLine($"Payment of {amount} with Bank Transfer with commission {commission} was processed");
    }

    public override decimal CalculateCommission(decimal amount)
    {
        return amount * 0.01m;
    }
}

class Program 
{
    static void Main()
    {
        Person person = new Person("John", 1000);
        PaymentMethod paymentMethod = new CreditCardPayment();
        paymentMethod.ProcessPayment(person, 100);
        person.DisplayBalance();
        paymentMethod = new PayPal();
        paymentMethod.ProcessPayment(person, 100);
        person.DisplayBalance();
        paymentMethod = new BankTransfer();
        paymentMethod.ProcessPayment(person, 100);
        person.DisplayBalance();
        person.Deposit(100);
        person.DisplayBalance();
    }
}
 */

/*  Задача 2: Многоуровневая транспортная система
Задача: создать систему для управления различными типами транспортных средств,
 включая наземный, водный и воздушный транспорт.
Каждый тип транспортного средства должен иметь определенную логику движения
 и показатели расхода топлива.
Транспортные средства должны иметь общие атрибуты и поведение, 
но обрабатывать определенные элементы управления по-разному.
Реализовать систему, в которой пользователь может регистрировать,
 обновлять и извлекать данные о транспортном средстве, не зная заранее точного типа.
Предотвращать несанкционированные изменения основных атрибутов транспортного средства */

 abstract class Vehicle
{
    public string Model { get;  set; }
    public int FuelLevel { get; protected set; }

    public int FuelCapacity { get; set; }

    public Vehicle(string model, int fuelLevel, int fuelCapacity)
    {
        Model = model;
        FuelLevel = fuelLevel;
        FuelCapacity = fuelCapacity;
    }
    
    public virtual void  Refuel()
    {
        if (FuelLevel == FuelCapacity)
        {
            Console.WriteLine("Vehicle is already full");
            return;
        }
        if (FuelLevel + 10 > FuelCapacity)
        {
            FuelLevel = FuelCapacity;
            Console.WriteLine("Vehicle is full");
            return;
        }
        FuelLevel += 10;
        Console.WriteLine("Vehicle is refueled");
        
    }
    public virtual void Move()
    {
        FuelLevel -= 10;
        Console.WriteLine("Vehicle is moving");
    }

    public void DisplayFuelLevel()
    {
        Console.WriteLine($"Fuel level: {FuelLevel}");
    }
}

class Car : Vehicle
{
    
    public Car(string model, int fuelLevel, int fuelCapacity) : base(model, fuelLevel, fuelCapacity)
    { }
    public override void Move()
    {
        if (FuelLevel < 5)
        {
            Console.WriteLine("Not enough fuel");
            return;
        }
        FuelLevel -= 5;
        Console.WriteLine("Car is moving");
    }
}

class Ship : Vehicle
{
   
    public Ship(string model, int fuelLevel , int fuelCapacity) : base(model, fuelLevel, fuelCapacity)
    { }
    public override void Move()
    {
        if (FuelLevel < 20)
        {
            Console.WriteLine("Not enough fuel");
            return;
        }
        FuelLevel -= 20;
        Console.WriteLine("Ship is moving");
    }

    public override void Refuel()
    {
        if (FuelLevel == FuelCapacity)
        {
            Console.WriteLine("Ship is already full");
            return;
        }
        if (FuelLevel + 20 > FuelCapacity)
        {
            FuelLevel = FuelCapacity;
            Console.WriteLine("Ship is full");
            return;
        }
        FuelLevel += 20;
        Console.WriteLine("Ship is refueled");
    }
}

class Plane : Vehicle
{

    public Plane(string model, int fuelLevel, int fuelCapacity) : base(model, fuelLevel, fuelCapacity)
    {}
    public override void Move()
    {
        if (FuelLevel < 50)
        {
            Console.WriteLine("Not enough fuel");
            return;
        }
        FuelLevel -= 50;
        Console.WriteLine("Plane is moving");
    }

    public override void Refuel()
    {
        if (FuelLevel == FuelCapacity)
        {
            Console.WriteLine("Plane is already full");
            return;
        }
        if (FuelLevel + 50 > FuelCapacity)
        {
            FuelLevel = FuelCapacity;
            Console.WriteLine("Plane is full");
            return;
        }
        FuelLevel += 50;
        Console.WriteLine("Plane is refueled");
    }
}

class Program 
{
    static void Main()
    {
        Vehicle vehicle = new Car("Toyota", 0, 60);
        Vehicle vehicle1 = new Ship("Titanic", 0, 1000);
        Vehicle vehicle2 = new Plane("Boeing", 0, 2000);
        vehicle.Refuel();
        vehicle.Move();
        vehicle.Move();
        vehicle.Move();
        vehicle.DisplayFuelLevel();
    }
} 
/* 
Task 3:  Hierarchical Access Control
Task: Implement a security system where users have different 
roles (admin, manager, employee) with varying access levels to company resources.
Ensure restricted access to critical operations based on user roles.
Allow specific users to extend access permissions while preventing
 unauthorized modifications.
Implement a feature where user roles can be checked dynamically at runtime.
Optimize storage of access rights to avoid unnecessary duplication. */

 class User 
{
    public string Name { get; private set; }
    public string Role { get; private set; }

    public User(string name, string role)
    {
        Name = name;
        Role = role;
    }

    public void DisplayRole()
    {
        Console.WriteLine($"Role: {Role}");
    }
}

class Data 
{
    public string FileName { get; private set; }
    public int FileSize { get; private set; }

    public Data(string fileName, int fileSize)
    {
        this.FileName = fileName;
        this.FileSize = fileSize;
    }

    public void DisplayFileDetails()
    {
        Console.WriteLine($"File name: {FileName}, File size: {FileSize}");
    }
}

class Security
{
    private Data[] _data; 
    
    public Security(int maxData)
    {
        _data = new Data[maxData];
    }

    public Data this[User user,int index]
    {
        get 
        {
            if (index < 0 || index >= _data.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            if (user.Role == "cleaner")
            {
                throw new ArgumentException("Access denied");
            }
            System.Console.WriteLine("Data readed");
            return _data[index];
        }
        set 
        {
            if (index < 0 || index >= _data.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            if (user.Role == "admin")
            {
                _data[index] = value;
                System.Console.WriteLine("Data added");
            }
            else
            {
                throw new ArgumentException("Access denied");
            }
            
        }   
    }
    public virtual void CheckAccess(User user)
    {
        if (user.Role != "admin")
        {
            throw new ArgumentException("Access denied");
        }
        Console.WriteLine("Access granted");
    }
}

class Program 
{
    static void Main()
    {
        User user = new User("John", "admin");
        User user1 = new User("Mike", "manager");
        User user2 = new User("Tom", "employee");
        Security security = new Security(5);
        security[user, 0] = new Data("file1", 100);
        System.Console.WriteLine(security[user1, 0].FileName);
        security.CheckAccess(user);
    }
} 

/* Task 4:  Multi-Tier Booking System
Task: Develop a booking system for hotels, flights, and events.
Each booking type should follow a common process but handle pricing 
and availability differently.
Prevent direct manipulation of reservation status while allowing controlled updates.
Enable a flexible system where new booking types can be added without
 modifying existing logic.
Allow users to retrieve and modify bookings without knowing the internal handling
 mechanism */

 abstract class Booking
 {
    public bool IsAvailable { get; protected set;}

    public Booking()
    {
        IsAvailable = true;
    }
    public virtual void BookingProcces ()
    {
        if (!IsAvailable)
        {
            System.Console.WriteLine("Booking failed");
            return;
        }
        System.Console.WriteLine("Booked");
        return;
    }

    public void Cancel()
    {
        if (IsAvailable)
        {
            System.Console.WriteLine("Booking is already canceled");
            return;
        }
        System.Console.WriteLine("Booking canceled");
        IsAvailable = true;
    }

    public void Confirm()
    {
        if (!IsAvailable)
        {
            System.Console.WriteLine("Booking is confirmed");
            return;
        }
    }
    protected abstract decimal CalculatePrice();
    protected abstract bool CheckAvailability();
 }
 
 class Hotel : Booking 
 {
   // private int _aveilableRooms = 10;
    public int AvailableRooms { get; private set; }
    public bool[] Rooms;
    
    public  Hotel(int rooms)
    {
        AvailableRooms = rooms;
        Rooms = new bool[rooms];
    
    
        for (int i = 0; i < Rooms.Length; i++)
        {
            Rooms[i] = true;
        }
    }
    

    public bool this[int index]
    {
        get 
        {
            if (index < 0 || index >= Rooms.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            return Rooms[index];
        }
        set
        {
            if (index < 0 || index >= Rooms.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            Rooms[index] = value;
        }
    }
    public override void BookingProcces()
    {
        decimal price = CalculatePrice();
        if (!CheckAvailability())
        {
            System.Console.WriteLine("Hotel room is not available");
            return;
        }
        int roomIndex = -1;
        for (int i = 0; i < Rooms.Length; i++)
        {
            if (Rooms[i])
            {
                roomIndex = i;
                break;
            }
        }

        if (roomIndex == -1)
        {
            Console.WriteLine("No available rooms.");
            return;
        }
        System.Console.WriteLine($"Hotel room booked, you must pay {price}$");

        AvailableRooms--;
        Rooms[roomIndex] = false;
        IsAvailable = AvailableRooms > 0;

    }
    protected override decimal CalculatePrice()
    {
        return 100;
    }
    protected override bool CheckAvailability()
    {
        return AvailableRooms > 0;
    }
 }

class FlightSystem : Booking
{
    public int AvailableSeats {get; set;}
    public  bool[] Seats {get; private set;} 

    public FlightSystem(int seats)
    {
        AvailableSeats = seats;
        Seats = new Seats[seats];

        for (int i = 0; i < seats; i ++)
        {
            Seats[i] = true;
        }
    }

    public bool this[int index]
    {
        get 
        {
            if (index < 0 || index >= Rooms.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            return Seats[index];
        }
        set
        {
            if (index < 0 || index >= Seats.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            Seats[index] = value;
        }
    }
    public override void BookingProcces()
    {
        if (!CheckAvailability())
        {
            System.Console.WriteLine("Booking process terminated, not available seats");
            return;
        }
        decimal price = CalculatePrice();
        int seatIndex = -1;
        for (int i = 0; i < Seats.Length; i++)
        {
            if (Seats[i])
            {
                seatIndex = i;
                break;
            }
        }
        if (seatIndex == -1)
        {
            System.Console.WriteLine("Booking process terminated, not available seats");
            return;
        }
        Seats[seatIndex] = false;
        AvailableSeats--;
        IsAvailable = AvailableSeats > 0;
        Console.WriteLine($"Flight seat booked, you must pay {price}$");

    }

    protected override decimal CalculatePrice()
    {
        return 250;
    }

    protected override bool CheckAvailability()
    {
        return AvailableSeats > 0;
    }
}
 class Program 
 {
     static void Main()
     {
        Hotel booking = new Hotel(3);
        booking.BookingProcces();
        booking.BookingProcces();
     }
 }


 