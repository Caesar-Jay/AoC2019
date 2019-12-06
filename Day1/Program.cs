using System;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").ToList();
            // Day1
            //var total = input.Sum(f => CalcFuel(int.Parse(f)));

            // Day1.2
            int total = 0;

            foreach (var module in input)
            {
                var fuel = CalcFuel(int.Parse(module));
                var tempFuel = fuel;

                while (true)
                {
                    tempFuel = CalcFuel(tempFuel);
                    if (tempFuel < 1)
                        break;
                    else
                        fuel += tempFuel;
                }

                total += fuel;
            }

            Console.WriteLine(total);
        }

        static int CalcFuel(int mass)
        {
            return (int)(Math.Floor((decimal)(mass / 3)) - 2);
        }
    }
}
