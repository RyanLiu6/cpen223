//Student name:Shikhar Chitkara
//Student number:46443727

using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    public class Program
    {
        static void Main()
        {
            DNA dna12 = new DNA("ATCGGGCATGTA");
            DNA expected = new DNA("ATCGGATTGATGCATGTA");
            DNA actual = dna12.CutAndSplice("GGGCAT", 2, "ATTGAT");
            Console.WriteLine(actual.GetSequence() == "ATCGGATTGATGCATGTA");
        }
    }
    public class DNA
    {
        private string dna;

        public DNA(string dna) //Constructor from Lab 5
        {
            this.dna = dna; //For this lab's constructor, checking for dna validity is optional 
        }
        public string GetSequence() //From Lab 5 (just a getter method)
        {
            return dna;
        }
        /// <summary>        
        /// Generates a new DNA by cutting and splicing the DNA sequence. 
        /// The new DNA should not have any junk (*this dna* though should 
        /// not change). If the restriction enzyme is not found in the 
        /// DNA sequence then the DNA sequence created is identical to
        /// the original sequence without any junk.
        /// See the lab description for details about the cut-and-splice operation.
        /// </summary>
        /// <param name="restrictionEnzyme">
        /// restrictionEnzyme is not null, not "", and is a sequence of codons with 
        /// no junk. This is the codon sequence that will be cleaved.
        /// </param>
        /// <param name="splicePosition">
        /// splicePosition is the position within the restriction enzyme where the 
        /// splicee is added.
        /// 0 &lt splicePosition &lt length of restriction enzyme.
        /// </param>
        /// <param name="splicee">
        /// splicee is not null, not "", and is a sequence of codons with no junk. 
        /// This is the enzyme to splice in to the DNA sequence where the restriction
        /// enzyme is cleaved.
        /// </param>
        /// <returns>DNA object created by the cut-and-splice operation</returns>
        /// <exception cref="ArgumentException"> 
        /// Thrown if restrictionEnzyme or splicee is not valid, or
        ///        if splicePosition is not valid
        /// </exception>
        public DNA CutAndSplice(string restrictionEnzyme, int splicePosition, string splicee)
        {
            if (IsValidDNA(restrictionEnzyme) != true || IsValidDNA(splicee) != true)
            {
                throw new ArgumentException("Invalid RestrictionEnzyme or Splicee.");
            }
            if (splicePosition <= 0 || splicePosition >= restrictionEnzyme.Length)
            {
                throw new ArgumentException("Invalid Splice Position");

            }
            /// Removes all the junk from the sequence 
            int codons = 0;
            StringBuilder nojunk = new StringBuilder();
            foreach (char c in dna)
            {
                int count = 0;
                if (c == 'A' || c == 'C' || c == 'G' || c == 'T')
                {
                    count++;
                    nojunk.Append(c);
                }
                codons = count / 3;
            }
            string nojunkDNA = nojunk.ToString();

            nojunk = new StringBuilder();

            ///Checks if and where the restriction enzyme matches with the DNA sequence and then insertd the splicee at the specidied position

            int i = 0;
            int codoncount = 0;
            while (i < nojunkDNA.Length - restrictionEnzyme.Length)
            {
                bool match = false;
                for (int i_2 = 0; i_2 < restrictionEnzyme.Length; i_2++)
                {
                    match = true;
                    if (nojunkDNA[i + i_2] != restrictionEnzyme[i_2])
                    {
                        codoncount++;
                        if (codoncount < codons)
                        {
                            i = i + 3;
                            nojunk.Append(nojunkDNA.Substring(i + i_2, 3));
                       
                        }
                        match = false;
                        break;
                    }
                    if (match)
                    {
                        nojunk.Append(nojunkDNA.Substring(i, i + splicePosition));
                        nojunk.Append(splicee);
                        nojunk.Append(nojunkDNA.Substring(i + splicePosition));
                            i = i + restrictionEnzyme.Length;
                    }
                }
            }
                string nojunkDNA2 = nojunk.ToString();


            return new DNA(nojunkDNA2);
        }


        /// <summary>
        /// Checks if the restricion enzyme and the splicee are valid.
        /// </summary>
        /// <param name="dna"> The restriction enzyme and the splicee cannot be empty and need to be valid structure. </param>
        /// <returns>if the splicee and restriction enzyme are valid or not.</returns>
        public bool IsValidDNA(string dna)
        {
            int count = 0;
            for (int i = 0; i < dna.Length; i++)
            {
                if (dna[i] == 'A' || dna[i] == 'C' || dna[i] == 'G' || dna[i] == 'T')
                {
                    count++;
                }
                else
                {
                    return false;
                }
            }

            if (count % 3 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
                 
            