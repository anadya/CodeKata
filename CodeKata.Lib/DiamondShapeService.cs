using System;

namespace CodeKata.Lib
{
    public class DiamondShapeService
    {
        public readonly IDiamondShape _diamondShape;
        public DiamondShapeService(IDiamondShape diamondShape)
        {
            _diamondShape = diamondShape;
        }

        public void PrintDiamondShape(string[] args)
        {
            if (!_diamondShape.IsValid(args))
            {
                Console.WriteLine("Input must be an alphabet character. Please provide valid input...");
                Environment.Exit(-1);
            }

            var letter = args[0][0];
            Console.WriteLine(_diamondShape.CreateDiamondShape(letter));
        }
    }
}
