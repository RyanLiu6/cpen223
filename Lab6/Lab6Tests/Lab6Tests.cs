using System;
using Lab6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab6Tests
{
    [TestClass]
    public class SpiceTests
    {
        [TestMethod]
        public void Splice_1()
        {
            // base test 1
            DNA dna = new DNA("ATCGGGCATGTA");
            DNA expected = new DNA("ATCGGATTGATGCATGTA");
            DNA actual = dna.CutAndSplice("GGGCAT", 2, "ATTGAT");

            Assert.AreEqual(expected.GetSequence(), actual.GetSequence());
        }

        [TestMethod]
        public void Splice_2()
        {
            // base test 2
            DNA dna = new DNA("ATCGGGCATGTAGGGCAT");
            DNA expected = new DNA("ATCGGATTGATGCATGTAGGATTGATGCAT");
            DNA actual = dna.CutAndSplice("GGGCAT", 2, "ATTGAT");

            Assert.AreEqual(expected.GetSequence(), actual.GetSequence());
        }

        [TestMethod, Timeout(1000)]
        public void Splice_3()
        {
            // check for proper positioning
            // GGT when spliced at 2 by GAT produces GGGATT - possible infinite splice
            DNA dna = new DNA("ATCGGTCGA");
            DNA expected = new DNA("ATCGGGATTCGA");
            DNA actual = dna.CutAndSplice("GGT", 2, "GAT");

            Assert.AreEqual(expected.GetSequence(), actual.GetSequence());
        }

        [TestMethod]
        public void UnmodifiedDNA()
        {
            // Check for modification of base DNA using base test 1
            string original = "ATCGGGCATGTA";
            DNA dna = new DNA(original);
            DNA expected = new DNA("ATCGGATTGATGCATGTA");
            DNA actual = dna.CutAndSplice("GGGCAT", 2, "ATTGAT");

            Assert.AreEqual(expected.GetSequence(), actual.GetSequence());
            Assert.AreEqual(original, dna.GetSequence());
        }
    }

    [TestClass]
    public class ExceptionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Exceptions_1()
        {
            // splicePosition check <= 0
            DNA baseDna = new DNA("ATCGCA");

            baseDna.CutAndSplice("ATC", 0, "CGCGCG");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Exceptions_2()
        {
            // splicePosition check for >= restrictionEnzyme.Length
            string resEnz = "ATC";
            DNA baseDna = new DNA("ATCGCA");

            baseDna.CutAndSplice(resEnz, resEnz.Length, "CGCGCG");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Exceptions_3()
        {
            // restrictionEnzyme check for junk
            DNA baseDna = new DNA("ATCGCA");

            baseDna.CutAndSplice("XYZ", 1, "CGCGCG");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Exceptions_4()
        {
            // restrictionEnzyme check for empty string
            DNA baseDna = new DNA("ATCGCA");

            baseDna.CutAndSplice("", 1, "CGCGCG");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Exceptions_5()
        {
            // restrictionEnzyme check for null
            DNA baseDna = new DNA("ATCGCA");

            baseDna.CutAndSplice(null, 1, "CGCGCG");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Exceptions_6()
        {
            // splicee check for junk
            DNA baseDna = new DNA("ATCGCA");

            baseDna.CutAndSplice("ATC", 1, "XYZXYZ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Exceptions_7()
        {
            // splicee check for empty string
            DNA baseDna = new DNA("ATCGCA");

            baseDna.CutAndSplice("ATC", 1, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Exceptions_8()
        {
            // splicee check for null
            DNA baseDna = new DNA("ATCGCA");

            baseDna.CutAndSplice("ATC", 1, null);
        }
    }
}