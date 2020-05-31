using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIdentifierTests
{
    [TestClass]
    public class CheckArgsTests
    {
        [TestMethod]
        public void NecessaryQuantityArg_ReturnTrue()
        {
            string[] arg = { "arg" };
            bool result = CheckIdentifier.Program.CheckArgs(arg);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void MoreThanNecessaryQuantityArg_ReturnFalse()
        {
            string[] args = { "arg1", "arg2" };
            bool result = CheckIdentifier.Program.CheckArgs(args);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void LessThanNecessaryQuantityArg_ReturnFalse()
        {
            string[] arg = { };
            bool result = CheckIdentifier.Program.CheckArgs(arg);
            Assert.AreEqual(false, result);
        }
    }

    [TestClass]
    public class CheckIdentifierTests
    {
        [TestMethod]
        public void EmptyIdentifier_ReturnFalse()
        {
            string identifier = "";
            bool result = CheckIdentifier.Program.CheckIdentifier(identifier);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IdentifierBeginsWithDigit_ReturnFalse()
        {
            string identifier = "1identifier";
            bool result = CheckIdentifier.Program.CheckIdentifier(identifier);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IdentifierContainsSpecialSymbol_ReturnFalse()
        {
            string identifier = "identifier@test";
            bool result = CheckIdentifier.Program.CheckIdentifier(identifier);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IdentifierContainsRussianLetters_ReturnFalse()
        {
            string identifier = "identifieròåñò";
            bool result = CheckIdentifier.Program.CheckIdentifier(identifier);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CorrectIdentifier_ReturnTrue()
        {
            string identifier = "identifier";
            bool result = CheckIdentifier.Program.CheckIdentifier(identifier);
            Assert.AreEqual(true, result);
        }
    }

    [TestClass]
    public class IsLetterTests
    {
        [TestMethod]
        public void LatinLetter_ReturnTrue()
        {
            char latinLetter = 'g';
            bool result = CheckIdentifier.Program.IsLetter(latinLetter);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Digit_ReturnFalse()
        {
            char digit = '4';
            bool result = CheckIdentifier.Program.IsLetter(digit);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void SpecialSymbol_ReturnFalse()
        {
            char symbol = '!';
            bool result = CheckIdentifier.Program.IsLetter(symbol);
            Assert.AreEqual(false, result);
        }
    }
}
