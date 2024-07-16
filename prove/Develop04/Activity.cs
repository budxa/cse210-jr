using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;


    public Activity()
    {
        _name = "";
        _description = "";
        _duration = -1;
    }

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting The {_name}...");
        Console.WriteLine(_description);
        Console.Write("Enter the seconds you would like: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready....");
        ShowSpinner(5);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Well Done! You completed {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b-");
            Thread.Sleep(250);
            Console.Write("\b\\");
            Thread.Sleep(250);
            Console.Write("\b|");
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(200);
            Console.Write("\b \b");
        }
    }

    public int GetDuration()
    {
        return _duration;
    }
}
