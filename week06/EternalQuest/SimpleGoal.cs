// This is goal that can be completed once and awards points one time.

using System;

public class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isCompleted = false;
    }

    public override int RecordEvent()
    {
        if (_isCompleted)
        {
            Console.WriteLine($"[Simple] '{_name}' already completed.");
            return 0;
        }

        _isCompleted = true;
        Console.WriteLine($"[Simple] Completed '{_name}'. +{_points} points.");
        return _points;
    }

    public override bool IsComplete() => _isCompleted;

    public override string GetStatus() => $"{(_isCompleted ? "[X]" : "[ ]")} {_name} - {_description}";

    public override string Serialize() => $"Simple|{Escape(_name)}|{Escape(_description)}|{_points}|{_isCompleted}";

    private string Escape(string s) => s?.Replace("|", "¦") ?? "";
}
