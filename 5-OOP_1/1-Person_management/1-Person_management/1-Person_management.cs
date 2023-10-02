using System;

namespace _1_Person_management
{
    class Person_Managment
    {
        static void Main()
        {
            Address address1 = new("kaplanstr", 1, 4020, "Linz");
            Address address2 = new("Ledererstr", 2, 4020, "Linz");

            PersonManager codersBay = new();

            codersBay.CreatePerson("Ferzan", "Abdullahzadeh Narzmes");
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
