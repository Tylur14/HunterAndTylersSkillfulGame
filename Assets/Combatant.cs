using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    [SerializeField] private string combatantName; // for display purposes
    [SerializeField] private int team; // player is always team 0 (zero)
 
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    
    [SerializeField] private int currentEnergy; // Used for physical spells
    [SerializeField] private int maxEnergy;
    
    [SerializeField] private int currentMana;   // Used for magical spells
    [SerializeField] private int maxMana;
    
}
