using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());

        Random randomGenerator = new();
        int magicNumber = randomGenerator.Next(1, 101);


        int guess = 0;
        bool repeat = true;

        do
        {
            do
            {
                Console.Write("what is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            } while (guess != magicNumber);

            Console.Write("Do you want to repeat the process? (y/n)(yes/no): ");
            string response = Console.ReadLine().ToLower();
            if (response == "y" || response == "yes")
            {
                repeat = true;
            }
            else
            {
                repeat = false; 
            }
        } while (repeat);

        Console.WriteLine("Thank you for playing the guessing game! See you next time!");



    }
}