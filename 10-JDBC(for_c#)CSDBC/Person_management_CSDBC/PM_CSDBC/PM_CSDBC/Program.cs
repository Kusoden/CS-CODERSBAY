using _1_Person_management;
using System;
using System.Threading;
using static _1_Person_management.PersonManager;

namespace _1_Person_management
{
    class Person_Management
    {
        static void Main()
        {
            Address address1 = new Address("kaplanstr", 1, 4020, "Linz");
            Address address2 = new Address("Ledererstr", 2, 4020, "Linz");

            PersonManager codersBay = new PersonManager();

            try
            {
                codersBay.CreatePerson("Ferzan1", "Abdullahzadeh Narzmes");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Please enter a valid name. (without any numbers)");
                Console.WriteLine(ex.StackTrace); // delivers an error message in the console
                                                  // which leads you to the line where something went wrong
            }

            Console.WriteLine("+__+__+__+__+__+__+__+__+__+__+\n me in CODERSBAY PV");
            codersBay.DisplayAllPersons();
            Thread.Sleep(1000);

            PersonManager magi = new PersonManager();
            magi.CreatePerson("Kamran", "Azizi", "01.01.1995", address1, Person.Gender.Male);
            magi.CreatePerson("Alex", "Pricher", "02.02.1996", address2, Person.Gender.Male);
            Console.WriteLine("+__+__+__+__+__+__+__+__+__+__+\nIn MAGISTRAT PV:");
            magi.DisplayAllPersons();
            Thread.Sleep(1000);

            Console.WriteLine();
            Console.WriteLine("removed Alex + created with only F/Lname:");
            magi.RemovePerson("Alex");
            magi.CreatePerson("Beni", "Bjerni");

            // 

            bool found;

            do
            {
                Console.WriteLine("Enter a name to search for a person:");

                string searchName = Console.ReadLine();
                try
                {
                    Person foundPerson = magi.FindPersonByName(searchName);
                    Console.WriteLine("Found person: " + foundPerson.Name +"last Name: "+ foundPerson.LastName);
                    found = false;
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Person not found.");
                    Console.WriteLine(ex.StackTrace); // delivers an error message in the console
                                                      // which leads you to the line where something went wrong
                    found = true;
                }
            } while (found == true);

            PersonManager linz = new PersonManager();
            Thread.Sleep(1000);

            Console.WriteLine();
            Console.WriteLine("created Öl in Linz PV ");
            linz.CreatePerson("Oliver", "öl");

            linz.DisplayAllPersons();
        }

    }
}


