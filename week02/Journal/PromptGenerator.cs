using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>()
    {
        "What was the best part of your day?",
        "What is something you learned today?",
        "Who did you talk to today?",
        "What made you smile today?",
        "What is one goal you have for tomorrow?"
    };

    private Random _rand = new Random();

    public PromptGenerator() { }

    public string GetRandomPrompt()
    {
        int idx = _rand.Next(0, _prompts.Count);
        return _prompts[idx];
    }
}
