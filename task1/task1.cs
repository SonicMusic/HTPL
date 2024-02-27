using System;
using System.Security.Cryptography.X509Certificates;

namespace task1
{
    internal class task1
    {
        static int Path(int[] N, int m)
        {
            return Path(N,m-1);
        }

        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("m = ");
            int m = int.Parse(Console.ReadLine());

            int p = 0;

            int[] N = new int[n];
            for (int i = 0; i < n; i++)
            {
                N[i] = i + 1;
            }

            do
            {
                Console.Write(N[p]);

                p = (p + m - 1) % n;
            }
            while (N[p] != N[0]);

            
            Console.Read();

        }
    }
}
