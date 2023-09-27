char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
char[] leetChars = { '@', '8', '(', 'D', '3', 'F', '6', '#', '!', 'J', 'K', '1', 'M', 'N', '0', 'P', 'Q', 'R', '$', '7', 'U', 'V', 'W', 'X', 'Y', '2' };

Console.WriteLine("LEET THE TEXT: ");
string textToConvert = Console.ReadLine().ToUpper();
string leetTextPhrase = "";

for (int i = 0; i < textToConvert.Length; i++)
{
    char temp = textToConvert[i];
    if (char.IsDigit(temp))
    {
        leetTextPhrase += temp;
    }
    else
    {
        bool found = false;
        char leetChar = temp;

        for (int j = 0; j < alphabet.Length; j++)
        {
            if (temp == alphabet[j])
            {
                leetChar = leetChars[j];
                found = true;
            }
        }

        if (!found)
        {
            leetTextPhrase += temp; /*leetTextPhrase.Append(temp) alternative*/
        }
        else
        {
            leetTextPhrase += leetChar;
        }
    }
}

Console.WriteLine(leetTextPhrase);