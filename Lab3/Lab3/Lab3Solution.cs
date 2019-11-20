using System;
using System.Collections.Generic;

using System.Numerics;

namespace Lab3
{
	public class Program
	{
		static void Main()
		{
			Console.Write("hello :)");
		}

		public static List<int> GetAllPPPrimes(List<int> intList)
		{
			List<int> returnList = new List<int>();

            foreach (int x in intList)
			{
                if (IsPPPrime(x) && !returnList.Contains(x))
				{
					returnList.Add(x);
				}
			}

			returnList.Sort();

			return returnList;
		}

		public static bool IsPPPrime(int num)
		{
			if (num == 2 || num == 3 || num == 5)
			{
				return true;
			}

			int count = 0;

			for (int i = 2; i < num; i++)
			{
				BigInteger curr = BigInteger.ModPow(i, num, num);

				if (i % 3 == 0 && curr == i)
				{
					count++;
				}

				if (count >= 2)
				{
					return true;
				}
			}
			return false;
		}
	}
}
