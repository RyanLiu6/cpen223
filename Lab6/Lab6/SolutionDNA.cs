using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    public class Program
    {
        static void Main()
        {
            //You could mainly use unit tests for testing.
        }
    }
    public class DNA
    {
        private string dna;
        private List<char> nuc = new List<char>{'A', 'T', 'G', 'C'};

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
            // Check for validity
            if (!this.IsValidSequence(restrictionEnzyme))
            {
                throw new ArgumentException("Invalid restricitonEnzyme");
            }

            if (!this.IsValidSequence(splicee))
            {
                throw new ArgumentException("Invalid splicee");
            }

            if (splicePosition <= 0 || splicePosition >= restrictionEnzyme.Length)
            {
                throw new ArgumentException("Invalid splice position");
            }

            // Filter for junk
            string dnaSequence = this.RemoveJunk(this.dna);

            if (dnaSequence.Contains(restrictionEnzyme))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(restrictionEnzyme.Substring(0, splicePosition));
                sb.Append(splicee);
                sb.Append(restrictionEnzyme.Substring(splicePosition));

                dnaSequence = dnaSequence.Replace(restrictionEnzyme, sb.ToString());
            }

            return new DNA(dnaSequence);
        }

        private string RemoveJunk(string sequence)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char x in sequence)
            {
                if (nuc.Contains(x))
                {
                    sb.Append(x);
                }
            }
            return sb.ToString();
        }

        private bool IsValidSequence(string sequence)
        {
            if (string.IsNullOrEmpty(sequence))
            {
                return false;
            }

            string filteredSequence = this.RemoveJunk(sequence);

            if (string.Equals(filteredSequence, sequence))
            {
                return sequence.Length % 3 == 0;
            }

            return false;
        }
    }
}
