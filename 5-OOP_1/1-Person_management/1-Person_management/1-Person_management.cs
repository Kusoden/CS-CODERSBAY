using System;

namespace PersonManager
{
    class Person_Managment
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("kaplanstr", 1, 4020, "Linz");
            Address address2 = new Address("Ledererstr", 2, 4020, "Linz");

            PersonManager codersBay = new();

            codersBay.CreatePerson("Ferzan", "Abdullahzadeh Narzmes");
            Console.WriteLine("________________________");
            codersBay.DisplayAllPersons();

            PersonManager magi = new();
            magi.CreatePerson("Kamran", "Azizi", "01.01.1995", address1, Person.Gender.Male);
            magi.CreatePerson("Alex", "Pricher", "02.02.1996", address2, Person.Gender.Male);
            Console.WriteLine("________________________");
            magi.DisplayAllPersons();
            magi.RemovePerson("Alex");

            magi.CreatePerson("Beni", "Bjerni");
            PersonManager linz = new();
            linz.CreatePerson("Oliver", "öl");

            magi.DisplayAllPersons();
        }
    }
}
