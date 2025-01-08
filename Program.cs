using System;

class CaesarCipher
{
    // Constant string representing the uppercase English alphabet.
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    /// <summary>
    /// Encrypts a given text using the Caesar Cipher technique.
    /// </summary>
    /// <param name="text">The input text to be encrypted.</param>
    /// <param name="shift">The number of positions to shift each letter.</param>
    /// <returns>The encrypted text.</returns>
    public static string Encrypt(string text, int shift)
    {
        return ProcessText(text, shift);
    }

    /// <summary>
    /// Decrypts a given text that was encrypted using the Caesar Cipher.
    /// </summary>
    /// <param name="text">The encrypted text to be decrypted.</param>
    /// <param name="shift">The number of positions used in encryption (reversed in decryption).</param>
    /// <returns>The decrypted text.</returns>
    public static string Decrypt(string text, int shift)
    {
        return ProcessText(text, -shift); // Reverse the shift to decrypt
    }

    /// <summary>
    /// Processes text for both encryption and decryption.
    /// </summary>
    /// <param name="text">The input text to process.</param>
    /// <param name="shift">The number of positions to shift (positive for encryption, negative for decryption).</param>
    /// <returns>The transformed text.</returns>
    private static string ProcessText(string text, int shift)
    {
        char[] buffer = text.ToUpper().ToCharArray(); // Convert text to uppercase and store it in a character array

        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];

            // Check if the character is a letter (ignores numbers, symbols, etc.)
            if (char.IsLetter(letter))
            {
                int letterIndex = Alphabet.IndexOf(letter); // Find letter position in the alphabet
                int newIndex = (letterIndex + shift + Alphabet.Length) % Alphabet.Length; // Shift and wrap around if needed
                buffer[i] = Alphabet[newIndex]; // Replace the character with the shifted one
            }
        }

        return new string(buffer); // Convert char array back to string
    }

    public static void Main()
    {
        Console.Write("Enter text to encrypt: ");
        string input = Console.ReadLine();

        Console.Write("Enter shift value: ");
        if (int.TryParse(Console.ReadLine(), out int shift))
        {
            string encrypted = Encrypt(input, shift);
            string decrypted = Decrypt(encrypted, shift);

            Console.WriteLine($"Encrypted Text: {encrypted}");
            Console.WriteLine($"Decrypted Text: {decrypted}");
        }
        else
        {
            Console.WriteLine("Invalid shift value. Please enter a number.");
        }
    }
}