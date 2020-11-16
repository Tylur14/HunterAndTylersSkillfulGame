using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GuiTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private OverworldCursorController _cursorController;

    private void Awake()
    {
        _cursorController = FindObjectOfType<OverworldCursorController>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_cursorController)
            _cursorController.mouseOverGui = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_cursorController)
            _cursorController.mouseOverGui = false;
    }
}
