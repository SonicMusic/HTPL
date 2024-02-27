using System;
using System.IO;
using System.Linq;

namespace task4
{
    class task4
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the input file as an argument!");
                return;
            }

            string[] strings = File.ReadAllLines(args[0]);

            int[] nums = strings.Select(int.Parse).ToArray();

            int minMoves = MinMoves(nums);

            Console.WriteLine(minMoves);
        }

        public static int MinMoves(int[] nums)
        {
            Array.Sort(nums);
            int median = nums[nums.Length / 2];

            int moves = 0;
            foreach (int num in nums)
            {
                moves += Math.Abs(num - median);
            }

            return moves;
        }
    }
}
