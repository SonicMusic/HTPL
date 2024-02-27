using System;
using System.IO;

namespace task2
{
    class task2
    {
        static void Main(string[] args)
        {
            string[] centerCoordinates = File.ReadAllText(args[0]).Split(' ');
            string[] pointCoordinates = File.ReadAllLines(args[1]);

            double centerX = double.Parse(centerCoordinates[0]);
            double centerY = double.Parse(centerCoordinates[1]);
            double radius = double.Parse(centerCoordinates[2]);

            foreach (string pointCoord in pointCoordinates)
            {
                double pointX = double.Parse(pointCoord.Split(' ')[0]);
                double pointY = double.Parse(pointCoord.Split(' ')[1]);

                double distance = Math.Sqrt(Math.Pow((pointX - centerX), 2) + Math.Pow((pointY - centerY), 2));

                if (distance == radius)
                {
                    Console.WriteLine("0");
                }
                else if (distance < radius)
                {
                    Console.WriteLine("1");
                }
                else
                {
                    Console.WriteLine("2");
                }
            }
        }
    }
}