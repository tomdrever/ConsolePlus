using System;

namespace ConsolePlus
{
    public class ColouredText
    {
        public static ColouredText NewColouredText(string contentText, ConsoleColor colour)
        {
            return new ColouredText {Colour = colour, ContentText = contentText};
        }

        public static ColouredText NewPlainText(string contentText)
        {
            return NewColouredText(contentText, ConsoleColor.White);
        }


        public string ContentText { get; set; }
        public ConsoleColor Colour { get; set; }

        public override string ToString()
        {
            return ContentText;
        }
    }

}