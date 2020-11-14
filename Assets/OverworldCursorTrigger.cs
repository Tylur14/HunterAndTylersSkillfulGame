using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OverworldCursorTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent mouseOverEvents;
    [SerializeField] private UnityEvent mouseExitEvents;

    private void OnMouseEnter()
    {
        mouseOverEvents.Invoke();
    }

    private void OnMouseExit()
    {
        mouseExitEvents.Invoke();
    }
}
