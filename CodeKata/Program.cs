using System;
using CodeKata.Lib;

namespace CodeKata
{
    class Program
    {
        static void Main(string[] args)
        {
            DiamondShape diamondShape = new DiamondShape();

            if (!diamondShape.IsValid(args))
            {
                Console.WriteLine("Input must be an alphabet character. Please provide valid input...");
                return;
            }

            var letter = args[0][0];
            Console.WriteLine(diamondShape.CreateDiamondShape(letter));
        }
    }
}
