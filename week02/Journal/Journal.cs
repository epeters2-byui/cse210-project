using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// mThis will manage journal entries and handles JSON save/load operations.
public class Journal
{
    // For internal list of entries
    private List<Entry> _entries = new List<Entry>();

    // New new entry add to the journal
    public void AddEntry(Entry entry)
    {
        if (entry == null) return;
        _entries.Add(entry);
    }

    // This will remove all entries
    public void Clear()
    {
        _entries.Clear();
    }

    // This is for displaying entries to the console
    public void Display()
    {
        if (_entries == null || _entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        Console.WriteLine("--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    // This will save all entries to a JSON file
    public void SaveToFile(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
        {
            throw new ArgumentException("Filename cannot be empty.");
        }

        // This for serializing and with indentation for readability
        string jsonString = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });

        try
        {
            File.WriteAllText(filename, jsonString);
        }
        catch (Exception ex)
        {
            throw new IOException("Failed to write journal to file: " + ex.Message, ex);
        }
    }

    // This will load entries from a JSON file and replace current entries
    public void LoadFromFile(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
        {
            throw new ArgumentException("Filename cannot be empty.");
        }

        if (!File.Exists(filename))
        {
            throw new FileNotFoundException("File not found.", filename);
        }

        string jsonString;
        try
        {
            jsonString = File.ReadAllText(filename);
        }
        catch (Exception ex)
        {
            throw new IOException("Failed to read file: " + ex.Message, ex);
        }

        if (string.IsNullOrWhiteSpace(jsonString))
        {
            // This empty file -> empty journal
            _entries = new List<Entry>();
            return;
        }

        List<Entry> loaded = null;

        try
        {
            // This deserialize the JSON into a list of Entry objects
            loaded = JsonSerializer.Deserialize<List<Entry>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        catch (JsonException jex)
        {
            // Clear error about invalid JSON content will be provides
            throw new FormatException("The file does not contain valid journal JSON: " + jex.Message, jex);
        }

        // when deserialization returns null, treat as empty list; otherwise replace entries
        if (loaded == null)
        {
            _entries = new List<Entry>();
        }
        else
        {
            _entries = loaded;
        }
    }

    // Return a copy of all entries 
    public List<Entry> GetAllEntries()
    {
        return new List<Entry>(_entries);
    }
}
