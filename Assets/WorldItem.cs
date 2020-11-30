using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : Action
{
    [SerializeField] private Item item;
    [SerializeField] private PlayerInventory _inventory;

    private void Awake()
    {
        _inventory = FindObjectOfType<PlayerInventory>();
    }

    public override void Interact()
    {
        _inventory.Debug_AddTestItem(item);
        base.Interact();
    }
}
