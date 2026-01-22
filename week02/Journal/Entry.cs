using System;

public class Entry
{
    public string _date = "";
    public string _prompt = "";
    public string _text = "";

    public Entry() { }

    public Entry(string prompt, string text)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _prompt = prompt;
        _text = text;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Entry: {_text}");
        Console.WriteLine(new string('-', 40));
    }

    public string ToSaveString()
    {
        string safeText = _text.Replace("\r\n", "\n").Replace("\n", "\\n");
        string safePrompt = _prompt.Replace("\r\n", "\n").Replace("\n", "\\n");
        return $"{_date}~|~{safePrompt}~|~{safeText}";
    }

    public static Entry FromSaveString(string line)
    {
        string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);
        if (parts.Length >= 3)
        {
            Entry e = new Entry();
            e._date = parts[0];
            e._prompt = parts[1].Replace("\\n", "\n");
        
            string joined = string.Join("~|~", parts, 2, parts.Length - 2);
            e._text = joined.Replace("\\n", "\n");
            return e;
        }
        else
        {
            return new Entry();
        }
    }
}

