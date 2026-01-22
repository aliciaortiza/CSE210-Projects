using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public Journal() { }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        Console.WriteLine("\n--- Journal Entries ---\n");
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet.");
        }
        else
        {
            foreach (Entry e in _entries)
            {
                e.Display();
            }
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry e in _entries)
                {
                    outputFile.WriteLine(e.ToSaveString());
                }
            }
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            List<Entry> loaded = new List<Entry>();
            foreach (string line in lines)
            {
                Entry e = Entry.FromSaveString(line);
                loaded.Add(e);
            }

            _entries = loaded;
            Console.WriteLine($"Journal loaded from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}
