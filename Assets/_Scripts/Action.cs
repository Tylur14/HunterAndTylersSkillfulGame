using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Action : MonoBehaviour
{
    public string actionDescription;
    public UnityEvent interaction;

    public virtual void Interact()
    {
        interaction.Invoke();
        
    }
    
}
