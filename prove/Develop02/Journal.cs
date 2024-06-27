using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntries();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter input = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                input.WriteLine($"{entry._date} | {entry._promptText} | {entry._entryText}");
            }
        }
    }

    public void LoadFormFile(string file)
    {
        _entries.Clear();
        using (StreamReader output = new StreamReader(file))
        {
            string line;
            while ((line = output.ReadLine()) != null)
            {
                string[] parts = line.Split("|");
                Entry _entry = new Entry
                {
                    _date = parts[0],
                    _promptText = parts[1],
                    _entryText = parts[2],
                };
                _entries.Add(_entry);
            }
        }
    }
}