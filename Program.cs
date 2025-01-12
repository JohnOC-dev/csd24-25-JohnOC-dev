using System;

public class CaesarCipher
{   
    /*
        This method encrypts the input text using the Caesar Cipher technique. 
        The param "text" contains the input text to be encrypted, and the param "shift" determines the number of positions to shift each letter.
    */

    // Improvement  1: Eliminated hardcoded alphabet by using char arithmetic. This makes the algorithm more efficient and adaptable to different character sets
    public static string Encrypt(string text, int shift)
    {
        return ProcessText(text, shift);
    }

    
    /*
        This method decrypts the text that was previously encrypted using the Caesar Cipher.
        Here, "text" contains the encrypted text to be decrypted, and "shift" is the number of position that were used during encryption(applied in reverse during decryption).
    */
    public static string Decrypt(string text, int shift)
    {
        return ProcessText(text, -shift); // Reverses the shift to decrypt
    }

    /*
        The "ProcessText" method processes the input text for both encryption and decryption while preserving the letter case and handling non-letter characters.
        "text" always contains the input text to be processed, and "shift" is the number of positions to shift each letter (positive for encryption, negative for decryption).
        The return value is the transformed text.
    */
    private static string ProcessText(string text, int shift)
    {
        char[] buffer = text.ToCharArray(); // Convert text into a character array

        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];

            // Improvement 2: Preserve case by determining if the letter is uppercase or lowercase
            if (char.IsLetter(letter))
            {
                char baseChar = char.IsUpper(letter) ? 'A' : 'a'; // Maintains original case
                int newIndex = ((letter - baseChar + shift) % 26 + 26) % 26; // Handles wrap-around correctly
                buffer[i] = (char)(baseChar + newIndex); // Shifted letter while preserving case
            }

            // Improvement 3: Non-letter characters remain unchanged
            // Unlike the previous implementation, punctuation, numbers, and spaces are retained
        }

        return new string(buffer); // Convert the character array back to a string
    }

    public static void Main()
    {
        Console.Write("Enter text to encrypt: ");
        string input = Console.ReadLine();

        Console.Write("Enter shift value: ");

        // Improvement 4: Input validation to prevent crashes and unexpected behavior, .IsNullOrWhiteSpace() checks for null, empty, or whitespace strings
        if (!string.IsNullOrWhiteSpace(input) && int.TryParse(Console.ReadLine(), out int shift))
        {
            string encrypted = Encrypt(input, shift);
            string decrypted = Decrypt(encrypted, shift);

            Console.WriteLine($"Encrypted Text: {encrypted}");
            Console.WriteLine($"Decrypted Text: {decrypted}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid text and a numerical shift value."); // Error message for invalid input
        }
    }
}
