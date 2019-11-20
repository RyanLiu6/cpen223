using System.IO;
using Lab4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab4Tests
{
    [TestClass]
    public class UnitTest1
    {
        WordCounter bankCounter;
        WordCounter bookCounter;

        [TestInitialize]
        public void TestInitialize()
        {
            bankCounter = new WordCounter("http://textfiles.com/conspiracy/bankcris.txt");
            bookCounter = new WordCounter("http://textfiles.com/conspiracy/bookfile.txt");
        }

        [TestMethod]
        public void Testuw1()
        {
            try
            {
                wordCountHelper(741, bankCounter.UniqueWordCount());
            }
            catch (IOException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Testco1()
        {
            try
            {
                wordCountHelper(118, bankCounter.CountOccurrences("the"));
            }
            catch (IOException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Testco2()
        {
            try
            {
                wordCountHelper(0, bankCounter.CountOccurrences(null));
            }
            catch (IOException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Testco3()
        {
            try
            {
                wordCountHelper(0, bankCounter.CountOccurrences(""));
            }
            catch (IOException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Testco4()
        {
            try
            {
                wordCountHelper(6, bankCounter.CountOccurrences("Nation"));
            }
            catch (IOException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Testco5()
        {
            try
            {
                wordCountHelper(106, bankCounter.CountOccurrences("-"));
            }
            catch (IOException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Testco6()
        {
            try
            {
                wordCountHelper(1, bankCounter.CountOccurrences("$22"));
            }
            catch (IOException)
            {
                Assert.Fail();
            }
        }

        //    Unique Words in http://textfiles.com/conspiracy/bookfile.txt: 2364
        //    Occurrences of the in http://textfiles.com/conspiracy/bookfile.txt: 385
        //    Occurrences of after in http://textfiles.com/conspiracy/bookfile.txt: 5

        [TestMethod]
        public void Testuw2()
        {
            try
            {
                wordCountHelper(2364, bookCounter.UniqueWordCount());
            }
            catch (IOException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Testco3_1()
        {
            try
            {
                wordCountHelper(385, bookCounter.CountOccurrences("the"));
            }
            catch (IOException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Testco3_2()
        {
            try
            {
                wordCountHelper(5, bookCounter.CountOccurrences("after"));
            }
            catch (IOException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Testco3_3()
        {
            try
            {
                wordCountHelper(234, bookCounter.CountOccurrences(","));
            }
            catch (IOException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Testco3_4()
        {
            try
            {
                wordCountHelper(5, bookCounter.CountOccurrences("***"));
            }
            catch (IOException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Testco3_5()
        {
            try
            {
                wordCountHelper(12, bookCounter.CountOccurrences("..."));
            }
            catch (IOException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Testco3_6()
        {
            try
            {
                wordCountHelper(5, bookCounter.CountOccurrences("NOW"));
            }
            catch (IOException)
            {
                Assert.Fail();
            }
        }

        /********************************************************************
        ************************* Helper methods ****************************
        ********************************************************************/
        private void wordCountHelper(int expected, int actual)
        {
            Assert.AreEqual(expected, actual);
        }
    }
}
