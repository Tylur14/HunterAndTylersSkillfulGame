using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private enum SpellTypes
    {
        Unarmed,
        Swords,
        Bows,
        Mystic,
        Imbuing,
        Summoning
    }

    [SerializeField] private string spellName;
    [SerializeField] private SpellTypes spellType;

    [Header("Display Settings")]
    [SerializeField] private Sprite spellIcon;
    
    [Header("General Settings")] 
    [SerializeField] private int damageAmount;
    [SerializeField] private GameObject useEffect;

    [Header("Physical Settings")] 
    [SerializeField] private int energyCost;

    [Header("Magic Settings")] 
    [SerializeField] private int manaCost;

    void CastSpell()
    {
        // at some point the target should be determined
        // Instantiate useEffect
        // make sure useEffect is properly located on the target's location
        // Reduce user's mana/energy by manaCost/energyCost
    }
}