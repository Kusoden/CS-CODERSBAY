
Random r = new();
Console.WriteLine("Write what should be Encrypted");
string textToEncrypt = Console.ReadLine();

int key = r.Next(1, 26);

Console.WriteLine("The number that has been encrypted to:" + key);
Console.WriteLine("+---+---+---+---+---+---+---+---+---+");

foreach (char temp in textToEncrypt)
{
    if (char.IsLower(temp))
    {
        char encryptedChar = (char)(temp + key);
        if (encryptedChar > 'z')
        {
            encryptedChar = (char)(encryptedChar - 26);
        }
        Console.Write(encryptedChar);
    }
    else if (char.IsUpper(temp))
    {
        char encryptedChar = (char)(temp + key);
        if (encryptedChar > 'Z')
        {
            encryptedChar = (char)(encryptedChar - 26);
        }
        Console.Write(encryptedChar);
    }
    else
    {
        Console.Write(temp);
    }
}

Console.WriteLine("\n+---+---+---+---+---+---+---+---+---+");

