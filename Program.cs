using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.Intrinsics.X86;
using System.Threading.Channels;
using System.Xml.Serialization;
// Pontus Thorén SUT25
namespace PyramidBuilder_
{
    internal class Program
    {

        static void Main(string[] args)
        {
        Start:
            Console.WriteLine("Ange höjden på pyramiden."); //Ask the player to chose the height of the pyramid.
            string input = Console.ReadLine();

            if (int.TryParse(input, out int height) && height > 0) // Check if the input is a positive integer.
            {

                Console.WriteLine("Välj vilken symbol du vill ha i din pyramid.");
                string symbolInput = Console.ReadLine();

                char symbol = '*'; // Our standard symbol.

                if (!string.IsNullOrEmpty(symbolInput)) 
                {
                    symbol = symbolInput[0]; //Use the first character if the user typed a symbol
                }

                Console.WriteLine("Vill du ha en vanlig (n), ifylld pyramid med färg tryck (f), en ihållig tryck (i) eller en inverterad pyramid (o).");
                string choice = Console.ReadLine();


                if (choice.ToLower() == "o") // Here we have the code for the inverted part.
                {
                    for (int i= height; i >= 1; i--) // Start on the height, and then reverse down to 1.
                    {
                        Console.Write(new string(' ', height - i));//Print the spaces from left so the pyramid will be centered.
                        Console.WriteLine(new string(symbol, i * 2 - 1));//Print out the pyramids row with the right amount of symbols.
                    }
                }

                for (int i = 1; i <= height; i++) // Start on 1,and go down to the set height.
                {
                    if (choice.ToLower() == "f") // The color part.
                    {

                        if (i % 2 == 0)// Current number is even, write red
                            Console.ForegroundColor = ConsoleColor.Red;

                        else// Current number is odd, write green
                            Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write(new string(' ', height - i));//Print spaces before the symbol to align the pyramid.
                        Console.WriteLine(new string(symbol, i * 2 - 1));//Making the pyramids shape.
                        Console.ResetColor();
                    }
                    else if (choice.ToLower() == "i") // Hollow
                    {
                        Console.Write(new string(' ', height - i)); //Print the spaces to align the pyramid.

                        if (i == 1)
                        {
                            Console.WriteLine(symbol); //Always print a single symbol on first row.
                        }
                        else if (i == height)
                        {
                            Console.WriteLine(new string(symbol, i * 2 - 1)); //Last row, print full of symbols.
                        }
                        else // Middle rows: print symbols,then spaces,then symbols again to make it hollow.
                        {
                            Console.Write(symbol); //Left edge
                            Console.Write(new string(' ', (i * 2 - 1) - 2));//Spaces in middle. Taking away 2 extra for making it hollow.
                            Console.WriteLine(symbol);//Right edge.
                        }

                    }
                    else if (choice.ToLower() == "n") // And here we got just a normal pyramid. 
                    {
                        Console.Write(new string(' ', height - i)); //Print spaces to center the pyramid.
                        Console.WriteLine(new string(symbol, i * 2 - 1)); //Print the symbols for the current row.

                    }
                }

            }

            else
            {
                Console.WriteLine("Ogiltlig inmatning.Ange ett positivt heltal."); // If you dont write at number, you get this error.
            }
            Console.ReadKey();
            Console.WriteLine("Vill du starta om spelet? (Yes/No)");
            string answer = Console.ReadLine();
            if (answer == "Yes" || answer == "yes")
            {
                goto Start;
            }
            else
            {
                Console.WriteLine("Tack för att du spelade!");
            }
        }



    }
}

