using System;

class Program
{
    static void Main(string[] args)
    {
        
        Journal journal = new Journal();
        PromptGenerator prompt = new PromptGenerator();

        bool exit = false;
        while(!exit)
        {
            Console.WriteLine("Welcome To the Journal!");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do?: ");
            
            string select = Console.ReadLine();
            switch (select)
            {
                case "1":
                    Entry newEntry = new Entry();
                    newEntry._date = DateTime.Now.ToString("dd/MM/yyyy");
                    newEntry._promptText = prompt.GetRandomPrompt();
                    Console.WriteLine($"{newEntry._promptText}");
                    newEntry._entryText = Console.ReadLine();
                    Console.WriteLine("");
                    journal.AddEntry(newEntry);
                    break;
                
                case "2":
                    journal.DisplayAll();
                    break;
                
                case "3":
                    Console.Write("Enter a filename: ");
                    string filename = Console.ReadLine();
                    journal.LoadFormFile(filename);
                    Console.WriteLine("");
                    break;
                
                case "4":
                    Console.Write("Enter a filename: ");
                    filename = Console.ReadLine();
                    journal.SaveToFile(filename);
                    break;
                
                case "5":
                    exit = true;
                    Console.WriteLine("Bye! Have a wonderful day!");
                    break;
                
                default:
                    Console.WriteLine("Invalid choice. Please try again");
                    Console.WriteLine("");
                    break;
            }
        }


        
    }
}