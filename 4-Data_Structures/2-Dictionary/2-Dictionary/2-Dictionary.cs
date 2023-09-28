using System;
using System.Collections.Generic;

Dictionary<string, string> pocketBook = new();

while (true)
{
    Console.WriteLine("Dictionary Menu:");
    Console.WriteLine("1. Add Word Pair");
    Console.WriteLine("2. Remove Word Pair");
    Console.WriteLine("3. Translate Word");
    Console.WriteLine("4. Exit");
    Console.Write("Enter a number (1/2/3/4): ");

    switch ()
    {
        case 1:
            AddWordPair();
            break;
        case 2:
            RemoveWordPair();
            break;
        case 3:
            TranslateWord();
            break;
        case 4:
            return;
        default:
            Console.WriteLine("Invalid choice. Please select a valid option.");
            break;
    }
}

void AddWordPair()
{
    Console.Write("Enter English word: ");
    string englishWord = Console.ReadLine().ToLower();
    Console.Write("Enter German translation: ");
    string germanWord = Console.ReadLine().ToLower();

    if (!pocketBook.ContainsKey(englishWord))
    {
        pocketBook[englishWord] = germanWord;
        Console.WriteLine("Word translation added successfully.");
    }
    else
        Console.WriteLine("This English word already exists in the pocketBook.");
}

void RemoveWordPair()
{
    Console.Write("Enter English word to remove: ");
    string englishWord = Console.ReadLine().ToLower();

    if (pocketBook.ContainsKey(englishWord))
    {
        pocketBook.Remove(englishWord);
        Console.WriteLine("Word pair removed successfully.");
    }
    else
        Console.WriteLine("Word not found in the pocketBook.");
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
    else
        Console.WriteLine("Word not found in the pocketBook.");
}