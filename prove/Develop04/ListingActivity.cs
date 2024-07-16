using System;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {

            "What are personal strengths of yours?",
            "When have you felt the Holy Ghost this month?",
            "Who are people that you have helped this week?",
            "Who are people that you appreciate in your life?",
            "Who are some of your personal heroes?"
    };


    public ListingActivity(string name, string description) : base(name, description)
    {

    }

    public ListingActivity()
    {
        
    }

    public void Run()
    {
        DisplayStartingMessage();
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        ShowSpinner(5);

        int elapsed = 0;
        List<string> items = new List<string>();
        while (elapsed < GetDuration())
        {
            Console.Write("List item: ");
            string item = Console.ReadLine();
            items.Add(item);
            elapsed += 8;
        }
        Console.WriteLine($"You listed {items.Count} item/s.");
        DisplayEndingMessage();
    }
}
