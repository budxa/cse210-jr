using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public void SetComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal: {GetDetailsString()} | {GetPoints()} | {_isComplete}";
    }

    public override string GetDetailsString()
    {
        return $"[{(_isComplete ? "X" : " ")}] {base.GetDetailsString()}";
    }
}
