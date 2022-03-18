using System;
using System.Text;

namespace CodeKata.Lib
{
    public interface IDiamondShape
    {
        bool IsValid(string[] arguments);

        string CreateDiamondShape(char lastLetter);

    }

    public class DiamondShape : IDiamondShape
    {
        private const char _firstAlphabet = 'A';
        private const char _lastAlphabet = 'Z';

        public bool IsValid(string[] arguments)
        {
            return arguments.Length == 1
                    && arguments[0].Length == 1 
                    && validateAllowedChars(arguments[0][0]);
        }

        public string CreateDiamondShape(char lastLetter)
        {
            if (!validateAllowedChars(lastLetter))
            {
                throw new ArgumentException("Argument not allowed. This method allows only alphabet charachter");
            }

            int midIndex = calculateMidIndex(lastLetter);
            int diamondLength = (midIndex * 2) + 1;
            int lastLetterAscii = lastLetter;

            var diamondStrBuilder = new StringBuilder();

            for (var i = 0; i < diamondLength -1 ; i++)
            {
                char[] line = createLine(i, midIndex, lastLetterAscii);
                diamondStrBuilder.AppendLine(new string(line));
            };

            char[] lastLine = createLine(diamondLength - 1, midIndex, lastLetterAscii);
            diamondStrBuilder.Append(new string(lastLine));

            return diamondStrBuilder.ToString();
        }

        private int calculateMidIndex(char letter)
        {
            int asciiDecimal = char.ToUpper(letter);
            int alphabetIndex = asciiDecimal - char.ToUpper(_firstAlphabet);

            return alphabetIndex;
        }
      
        private char[] createLine(int lineIndex, int midIndex, int lastLetterAscii)
        {
            int distanceFromMid = lineIndex > midIndex ? (midIndex * 2) - lineIndex : lineIndex;

            int maxCharLength = distanceFromMid + midIndex + 1;
            char[] lineOfChars = new char[maxCharLength];

            for (var i = 0; i < maxCharLength; i++)
            {
                lineOfChars[i] = ' ';
            }

            int currentLetterAscii = lastLetterAscii - midIndex + distanceFromMid;
            char currentLetter = (char)currentLetterAscii;

            lineOfChars[midIndex - distanceFromMid] = currentLetter;
            lineOfChars[midIndex + distanceFromMid] = currentLetter;

            return lineOfChars;
        }

        private bool validateAllowedChars(char letter)
        {
            return char.ToUpper(letter) >= char.ToUpper(_firstAlphabet)
                    && char.ToUpper(letter) <= char.ToUpper(_lastAlphabet);
        }
    }
}
