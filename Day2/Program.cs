using System;
using System.IO;


namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt").Split(',');

            int[] intCodes = new int[input.Length];
            int[] intOrig = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                intCodes[i] = int.Parse(input[i]);
                intOrig[i] = int.Parse(input[i]);
            }

            int result = 0;
            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    intCodes = (int[])intOrig.Clone();
                    result = OutputLocator(noun, verb, intCodes);
                    if (result == 19690720)
                    {
                        Console.WriteLine(100 * intCodes[1] + intCodes[2]);
                        Console.ReadKey();
                    }
                }
            }

        }

        static int OutputLocator(int noun, int verb, int[] intCodes)
        {
            intCodes[1] = noun;
            intCodes[2] = verb;

            int pos = 0;
            while (intCodes[pos] != 99)
            {
                intCodes = ProcessOpCode(intCodes[pos], pos, intCodes);
                pos += 4;
            }

            return intCodes[0];
        }

        static int[] ProcessOpCode(int opCode, int pos, int[] intCodes)
        {
            if (opCode == 1)
            {
                intCodes[intCodes[pos + 3]] = intCodes[intCodes[pos + 1]] + intCodes[intCodes[pos + 2]];
            }
            if (opCode == 2)
            {
                intCodes[intCodes[pos + 3]] = intCodes[intCodes[pos + 1]] * intCodes[intCodes[pos + 2]];
            }
            return intCodes;
        }
    }
}
