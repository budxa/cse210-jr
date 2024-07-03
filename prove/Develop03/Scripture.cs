using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public Reference _reference;
    private List<Word> _words;


    public Scripture(Reference reference, string text)
    {
        _reference = reference ?? throw new ArgumentNullException(nameof(reference));
        _words = text.Split(' ').Select(Word => new Word(Word)).ToList() ?? throw new ArgumentNullException(nameof(text));
    }

    public void HideRandomWords(int numberToHide)
    {
        numberToHide = 3;
        Random _random = new Random();

        var hWords = _random.Next(numberToHide);
        var vWords = _words.Where(w => !w.IsHidden()).ToList();
        for (int i = 0; i < hWords && vWords.Count > 0; i++)
        {
            var wordToHide = vWords[_random.Next(vWords.Count)];

            wordToHide.Hide();
            vWords.Remove(wordToHide);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public string GetDisplayText()
    {
        string textReference = _reference.GetDisplayText();
        string textScripture = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{ textReference} \n { textScripture}";
    }
}
