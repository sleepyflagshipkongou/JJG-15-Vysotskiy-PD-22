using System;
using System.Collections.Generic;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            Console.Write("Enter a number: ");
            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Be aware! Enter a correct number: ");
            }
            string num = number.ToString();
            List<int> numList = new List<int>();
            for (int i = 0; i < num.Length; i++)
            {
                numList.Add(int.Parse(num[i].ToString()));
            }

            numList.Sort();
            int counter = 0;
            for (int i = 0; i < numList.Count; i++)
            {
                for (int j = 0; j < numList.Count; j++)
                {
                    if (numList[i] == numList[j])
                        counter++;
                }
                Console.WriteLine("Element {0} we have {1} time(s) here!", numList[i], counter);
                i += counter - 1;
                counter = 0;
            }
            Console.Write("Enter a number you want to find: ");
            int numToFind;
            while (!int.TryParse(Console.ReadLine(), out numToFind))
            {
                Console.Write("Be aware! Enter a correct number: ");
            }
            for (int i = 0; i < numList.Count; i++)
            {
                if (numList[i] == numToFind)
                {
                    Console.WriteLine("Your number is here at {0} position.", i+1);
                    return;
                }
            }
            Console.WriteLine("No {0} in this list!", numToFind);

        }
    }
}
