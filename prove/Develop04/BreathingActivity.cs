using System;

public class BreathingActivity : Activity
{

    public BreathingActivity(string name, string description) : base(name, description)
    {
        
    }

    public void Run()
    {
        DisplayStartingMessage();
        int elapsed = 0;

        while (elapsed < GetDuration())
        {
            Console.WriteLine("Breath in...");
            ShowCountDown(4);
            Console.WriteLine("Breath out...");
            ShowCountDown(4);
            elapsed += 8;
        }
        DisplayEndingMessage();
    }
}
