using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Land of Kings Player Inventory System
/// Current max quantity for backpack: 25 items
///    ? Wondering about storing Player Chest items in this class as well
/// 
/// Items held and take space up in the inventory:
///     |-> Armor, Weapons, & Tools
///     |-> World Progression Items (I.e. shears to cut the rope on a bridge)
///     |-> Foraged & Mined Items (I.e. iron ore, plant fibers, wooden planks)
/// Items that are collected but take up NO SPACE in the inventory:
///     |-> Quest items (I.e NPC X wants you to collect 10 Bear Pelts, they are implied to be collected but cannot be interacted with once gathered)
/// </summary>
    
    
public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameObject[] itemSlots;
    [SerializeField] private List<Item> items = new List<Item>();
    
    [SerializeField] private Item debugAddItem;

    private int _slotsFree;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha9))
            Debug_AddTestItem();
    }

    void Debug_AddTestItem()
    {
        itemSlots[0].tag = "Inv_Slot_Filled"; // works
        var info = debugAddItem.GetInvDisplayInfo(); // works
        itemSlots[0].transform.GetChild(1).GetComponent<Image>().sprite = info.Item1; // fails because it grabs the bg sprite, attempting hardcode fix
    }

    public void ProcessMouseOverSlot(GameObject g)
    {
        
    }

    public void ClearMouseOverSlot()
    {
        
    }
    // AddItem()
    // RemoveItem()
    // MoveItem()
}
