using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

Dictionary<string, string> pocketBook = new();
Dictionary<string, string> GermanFirstPocketBook = new();
string? choice = "";

do
{
    Thread.Sleep(1000);
    Console.Clear();
    Console.WriteLine("Dictionary Menu:");
    Console.WriteLine("1. Add Word Pair");
    Console.WriteLine("2. Remove Word Pair");
    Console.WriteLine("3. Translate Word");
    Console.WriteLine("4. Exit");
    Console.Write("Enter a number (1/2/3/4): ");
    choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddWordPair();
            break;
        case "2":
            RemoveWordPair();
            break;
        case "3":
            TranslateWord();
            break;
        case "4":
            break;
        default:
            Console.WriteLine("Invalid choice. Please select a valid option.");
            break;
    }
} while (choice != "4");

void AddWordPair()
{
    Console.Write("Enter English word: ");
    string englishWord = Console.ReadLine().ToLower();
    Console.Write("Enter German translation: ");
    string germanWord = Console.ReadLine().ToLower();

    if (!pocketBook.ContainsKey(englishWord))
    {
        pocketBook[englishWord] = germanWord;
        GermanFirstPocketBook[germanWord] = englishWord;
        Console.WriteLine("Word translation added successfully.");
    }
    else
        Console.WriteLine("This English word already exists in the pocketBook.");
}

void RemoveWordPair()
{
    Console.WriteLine("Do you want to delete the word by giving the German word or English word?");
    Console.WriteLine("english for English, german for German");
    string choiceOfPath = Console.ReadLine().ToLower();

    if (choiceOfPath == "english")
    {
        Console.Write("Enter English word to remove: ");
        string englishWord = Console.ReadLine().ToLower();
        string germanWord = pocketBook[englishWord];
        if (pocketBook.ContainsKey(englishWord))
        {
            pocketBook.Remove(englishWord);
            GermanFirstPocketBook.Remove(germanWord);
            Console.WriteLine("Word pair removed successfully.");
        }
        else
            Console.WriteLine("Word not found in the pocketBook.");
    }
    else
    {
        Console.Write("Enter German word to remove: ");
        string germanWord = Console.ReadLine().ToLower();
        string englishWord = GermanFirstPocketBook[germanWord];
        if (GermanFirstPocketBook.ContainsKey(germanWord))
        {
            pocketBook.Remove(englishWord);
            GermanFirstPocketBook.Remove(germanWord);
            Console.WriteLine("Word pair removed successfully.");
        }
        else
            Console.WriteLine("Word not found in the pocketBook.");
    }
}

void TranslateWord()
{
    Console.Write("Enter a word to translate: ");
    string word = Console.ReadLine().ToLower();

    if (pocketBook.ContainsKey(word))
    {
        string germanTranslation = pocketBook[word];
        Console.WriteLine($"English: {word} =>>> German: {germanTranslation}");
    }
    else if (GermanFirstPocketBook.ContainsKey(word))
    {
        string englishTranslation = GermanFirstPocketBook[word];
        Console.WriteLine($"German: {word} =>>> English: {englishTranslation}");
    }

    else
        Console.WriteLine("Word not found in the pocketBook.");
}