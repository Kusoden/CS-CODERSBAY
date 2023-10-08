using System;
using System.Threading;
using System.Linq; // Add this for name validation
using static _1_Person_management.PersonManager;

namespace _1_Person_management
{
    class Person_Management
    {
        static void Main()
        {
            Address address1 = new("kaplanstr", 1, 4020, "Linz");
            Address address2 = new("Ledererstr", 2, 4020, "Linz");

            PersonManager codersBay = new();

            try
            {
                codersBay.CreatePerson("Ferzan1", "Abdullahzadeh Narzmes");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Please enter a valid name.");
                /*put the code  to take user input for the name.*/
            }

            Console.WriteLine("+__+__+__+__+__+__+__+__+__+__+\n me in CODERSBAY PV");
            codersBay.DisplayAllPersons();
            Thread.Sleep(1000);

            PersonManager magi = new();
            magi.CreatePerson("Kamran", "Azizi", "01.01.1995", address1, Person.Gender.Male);
            magi.CreatePerson("Alex", "Pricher", "02.02.1996", address2, Person.Gender.Male);
            Console.WriteLine("+__+__+__+__+__+__+__+__+__+__+\nIn MAGISTRAT PV:");
            magi.DisplayAllPersons();
            Thread.Sleep(1000);

            Console.WriteLine();
            Console.WriteLine("removed Alex + created with only F/Lname:");
            magi.RemovePerson("Alex");
            magi.CreatePerson("Beni", "Bjerni");
            PersonManager linz = new();
            Thread.Sleep(1000);

            Console.WriteLine();
            Console.WriteLine("created Öl in Linz PV ");
            linz.CreatePerson("Oliver", "öl");

            linz.DisplayAllPersons();
        }
    }
}
