using System;
using CodeKata.Lib;

namespace CodeKata
{
    class Program
    {
        static void Main(string[] args)
        {
            IDiamondShape diamondShape = new DiamondShape();
            new DiamondShapeService(diamondShape).PrintDiamondShape(args);
        }
    }
}
