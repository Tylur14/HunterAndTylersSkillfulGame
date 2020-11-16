using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetailedHudDisplay : HudDisplay
{
    [SerializeField] private TextMeshProUGUI bodyText;
    public override void SetText(string hT, string bT)
    {
        base.SetText(hT,"");
        bodyText.text = bT;
    }
}
