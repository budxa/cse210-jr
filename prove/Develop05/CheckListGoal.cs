﻿using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus) : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public void SetAmount(int amount)
    {
        _amountCompleted = amount;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist: {GetDetailsString()} | {GetPoints()} | {_amountCompleted} | {_target} | {_bonus}";
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {base.GetDetailsString()} (Completed {_amountCompleted}/{_target} times)";
    }
}
