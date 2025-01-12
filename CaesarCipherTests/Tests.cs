using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaesarCipherTests
{
    [TestClass]
    public class CaesarCipherTests
    {
        [TestMethod]
        public void Encrypt_Shift3_ShouldReturnCorrectEncryption()
        {
            // Arrange
            string input = "HELLO";
            int shift = 3;
            string expected = "KHOOR"; // "H"->"K", "E"->"H", "L"->"O", etc.

            // Act
            string result = CaesarCipher.Encrypt(input, shift);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Decrypt_Shift3_ShouldReturnOriginalText()
        {
            // Arrange
            string input = "KHOOR";
            int shift = 3;
            string expected = "HELLO";

            // Act
            string result = CaesarCipher.Decrypt(input, shift);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Encrypt_Lowercase_ShouldPreserveCase()
        {
            // Arrange
            string input = "Hello";
            int shift = 3;
            string expected = "Khoor";

            // Act
            string result = CaesarCipher.Encrypt(input, shift);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Encrypt_WithNonLetterCharacters_ShouldIgnoreNonLetters()
        {
            // Arrange
            string input = "Hello, World!";
            int shift = 3;
            string expected = "Khoor, Zruog!"; // Non-letters remain unchanged

            // Act
            string result = CaesarCipher.Encrypt(input, shift);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Encrypt_HandlesWrapAround_ZToA()
        {
            // Arrange
            string input = "XYZ";
            int shift = 3;
            string expected = "ABC"; // 'X' -> 'A', 'Y' -> 'B', 'Z' -> 'C'

            // Act
            string result = CaesarCipher.Encrypt(input, shift);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Decrypt_HandlesWrapAround_AToZ()
        {
            // Arrange
            string input = "ABC";
            int shift = 3;
            string expected = "XYZ";

            // Act
            string result = CaesarCipher.Decrypt(input, shift);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Encrypt_ShiftNegative_ShouldWorkCorrectly()
        {
            // Arrange
            string input = "HELLO";
            int shift = -3;
            string expected = "EBIIL"; // "H"->"E", "E"->"B", "L"->"I"

            // Act
            string result = CaesarCipher.Encrypt(input, shift);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Decrypt_ShiftNegative_ShouldWorkCorrectly()
        {
            // Arrange
            string input = "EBIIL";
            int shift = -3;
            string expected = "HELLO";

            // Act
            string result = CaesarCipher.Decrypt(input, shift);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Encrypt_EmptyString_ShouldReturnEmpty()
        {
            // Arrange
            string input = "";
            int shift = 5;
            string expected = "";

            // Act
            string result = CaesarCipher.Encrypt(input, shift);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Decrypt_EmptyString_ShouldReturnEmpty()
        {
            // Arrange
            string input = "";
            int shift = 5;
            string expected = "";

            // Act
            string result = CaesarCipher.Decrypt(input, shift);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Encrypt_NoShift_ShouldReturnSameText()
        {
            // Arrange
            string input = "HELLO";
            int shift = 0;
            string expected = "HELLO"; // No shift should return the same text

            // Act
            string result = CaesarCipher.Encrypt(input, shift);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Decrypt_NoShift_ShouldReturnSameText()
        {
            // Arrange
            string input = "HELLO";
            int shift = 0;
            string expected = "HELLO";

            // Act
            string result = CaesarCipher.Decrypt(input, shift);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}