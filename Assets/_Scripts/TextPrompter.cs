using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPrompter : MonoBehaviour
{
    public enum PromptGenerics
    {
        TooFarAway,
        OOM
    };

    public Dictionary<string, string> promptDictionary = new Dictionary<string, string>();
    
    void Start()
    {
        InitDictionary();
        Alert(PromptGenerics.TooFarAway);
    }

    void Alert(PromptGenerics prompt)
    {
        // coroutine
        // while timer > maxTime, do countdown and keep text visible
        // while text is visible, fade it
        // stop
    }

    void InitDictionary()
    {
        promptDictionary.Add("TooFarAway", "That's too far away...");
    }
}

