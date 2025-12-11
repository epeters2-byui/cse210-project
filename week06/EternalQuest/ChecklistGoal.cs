// It is a goal that requires several occurrences to complete and awards a bonus when finished.

using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (_currentCount >= _targetCount)
        {
            Console.WriteLine($"[Checklist] '{_name}' already completed ({_currentCount}/{_targetCount}).");
            return 0;
        }

        _currentCount++;
        int awarded = _points;
        Console.WriteLine($"[Checklist] Progress '{_name}': {_currentCount}/{_targetCount}. +{_points} points.");

        if (_currentCount == _targetCount)
        {
            awarded += _bonusPoints;
            Console.WriteLine($"[Checklist] Completed '{_name}'! Bonus +{_bonusPoints} points.");
        }

        return awarded;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus() => $"{(IsComplete() ? "[X]" : "[ ]")} {_name} - {_description} (Completed {_currentCount}/{_targetCount})";

    public override string Serialize() => $"Checklist|{Escape(_name)}|{Escape(_description)}|{_points}|{_targetCount}|{_bonusPoints}|{_currentCount}";

    private string Escape(string s) => s?.Replace("|", "¦") ?? "";
}
