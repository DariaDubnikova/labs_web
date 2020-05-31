using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemoveExtraBlanksTests
{
    [TestClass]
    public class CheckArgsTests
    {
        [TestMethod]
        public void MoreThanNecessaryQuantityArg_ReturnFalse()
        {
            string[] args = { "input1.txt", "input2.txt", "output.txt" };
            bool result = RemoveExtraBlanks.Program.CheckArgs(args);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void LessThanNecessaryQuantityArg_ReturnFalse()
        {
            string[] arg = { "input.txt" };
            bool result = RemoveExtraBlanks.Program.CheckArgs(arg);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void NecessaryQuantityArg_ReturnTrue()
        {
            string[] args = { "input.txt", "output.txt" };
            bool result = RemoveExtraBlanks.Program.CheckArgs(args);
            Assert.AreEqual(true, result);
        }
    }

    [TestClass]
    public class RemoveExtraBlanksTests
    {
        [TestMethod]
        public void stringWithoutExtraBlanks_ReturnStringWithoutTabs()
        {
            string str = "test string";
            str = RemoveExtraBlanks.Program.RemoveExtraBlanks(str);
            Assert.AreEqual("test string", str);
        }

        [TestMethod]
        public void RemoveTabsAtEnd_ReturnStringWithoutTabs()
        {
            string str = "test\t\t\t";
            str = RemoveExtraBlanks.Program.RemoveExtraBlanks(str);
            Assert.AreEqual("test", str);
        }

        [TestMethod]
        public void RemoveSpacesAtStart_ReturnStringWithoutSpaces()
        {
            string str = "  test";
            str = RemoveExtraBlanks.Program.RemoveExtraBlanks(str);
            Assert.AreEqual("test", str);
        }

        [TestMethod]
        public void RemoveExtraSpaces_ReturnStringWithoutExtraSpaces()
        {
            string str = " test   string   ";
            str = RemoveExtraBlanks.Program.RemoveExtraBlanks(str);
            Assert.AreEqual("test string", str);
        }

        [TestMethod]
        public void RemoveExtraTabs_ReturnStringWithoutExtrsTabs()
        {
            string str = "\t\ttest\t\t\tstring\t";
            str = RemoveExtraBlanks.Program.RemoveExtraBlanks(str);
            Assert.AreEqual("test string", str);
        }

        [TestMethod]
        public void RemoveExtraSpacesAndTabs_ReturnStringWithoutExtrsTabsAndSpaces()
        {
            string str = "\t\t\ttest    string\t   ";
            str = RemoveExtraBlanks.Program.RemoveExtraBlanks(str);
            Assert.AreEqual("test string", str);
        }
    }
}
