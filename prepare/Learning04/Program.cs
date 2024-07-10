using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Jerald", "Mathematics");
        Console.WriteLine(assignment1.GetSummary());

        Assignment assignment2 = new Assignment();
        assignment2.SetName("Dante");
        assignment2.SetTopic("Electrons");
        Console.WriteLine(assignment2.GetSummary());

        MathAssignment mathAssignment = new MathAssignment("James", "Fractions", "7.85", "8-11");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeWorkList());

        WritingAssignment writingAssignment = new WritingAssignment("Ian", "European History","The Cold War");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());

    }
}