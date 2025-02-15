using System;
using System.Reflection.Metadata;

/*
     Create a Contact class with:
    Name, PhoneNumber, and Email properties.
    A method DisplayInfo() to print contact details.
    A Main() method where the user can create 3 contacts and display them.
    Store contacts in an array and allow searching by name.
    */
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
        string? input = Console.ReadLine();
        foreach (var contact in contactArray)
        {
            if (contact.Name == input)
            {
                Console.WriteLine($"The name was found!!!\n{contact.Name}`s phone number is: {contact.PhoneNumber}\n" +
                                  $"And email: {contact.Email}");
            }
            else
            {
                Console.WriteLine($"The {input} is not found in your contacts!!!");
            }
        }
    }
}
/*--------------------------------------------------------------------------------------------------------*/