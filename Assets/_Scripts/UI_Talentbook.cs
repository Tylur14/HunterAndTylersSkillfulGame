using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Talentbook : MonoBehaviour
{
    [SerializeField] private GameObject selectedBubble; // The bubble on the side of the talent book that indicates which page is selected
    private Effect_Spring _bubbleSpring;
    [SerializeField] private SpriteRenderer backgroundRenderer;

    [SerializeField] private GameObject displayFooter;
    [SerializeField] private TextMeshProUGUI levelDisplay;
    [SerializeField] private TextMeshProUGUI expDisplay;
    [SerializeField] private TextMeshProUGUI talentPointCountDisplay;
    [SerializeField] private Image experienceFillBar;

    private Player p;
    public void ChangeBubble(GameObject newBubble)
    {
        if (newBubble != selectedBubble)
        {
            // If there is something already selected, deselect it
            if(_bubbleSpring)
                _bubbleSpring.isActive = false;
            
            // Set the selected bubble to the incoming bubble 
            selectedBubble = newBubble;
            _bubbleSpring = selectedBubble.GetComponent<Effect_Spring>();
            
            // Enable the spring if possible, if not print out an error
            if(_bubbleSpring)
                _bubbleSpring.isActive = true;
            else Debug.LogError("Spring not found!");

        }
    }

    public void LookupSkill(string skillToLookup)
    {
        // look through the player object and find the associated skill!
    }

    void InitTalentBook()
    {
        var skills = p.GetCopyOfSkills();
        foreach(Skill s in skills)
        {
            
        }
    }

    void InitSkillDisplay()
    {
        displayFooter.SetActive(true);
    }

    void UpdateDisplay()
    {
        // Get Skill name
        // Get Skill spells
        // Get Skill level
        // Get Skill currentExp
        // Get Skill reqExp
        // Get Skill talentPoint#
    }

    private void OnEnable()
    {
        if (!p)
            p = FindObjectOfType<Player>();
        InitTalentBook();
        
    }
}
