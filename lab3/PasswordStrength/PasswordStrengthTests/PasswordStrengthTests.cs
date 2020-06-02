using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordStrengthTests
{
    
    [TestClass]
    public class CheckArgsTests
    {
        [TestMethod]
        public void MoreThanNecessaryQuantityArg_ReturnFalse()
        {
            string[] args = { "password1", "password2" };
            bool result = PasswordStrength.Program.CheckArgs(args);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void LessThanNecessaryQuantityArg_ReturnFalse()
        {
            string[] arg = { };
            bool result = PasswordStrength.Program.CheckArgs(arg);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void NecessaryQuantityArg_ReturnTrue()
        {
            string[] args = { "input.txt" };
            bool result = PasswordStrength.Program.CheckArgs(args);
            Assert.AreEqual(true, result);
        }
    }

    [TestClass]
    public class IsCorrectPasswordTests
    {
        [TestMethod]
        public void PasswordWithSpecialSymbol_ReturnFalse()
        {
            Assert.AreEqual(false, PasswordStrength.Program.IsCorrectPassword("password!"));
        }

        [TestMethod]
        public void CorrectPassword_ReturnFalse()
        {
            Assert.AreEqual(true, PasswordStrength.Program.IsCorrectPassword("password123"));
        }
    }

    [TestClass]
    public class PasswordStrengthTests
    {
        [TestMethod]
        public void LowPasswordStrength_ReturnStrength()
        {
            int passwordStrength = PasswordStrength.Program.PasswordStrength("aaa1");
            Assert.AreEqual(31, passwordStrength);
        }

        [TestMethod]
        public void MediumStrengthPassword_ReturnStrength()
        {
            int passwordStrength = PasswordStrength.Program.PasswordStrength("abc321");
            Assert.AreEqual(42, passwordStrength);
        }

        [TestMethod]
        public void HighStrengthPassword_ReturnStrength()
        {
            int passwordStrength = PasswordStrength.Program.PasswordStrength("Damc395");
            Assert.AreEqual(60, passwordStrength);
        }
    }

    [TestClass]
    public class PasswordStrengthByNumberOfCharactersTests
    {
        [TestMethod]
        public void PasswordLengthIs4_ReturnStrengthByNumberOfCharacters()
        {
            int passwordStrengthByNumberOfCharacters = PasswordStrength.Program.PasswordStrengthByNumberOfCharacters("aaa1");
            Assert.AreEqual(16, passwordStrengthByNumberOfCharacters);
        }

        [TestMethod]
        public void PasswordLengthIs6_ReturnStrength()
        {
            int passwordStrengthByNumberOfCharacters = PasswordStrength.Program.PasswordStrengthByNumberOfCharacters("abc321");
            Assert.AreEqual(24, passwordStrengthByNumberOfCharacters);
        }

        [TestMethod]
        public void PasswordLengthIs7_ReturnStrength()
        {
            int passwordStrengthByNumberOfCharacters = PasswordStrength.Program.PasswordStrengthByNumberOfCharacters("Damc395");
            Assert.AreEqual(28, passwordStrengthByNumberOfCharacters);
        }
    }

    [TestClass]
    public class PasswordStrengthByNumberOfDigitsTests
    {
        [TestMethod]
        public void PasswordNumberOfDigitsIs1_ReturnStrengthByNumberOfDigits()
        {
            int passwordStrengthByNumberOfDigits = PasswordStrength.Program.PasswordStrengthByNumberOfDigits("aaa1");
            Assert.AreEqual(4, passwordStrengthByNumberOfDigits);
        }

        [TestMethod]
        public void PasswordNumberOfDigitsIs3_ReturnStrength()
        {
            int passwordStrengthByNumberOfCharacters = PasswordStrength.Program.PasswordStrengthByNumberOfCharacters("abc321");
            Assert.AreEqual(12, passwordStrengthByNumberOfCharacters);
        }

        [TestMethod]
        public void PasswordNumberOfDigitsIs5_ReturnStrength()
        {
            int passwordStrengthByNumberOfCharacters = PasswordStrength.Program.PasswordStrengthByNumberOfCharacters("Da34395");
            Assert.AreEqual(20, passwordStrengthByNumberOfCharacters);
        }
    }

    [TestClass]
    public class PasswordStrengthByNumberOfUpperCaseLettersTests
    {
        [TestMethod]
        public void PasswordWithUpperCaseLetter_ReturnStrengthByNumberOfUpperCaseLetters()
        {
            int passwordStrengthByNumberOfUpperCaseLetters = PasswordStrength.Program.PasswordStrengthByNumberOfUpperCaseLetters("ABcde12");
            Assert.AreEqual(10, passwordStrengthByNumberOfUpperCaseLetters);
        }

        [TestMethod]
        public void PasswordWithOnlyUpperCaseLetter_ReturnStrength()
        {
            int passwordStrengthByNumberOfUpperCaseLetters = PasswordStrength.Program.PasswordStrengthByNumberOfUpperCaseLetters("ABCDEF");
            Assert.AreEqual(0, passwordStrengthByNumberOfUpperCaseLetters);
        }

        [TestMethod]
        public void PasswordWithOutUpperCaseLetter_ReturnStrength()
        {
            int passwordStrengthByNumberOfUpperCaseLetters = PasswordStrength.Program.PasswordStrengthByNumberOfUpperCaseLetters("abcde12");
            Assert.AreEqual(14, passwordStrengthByNumberOfUpperCaseLetters);
        }
    }

    [TestClass]
    public class PasswordStrengthByNumberOfLowerCaseLettersTests
    {
        [TestMethod]
        public void PasswordWithLowerCaseLetter_ReturnStrengthByNumberOfLowerCaseLetters()
        {
            int passwordStrengthByNumberOfLowerCaseLetters = PasswordStrength.Program.PasswordStrengthByNumberOfLowerCaseLetters("ABcde12");
            Assert.AreEqual(8, passwordStrengthByNumberOfLowerCaseLetters);
        }

        [TestMethod]
        public void PasswordWithOnlyLowerCaseLetter_ReturnStrength()
        {
            int passwordStrengthByNumberOfLowerCaseLetters = PasswordStrength.Program.PasswordStrengthByNumberOfLowerCaseLetters("abcdef");
            Assert.AreEqual(0, passwordStrengthByNumberOfLowerCaseLetters);
        }

        [TestMethod]
        public void PasswordWithOutLowerCaseLetter_ReturnStrength()
        {
            int passwordStrengthByNumberOfLowerCaseLetters = PasswordStrength.Program.PasswordStrengthByNumberOfLowerCaseLetters("DCES12");
            Assert.AreEqual(12, passwordStrengthByNumberOfLowerCaseLetters);
        }
    }

    [TestClass]
    public class PasswordStrengthByOnlyLettersTests
    {
        [TestMethod]
        public void PasswordWithOnlyLetters_ReturnStrengthByOnlyLetters()
        {
            int passwordStrengthByOnlyLetters = PasswordStrength.Program.PasswordStrengthByOnlyLetters("ABcde12");
            Assert.AreEqual(0, passwordStrengthByOnlyLetters);
        }

        [TestMethod]
        public void PasswordWithLettersAndDigits_ReturnStrengthByOnlyLetters()
        {
            int passwordStrengthByOnlyLetters = PasswordStrength.Program.PasswordStrengthByOnlyLetters("abcdef");
            Assert.AreEqual(6, passwordStrengthByOnlyLetters);
        }
    }

    [TestClass]
    public class PasswordStrengthByOnlyDigitsTests
    {
        [TestMethod]
        public void PasswordWithOnlyDigits_ReturnStrengthByOnlyDigits()
        {
            int passwordStrengthByOnlyDigits = PasswordStrength.Program.PasswordStrengthByOnlyDigits("123456");
            Assert.AreEqual(6, passwordStrengthByOnlyDigits);
        }

        [TestMethod]
        public void PasswordWithLettersAndDigits_ReturnStrengthByOnlyDigits()
        {
            int passwordStrengthByOnlyDigits = PasswordStrength.Program.PasswordStrengthByOnlyDigits("abcdef123");
            Assert.AreEqual(0, passwordStrengthByOnlyDigits);
        }
    }

    [TestClass]
    public class PasswordStrengthByNumberOfReapetedSymbolsTests
    {
        [TestMethod]
        public void PasswordWithReapetedSymbols_ReturnStrengthByNumberOfReapetedSymbols()
        {
            int passwordStrengthByNumberOfReapetedSymbols = PasswordStrength.Program.PasswordStrengthByNumberOfReapetedSymbols("abcada34");
            Assert.AreEqual(3, passwordStrengthByNumberOfReapetedSymbols);
        }

        [TestMethod]
        public void PasswordWithoutReapetedSymbols_ReturnStrengthByNumberOfReapetedSymbols()
        {
            int passwordStrengthByNumberOfReapetedSymbols = PasswordStrength.Program.PasswordStrengthByNumberOfReapetedSymbols("abcdef123");
            Assert.AreEqual(0, passwordStrengthByNumberOfReapetedSymbols);
        }
    }
}
