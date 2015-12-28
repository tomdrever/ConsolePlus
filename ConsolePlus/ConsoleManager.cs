using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace ConsolePlus
{
    public class ConsoleManager
    {
        public static void TypeTextFromFile(string filename, ConsoleColor colour, TypeSpeed typeSpeed)
        {
            Type(ReadTextFromFile(filename, colour), typeSpeed);
        }
        public static void TypeText(ColouredText text, TypeSpeed typeSpeed)
        {
            Console.ForegroundColor = text.Colour;

            var random = new Random();

            foreach (var letter in text.ContentText)
            {
                if (letter == '|')
                {
                    Console.Write("\n");
                }
                else
                {
                    Console.Write(letter);
                }

                Thread.Sleep(random.Next(1, (int)typeSpeed) * 10);
            }

            Console.Write(" ");

            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Type(ColouredText[] textCol, TypeSpeed typeSpeed)
        {
            foreach (var text in textCol)
            {
                TypeText(text, typeSpeed);
            }
        }

        public static void WriteTextFromFile(string filename, ConsoleColor colour)
        {
            Write(ReadTextFromFile(filename, colour));
        }
        public static void WriteText(ColouredText text)
        {
            Console.ForegroundColor = text.Colour;

            if (text.ContentText.Contains("|"))
            {
                text.ContentText = text.ContentText.Replace("|", "\n");
            }

            Console.Write(text + " ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Write(ColouredText[] textCol)
        {
            foreach (var text in textCol)
            {
                WriteText(text);
            }
        }

        private static ColouredText[] ReadTextFromFile(string fileName, ConsoleColor colour)
        {
            var reader = new StreamReader(fileName);
            return reader.ReadToEnd().Split(' ').Select(text => ColouredText.NewColouredText(text, colour)).ToArray();
        }
    }

    public enum TypeSpeed
    {
        Fast = 15,
        RatherFast = 30,
        Medium = 45,
        RatherSlow = 65,
        Slow = 100
    }
}
