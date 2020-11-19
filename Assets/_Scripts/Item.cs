using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        ActionItem,
        Tool,
        Weapon,
        Armor
    }
    
    // What's needed for display box
    [SerializeField] private string itemName;
    [SerializeField] private int[] modifiers = new int[5]; // STR, INT, DEX, DEF, SPEED
    [SerializeField] private string itemDescription;

    // What's needed for inventory display
    [SerializeField] private Sprite itemIcon;
    [SerializeField] private int itemQuantity = 1;

    public Tuple<string, int[], string> GetDisplayBoxInfo()
    {
        return new Tuple<string, int[], string>(itemName,modifiers,itemDescription);
    }
    
    public Tuple<Sprite,int> GetInvDisplayInfo()
    {
        return new Tuple<Sprite, int>(itemIcon,itemQuantity);
    }

}
