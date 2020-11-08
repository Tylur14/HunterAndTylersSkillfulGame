using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TESTING : MonoBehaviour
{
    [SerializeField] private Effect_Spring spring;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            spring.isActive = true;
    }

    // STAT STRING REPLACEMENT FUNCTION
    /*
    [SerializeField] private int baseAmount;
    [SerializeField] private int armorContributionAmount;
    [SerializeField] private TextMeshProUGUI textObj;

    public void ApplyStatString()
    {
        string s = textObj.text; // Get string
        s = s.Replace("$b", baseAmount.ToString());                             // The base amount that would be from the player stat
        s = s.Replace("$a", armorContributionAmount.ToString());                // The amount for the specific stat gained from armor
        s = s.Replace("$t", (baseAmount + armorContributionAmount).ToString()); // The total amount of both prior amounts combined
        textObj.text = s;        // Apply string to textObj
    }
    */
}
