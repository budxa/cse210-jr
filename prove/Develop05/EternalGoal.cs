using System;

public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
        
    }

    public override void RecordEvent()
    {
        // Eternal goals are never complete, just add points.
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"Eternal: {GetDetailsString()} | {GetPoints()}";
    }

    public override string GetDetailsString()
    {
        return $"[ ] {base.GetDetailsString()}";
    }
}
