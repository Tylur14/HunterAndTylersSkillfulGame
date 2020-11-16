using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI headText;
    private TextMeshProUGUI[] _textObjs;

    private void Awake()
    {
        _textObjs = GetComponentsInChildren<TextMeshProUGUI>();
    }

    public virtual void SetText(string incText, string bodyText = "")
    {
        ToggleTextObjs(true);
        headText.text = incText;
    }

    public void CloseText()
    {
        ToggleTextObjs(false);
    }

    void ToggleTextObjs(bool state)
    {
        foreach (var t in _textObjs)
            t.enabled = state;
    }
}
