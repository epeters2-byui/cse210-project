// Manages goal list, score, leveling, badges, and saving/loading.

using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _totalScore = 0;
    private int _level = 1;
    private HashSet<string> _badges = new HashSet<string>();

    public IReadOnlyList<Goal> Goals => _goals.AsReadOnly();
    public int TotalScore => _totalScore;
    public int Level => _level;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void DisplayGoals()
    {
        if (_goals.Count == 0) { Console.WriteLine("No goals created."); return; }
        Console.WriteLine("--- Your Goals ---");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
    }

    public void RecordGoalEvent(int oneBasedIndex)
    {
        int index = oneBasedIndex - 1;
        if (index < 0 || index >= _goals.Count) { Console.WriteLine("Invalid selection."); return; }

        Goal goal = _goals[index];
        int awarded = goal.RecordEvent(); // Polymorphism in action
        _totalScore += awarded;
        CheckLevelUp();
        CheckBadges();
    }

    private void CheckLevelUp()
    {
        int threshold = _level * 1000;
        while (_totalScore >= threshold)
        {
            _level++;
            Console.WriteLine($"*** Level Up! You reached Level {_level}! ***");
            threshold = _level * 1000;
        }
    }

    private void CheckBadges()
    {
        if (_totalScore >= 500 && !_badges.Contains("Bronze")) { _badges.Add("Bronze"); Console.WriteLine("*** Badge: Bronze Achiever (500) ***"); }
        if (_totalScore >= 2000 && !_badges.Contains("Silver")) { _badges.Add("Silver"); Console.WriteLine("*** Badge: Silver Achiever (2000) ***"); }
        if (_totalScore >= 5000 && !_badges.Contains("Gold")) { _badges.Add("Gold"); Console.WriteLine("*** Badge: Gold Achiever (5000) ***"); }
    }

    public void ShowScoreAndBadges()
    {
        Console.WriteLine($"Score: {_totalScore} pts | Level: {_level}");
        if (_badges.Count > 0) Console.WriteLine("Badges: " + string.Join(", ", _badges));
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"SCORE|{_totalScore}|{_level}");
            writer.WriteLine($"BADGES|{string.Join(",", _badges)}");
            foreach (Goal g in _goals) writer.WriteLine(g.Serialize());
        }
        Console.WriteLine($"Saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename)) { Console.WriteLine("Save file not found."); return; }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();
        _badges.Clear();
        _totalScore = 0;
        _level = 1;

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            string[] parts = line.Split('|');

            if (parts[0] == "SCORE") { _totalScore = int.Parse(parts[1]); _level = int.Parse(parts[2]); continue; }
            if (parts[0] == "BADGES") { if (parts.Length > 1) { foreach (string b in parts[1].Split(',', StringSplitOptions.RemoveEmptyEntries)) _badges.Add(b); } continue; }

            string type = parts[0];
            if (type == "Simple")
            {
                var sg = new SimpleGoal(Unescape(parts[1]), Unescape(parts[2]), int.Parse(parts[3]));
                if (bool.Parse(parts[4])) sg.RecordEvent(); // mark completed
                _goals.Add(sg);
            }
            else if (type == "Eternal") _goals.Add(new EternalGoal(Unescape(parts[1]), Unescape(parts[2]), int.Parse(parts[3])));
            else if (type == "Checklist")
            {
                var cg = new ChecklistGoal(Unescape(parts[1]), Unescape(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                for (int i = 0; i < int.Parse(parts[6]); i++) cg.RecordEvent();
                _goals.Add(cg);
            }
        }

        Console.WriteLine($"Loaded from {filename}");
    }

    private string Unescape(string s) => s?.Replace("¦", "|") ?? "";
}
