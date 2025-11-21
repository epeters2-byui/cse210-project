using System;
using System.Text.Json;

public class Entry
{
    // Stores when date and time when the entry was created
    public string DateTimeStamp { get; set; }

    // This the prompt shown to the user
    public string Prompt { get; set; }

    // For user's written response
    public string Response { get; set; }

    // For user's mood or emotional state for the entry
    public string Mood { get; set; }

    // Constructor required for JSON deserialization
    public Entry()
    {
        DateTimeStamp = "";
        Prompt = "";
        Response = "";
        Mood = "";
    }

    // Main constructor used when creating a new entry 
    public Entry(string prompt, string response, string mood)
    {
        DateTimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm"); // include time
        Prompt = (prompt ?? "");
        Response = (response ?? "");
        Mood = (mood ?? "");
    }

    // Return readable string for console display
    public override string ToString()
    {
        return $"Date: {DateTimeStamp}\nPrompt: {Prompt}\nResponse: {Response}\nMood: {Mood}\n";
    }

    // This convert this Entry to a JSON string
    public string ToJson(JsonSerializerOptions options = null)
    {
        if (options == null)
        {
            options = new JsonSerializerOptions { WriteIndented = false };
        }
        return JsonSerializer.Serialize(this, options);
    }

    // Create an Entry from a JSON string (returns an empty Entry for null/invalid input)
    public static Entry FromJson(string json, JsonSerializerOptions options = null)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return new Entry();
        }

        if (options == null)
        {
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        try
        {
            Entry result = JsonSerializer.Deserialize<Entry>(json, options);
            if (result == null) return new Entry();
            return result;
        }
        catch (JsonException)
        {
            // If JSON is not valid, return an empty Entry instead of throwing to let the caller decide
            return new Entry();
        }
    }
}
