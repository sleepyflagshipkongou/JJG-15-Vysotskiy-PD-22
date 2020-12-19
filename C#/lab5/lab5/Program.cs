using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            int m, n;
            Console.WriteLine("To create a matrix, enter m and n");
            Console.Write("m: ");
            m = Convert.ToInt32(Console.ReadLine());
            Console.Write("n: ");
            n = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[m,n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("matrix[{0}][{1}] = ",i,j);
                    matrix[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " " );
                }
                Console.WriteLine();
            }
            int differentElementsRows = 0;
            int counter;
            for (int i = 0; i < m; i++)
            {
                counter = 0;
                for (int j = 0; j < n-1; j++)
                {
                    for (int e = j+1; e < n; e++)
                    {
                        if (matrix[i, j] == matrix[i, e])
                            counter++;
                    }
                }

                if (counter == 0)
                    differentElementsRows++;
            }

            Console.WriteLine("There are(is) {0} row(s) with different elements.", differentElementsRows);

           
        }
    }
}
