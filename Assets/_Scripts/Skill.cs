using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// This Skill class will hold all the information for each of the 12 core skill categories for this game.
/// The 12 skill categories are as follow: Unarmed, Swords, Bows, Mystic, Imbuing, Summoning               [these are Combat Skills]
///                                        Mining, Foraging, Fishing, Detection, Negotiation, and Building [these are non-combat]
///
/// 
/// Each skill will contain a number of spells associated with that skill. Using the spells or interacting
/// |- with certain world objects will train these skills and level them up allowing for talent points to
/// |- be used on upgrades.
/// 
/// 9 spells for Combat Skills, 6 single rank active spells and 3 passive spells
/// The spell count from non-combat skills are currently undetermined
/// </summary>
public class Skill : MonoBehaviour
{
    
    [SerializeField] private Spell[] skillSpells; // Currently will hold all spells associated with each Skill
    [SerializeField] private string skillName;
    
    [SerializeField] private int skillLevel;
    [SerializeField] private int maxSkillLevel;
    
    [SerializeField] private int skillExperience;
    [SerializeField] private int maxSkillExperience;
    
    [SerializeField] private int skillTalentPoints;
    [Header("Display Settings")]
    [SerializeField] private Sprite skillIcon;
    [SerializeField] private Sprite skillBackgroundImage;
}
