//This file includes the Main method, as well as 7 tests.
//You can modify it to further test your program.

using System;
using System.IO;
using System.Collections.Generic;

namespace Lab4
{
    public class Program
    {
        static void Main()
        {
            int nTests = 7;
            int pTests = Test.Testco1() +
                         Test.Testco2() +
                         Test.Testco3_1() +
                         Test.Testco3_2() +
                         Test.Testco3_3() +
                         Test.Testuw1() +
                         Test.Testuw2();
            Console.WriteLine("===========");
            Console.WriteLine($"passing tests: {pTests}");
            Console.WriteLine($"failing tests: {nTests - pTests}");
            Console.WriteLine("===========");
        }
    }

    public class Test
    {
        public static int Testuw1()
        {
            try
            {
                WordCounter myCounter = new WordCounter("http://textfiles.com/conspiracy/bankcris.txt");
                if (741 == myCounter.UniqueWordCount())
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine($"IO Exception: {ioe.Message}");
                return 0;
            }
        }


        public static int Testco1()
        {
            try
            {
                WordCounter myCounter = new WordCounter("http://textfiles.com/conspiracy/bankcris.txt");
                if (118 == myCounter.CountOccurrences("the"))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine($"IO Exception: {ioe.Message}");
                return 0;
            }
        }


        public static int Testco2()
        {
            try
            {
                WordCounter myCounter = new WordCounter("http://textfiles.com/conspiracy/bankcris.txt");
                if (0 == myCounter.CountOccurrences(null))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine($"IO Exception: {ioe.Message}");
                return 0;
            }

        }

        //    Unique Words in http://textfiles.com/conspiracy/bookfile.txt: 2364
        //    Occurrences of the in http://textfiles.com/conspiracy/bookfile.txt: 385
        //    Occurrences of after in http://textfiles.com/conspiracy/bookfile.txt: 5


        public static int Testuw2()
        {
            try
            {
                WordCounter myCounter = new WordCounter("http://textfiles.com/conspiracy/bookfile.txt");
                if (2364 == myCounter.UniqueWordCount())
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine($"IO Exception: {ioe.Message}");
                return 0;
            }
        }


        public static int Testco3_1()
        {
            try
            {
                WordCounter myCounter = new WordCounter("http://textfiles.com/conspiracy/bookfile.txt");
                if (385 == myCounter.CountOccurrences("the"))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine($"IO Exception: {ioe.Message}");
                return 0;
            }
        }


        public static int Testco3_2()
        {
            try
            {
                WordCounter myCounter = new WordCounter("http://textfiles.com/conspiracy/bookfile.txt");
                if (5 == myCounter.CountOccurrences("after"))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine($"IO Exception: {ioe.Message}");
                return 0;
            }
        }


        public static int Testco3_3()
        {
            try
            {
                WordCounter myCounter = new WordCounter("http://textfiles.com/conspiracy/bookfile.txt");
                if (234 == myCounter.CountOccurrences(","))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine($"IO Exception: {ioe.Message}");
                return 0;
            }

        }
    }
}