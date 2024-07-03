using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture(new Reference("Proverbs", 91, 1, 2),
         "He that dwelleth in the place of the most High shall abide under the shadow of the Almighty; I will say of the Lord, He is my refuge and my fortress: my God; in Him will I trust."
        );

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press 'enter' to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }
            else
            {
                scripture.HideRandomWords(3);
            }
        }
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("All words are hidden.");
    }
}