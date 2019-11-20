using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Lab3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsPPPrime_TestMethod1()
        {
            IsPPPrime_Helper(5, true);
        }

        [TestMethod]
        public void IsPPPrime_TestMethod2()
        {
            IsPPPrime_Helper(77, false);
        }

        [TestMethod]
        public void IsPPPrime_TestMethod3()
        {
            IsPPPrime_Helper(253, true);
        }

        [TestMethod]
        public void IsPPPrime_TestMethod4()
        {
            IsPPPrime_Helper(348, true);
        }

        [TestMethod]
        public void IsPPPrime_TestMethod5()
        {
            //123 and 12345 are PP
            IsPPPrime_Helper(1234, false);
        }

        [TestMethod]
        public void IsPPPrime_TestMethod6()
        {
            IsPPPrime_Helper(2147483647, true);
        }

        public void IsPPPrime_Helper(int num, bool expected)
        {
            bool result = Program.IsPPPrime(num);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetAllPPPrimes_Test1()
        {
            List<int> intList = new List<int>();

            intList.Add(55);
            intList.Add(54);
            intList.Add(15);
            intList.Add(399);
            intList.Add(9);
            intList.Add(99);

            List<int> ppprimeList = new List<int>(new int[] { 15, 55, 99, 399 });
            List<int> studentList = Program.GetAllPPPrimes(intList);

            CollectionAssert.AreEqual(studentList, ppprimeList);
        }

        [TestMethod]
        public void GetAllPPPrimes_Test2()
        {
            List<int> intList = new List<int>();

            intList.Add(444);
            intList.Add(44);
            intList.Add(4);
            intList.Add(62);

            List<int> ppprimeList = new List<int>(new int[] { 44, 444 });
            List<int> studentList = Program.GetAllPPPrimes(intList);

            CollectionAssert.AreEqual(studentList, ppprimeList);
        }

        [TestMethod]
        public void GetAllPPPrimes_Test3()
        {
            List<int> intList = new List<int>();

            intList.Add(94);
            intList.Add(4);
            intList.Add(81);
            intList.Add(27);

            List<int> ppprimeList = new List<int>(new int[] { }); //should be empty
            List<int> studentList = Program.GetAllPPPrimes(intList);

            CollectionAssert.AreEqual(studentList, ppprimeList);
        }

        [TestMethod]
        public void GetAllPPPrimes_Test4()
        {
            List<int> intList = new List<int>();

            for (int i = 50; i < 150; i++)
            {
                intList.Add(i);
            }

            int[] tmp = { 51, 52, 53, 55, 57, 59, 60, 61, 63,
                65, 66, 67, 69, 70, 71, 73, 75, 76, 78, 79,
                83, 84, 85, 87, 89, 90, 91, 92, 93, 95, 97,
                99, 101, 102, 103, 105, 107, 109, 110, 111,
                113, 114, 115, 117, 119, 120, 121, 123, 124,
                126, 127, 129, 130, 131, 132, 133, 135, 137,
                138, 139, 140, 141, 143, 145, 147, 149, };

            List<int> ppprimeList = new List<int>(tmp);// a bigger list
            List<int> studentList = Program.GetAllPPPrimes(intList);

            CollectionAssert.AreEqual(studentList, ppprimeList);
        }


        // Testing primes under 20
        [TestMethod]
        public void GetAllPPPrimes_Test5()
        {
            List<int> intList = new List<int>();

            intList.Add(2);
            intList.Add(5);
            intList.Add(7);
            intList.Add(11);
            intList.Add(13);
            intList.Add(17);
            intList.Add(19);

            List<int> ppprimeList = intList;
            List<int> studentList = Program.GetAllPPPrimes(intList);

            CollectionAssert.AreEqual(studentList, ppprimeList);
        }

        // Testing duplicates using primes
        [TestMethod]
        public void GetAllPPPrimes_Test6()
        {
            List<int> intList = new List<int>();

            intList.Add(7);
            intList.Add(7);
            intList.Add(11);
            intList.Add(11);
            intList.Add(11);

            List<int> ppprimeList = new List<int>(new int[] { 7, 11 } );
            List<int> studentList = Program.GetAllPPPrimes(intList);

            CollectionAssert.AreEqual(studentList, ppprimeList);
        }
    }
}
