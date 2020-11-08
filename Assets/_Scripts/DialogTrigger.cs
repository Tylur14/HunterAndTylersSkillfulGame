using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : Interactable
{
    [SerializeField] private string npcName;
    [SerializeField] private string npcBody;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && _cursorOver)
            TriggerDialog();
    }

    private void TriggerDialog()
    {
        print("trying to trigger!");
        if(IsPlayerInRange())
            FindObjectOfType<DialogBox>().InitDialogBox(this);
    }

    public Tuple<string,string> GetDialog()
    {
        return Tuple.Create(npcName, npcBody);
    }
}
