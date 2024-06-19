using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        int userInput = -1;
        while (userInput != 0)
        {
            Console.Write("Enter a number: ");
            string userAnswer = Console.ReadLine();
            userInput = int.Parse(userAnswer);

            // Add a number as long as it is not 0
            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        }


        // Sum Number
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");


        // Average Number
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Largest Number
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The largest is: {max}");


        // Smallest Positive Number
        int minPosNum = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0)
            {
                if (number < minPosNum)
                {
                    minPosNum = number;
                }
            }
        }
        Console.WriteLine($"The smallest positive number is: {minPosNum}");


        // Sorted Out List
        Console.WriteLine("The sorted list is:");
       
        numbers.Sort();
        for (int i = 0; i < numbers.Count; i++)
        {
            int number = numbers[i];
            Console.WriteLine(number);
        }
    }
}