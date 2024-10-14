using System;

class Program
{
    static void Main(string[] args)
    {
        // Loop until the user selects "0" to exit
        int option;
        do
        {
            PrintMenu(); // Show the menu
            option = InputOption(); // Get user option
            string message = GetMessage(option); // Get the message
            Console.WriteLine(message); // Display the returned message
        } while (option != 0); // Loop until the user selects "Exit"

        // Additional tasks (word count, encryption, decryption)
        Console.Write("Enter a string with words starting with uppercase letters: ");
        string inputString = Console.ReadLine();
        int wordCount = CountWords(inputString); // Count words task
        Console.WriteLine($"Number of words: {wordCount}");

        // Caesar Cipher encryption
        Console.Write("Enter a string to encrypt: ");
        string toEncrypt = Console.ReadLine();
        Console.Write("Enter number of rotations: ");
        int rotations = Convert.ToInt32(Console.ReadLine());
        string encrypted = Encrypt(toEncrypt, rotations);
        Console.WriteLine($"Encrypted: {encrypted}");

        // Caesar Cipher decryption
        Console.Write("Enter the encrypted string to decrypt: ");
        string encryptedString = Console.ReadLine();
        Console.Write("Enter number of rotations used for encryption: ");
        int decryptionRotations = Convert.ToInt32(Console.ReadLine());
        string decrypted = Decrypt(encryptedString, decryptionRotations);
        Console.WriteLine($"Decrypted: {decrypted}");
    }

    // Method displaying menu
    static void PrintMenu()
    {
        Console.WriteLine("Select a language option:");
        Console.WriteLine("1. French");
        Console.WriteLine("2. Spanish");
        Console.WriteLine("3. German");
        Console.WriteLine("4. Italian");
        Console.WriteLine("0. Exit");
    }

    // Method for user's option and handle input errors
    static int InputOption()
    {
        int option = -1;
        try
        {
            Console.Write("Enter your choice: ");
            option = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
        return option;
    }

    // Method to return the appropriate greeting message in the language the 'user' picks
    static string GetMessage(int language)
    {
        switch (language)
        {
            case 0:
                return "Goodbye";
            case 1:
                return "Bonjour";
            case 2:
                return "Ola";
            case 3:
                return "Hallo";
            case 4:
                return "Ciao";
            default:
                return "Please enter a valid option.";
        }
    }

    // Method that counts words in a string and each word starts with an uppercase letter
    static int CountWords(string str)
    {
        int count = 0;
        foreach (char c in str)
        {
            if (char.IsUpper(c))
            {
                count++;
            }
        }
        return count;
    }

    // Caesar Cipher encryption method
    static string Encrypt(string text, int shift)
    {
        char[] buffer = text.ToCharArray();

        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];
            if (char.IsLetter(letter))
            {
                char letterOffset = char.IsUpper(letter) ? 'A' : 'a';
                letter = (char)(((letter + shift - letterOffset) % 26) + letterOffset);
            }
            buffer[i] = letter;
        }
        return new string(buffer);
    }

    // Caesar Cipher decryption method
    static string Decrypt(string text, int shift)
    {
        return Encrypt(text, 26 - shift); // Reversing encryption using the opposite shift
    }
}
