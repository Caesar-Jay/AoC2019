using System;
using System.IO;

namespace Day5
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
            }

            OutputLocator(intCodes);
        }

        static void OutputLocator(int[] intCodes)
        {
            int pos = 0;
            int mode = 0;
            int paramMode1 = 0;
            int paramMode2 = 0;
            int paramMode3 = 0;
            int param1 = 0;
            int param2 = 0;


            while (intCodes[pos] != 99)
            {
                var instr = intCodes[pos].ToString().PadLeft(5, '0');
                mode = int.Parse(instr.Substring(3, 2));
                paramMode1 = int.Parse(instr.Substring(2, 1));
                paramMode2 = int.Parse(instr.Substring(1, 1));
                paramMode3 = int.Parse(instr.Substring(0, 1));

                if (mode == 1 || mode == 2)
                {
                    param1 = paramMode1 == 0 ? intCodes[intCodes[pos + 1]] : intCodes[pos + 1];
                    param2 = paramMode2 == 0 ? intCodes[intCodes[pos + 2]] : intCodes[pos + 2];
                }

                switch (mode)
                {
                    case 1:

                        intCodes[intCodes[pos + 3]] = param1 + param2;
                        pos += 4;
                        break;
                    case 2:
                        intCodes[intCodes[pos + 3]] = param1 * param2;
                        pos += 4;
                        break;
                    case 3:
                        Console.WriteLine("Input: ");
                        var input = int.Parse(Console.ReadLine());
                        intCodes[intCodes[pos + 1]] = input;
                        pos += 2;
                        break;
                    case 4:
                        var output = intCodes[intCodes[pos + 1]];
                        Console.WriteLine($"Output: {output}");
                        pos += 2;
                        break;
                    case 5:
                        if (intCodes[pos + 1] != 0)
                        {
                            intCodes[pos] = intCodes[pos + 2];
                        }
                        else
                            pos += 3;
                        break;
                    case 6:
                        if (intCodes[pos + 1] == 0)
                        {
                            intCodes[pos] = intCodes[pos + 2];
                        }
                        else
                            pos += 3;
                        break;
                    case 7:
                        if (intCodes[pos + 1] < intCodes[pos + 2])
                        {
                            intCodes[intCodes[pos + 3]] = 1;
                        }
                        else
                        {
                            intCodes[intCodes[pos + 3]] = 0;
                            pos += 4;
                        }
                        break;
                    case 8:
                        if (intCodes[pos + 1] == intCodes[pos + 2])
                        {
                            intCodes[intCodes[pos + 3]] = 1;
                        }
                        else
                        {
                            intCodes[intCodes[pos + 3]] = 0;
                            pos += 4;
                        }
                        break;
                    default:
                        Console.WriteLine("Fel");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
