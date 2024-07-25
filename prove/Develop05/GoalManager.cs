using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome To The Eternal Quest Program");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Create Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");

            Console.Write("Select an option: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    DisplayPLayerInfo();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    CreateGoal();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void DisplayPLayerInfo()
    {
        Console.WriteLine($"Your score is: {_score}");
    }

    private void ListGoals()
    {
        Console.WriteLine("\nGoals: ");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nCreate a new goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string choice = Console.ReadLine();

        Console.Write("Enter Goal Name: ");
        string shortName = Console.ReadLine();

        Console.Write("Enter Goal Description: ");
        string description = Console.ReadLine();

        Console.Write("Enter Points: ");
        int points = int.Parse(Console.ReadLine());


        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(shortName, description, points));
                break;

            case "2":
                _goals.Add(new EternalGoal(shortName, description, points));
                break;

            case "3":
                Console.Write("Enter target number of completions: ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(shortName, description, points, target, bonus));
                break;

            default:
                Console.WriteLine("Invalid goal type. Please try again.");
                break;
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        Console.WriteLine("Select a goal to record: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            goal.RecordEvent();
            _score += goal.GetPoints();
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                _score += checklistGoal.GetBonus();
            }
            Console.WriteLine("Event recorded.");
        }
        else
        {
            Console.WriteLine("invalid selection. Please try again.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. Please check the filename and try again.");
            return;
        }

        using (StreamReader reader = new StreamReader(filename))
        {
            _score = int.Parse(reader.ReadLine());
            _goals.Clear();
            
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length < 4)
                {
                    Console.WriteLine("Invalid goal format in file. Moving on...");
                    continue;
                }

                string type = parts[0];
                string shortName = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                switch (type)
                {
                    case "SimpleGoal":
                        if (parts.Length != 5)
                        {
                            Console.WriteLine("Invalid SimpleGoal format. Moving on...");
                            continue;
                        }
                        bool isComplete = bool.Parse(parts[4]);
                        var simpleGoal = new SimpleGoal(shortName, description, points);

                        simpleGoal.SetComplete(isComplete);
                        _goals.Add(simpleGoal);
                        break;
                    
                    case "EternalGoal":
                        if (parts.Length != 4)
                        {
                            Console.WriteLine("Invalid EternalGoal format. Skipping...");
                            continue;
                        }
                        _goals.Add(new EternalGoal(shortName, description, points));
                        break;
                    
                    case "ChecklistGoal":
                        if (parts.Length != 7)
                        {
                            Console.WriteLine("Invalid ChecklistGoal format. Skipping...");
                            continue;
                        }
                        int amountCompleted = int.Parse(parts[4]);
                        int target = int.Parse(parts[5]);
                        int bonus = int.Parse(parts[6]);
                        var checklistGoal = new ChecklistGoal(shortName, description, points, target, bonus);
                        checklistGoal.SetAmount(amountCompleted);
                        _goals.Add(checklistGoal);
                        break;

                    default:
                        Console.WriteLine("Unknown goal type. Skipping...");
                        break;
                }
            }
        }
        Console.WriteLine("Goals loaded.");
    }
}
