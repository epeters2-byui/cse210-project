// A repeatable goal for awards points each time and never completes.

using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent()
    {
        Console.WriteLine($"[Eternal] Recorded '{_name}'. +{_points} points.");
        return _points;
    }

    public override bool IsComplete() => false;

    public override string GetStatus() => $"[∞] {_name} - {_description}";

    public override string Serialize() => $"Eternal|{Escape(_name)}|{Escape(_description)}|{_points}";

    private string Escape(string s) => s?.Replace("|", "¦") ?? "";
}
