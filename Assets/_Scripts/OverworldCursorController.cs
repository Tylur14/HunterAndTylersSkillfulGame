using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class OverworldCursorController : MonoBehaviour
{
    [Header("GUI Interactions")]
    [SerializeField] private HudDisplay armorWepDisplay;
    [SerializeField] private HudDisplay itemDisplay;
    
    [Header("Non-GUI Interactions")]
    [SerializeField] private HudDisplay entityDisplay; 
    [SerializeField] private HudDisplay actionDisplay;
    private Action _currentlyHighlightedAction;
    private Entity _currentlyHighlightedEntity;
    private HudDisplay _activeDisplay;

    
    public bool mouseOverGui = false;
    private void Update()
    {
        // Handle interactions
        if(Input.GetMouseButtonDown(1) && _currentlyHighlightedAction)
            _currentlyHighlightedAction.Interact();
        
        // Handle mouse overs
        if (!mouseOverGui)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit.collider)
            {
                if(hit.collider.CompareTag("Action"))
                {
                    if (entityDisplay.isActiveAndEnabled)
                        entityDisplay.gameObject.SetActive(false);
                
                    _activeDisplay = actionDisplay;
                    _activeDisplay.gameObject.SetActive(true);
                    var a = hit.collider.GetComponent<Action>();
                    if (_currentlyHighlightedAction != a)
                    {
                        ChangeOrDisableHighlight(false);
                        _currentlyHighlightedAction = a;
                        if(a)
                            actionDisplay.SetText(a.actionDescription);    
                    }
                    
                }            
                else if (hit.collider.CompareTag("Entity"))
                {
                    if (actionDisplay.isActiveAndEnabled)
                        actionDisplay.gameObject.SetActive(false);
                
                    _activeDisplay = entityDisplay;
                    _activeDisplay.gameObject.SetActive(true);
                    var e = hit.collider.GetComponent<Entity>();
                    if (_currentlyHighlightedEntity != e)
                    {
                        ChangeOrDisableHighlight(false);
                        _currentlyHighlightedEntity = e;
                        if(e)
                            entityDisplay.SetText(e.entityName,e.entityDescription);   
                    }
                }
            }   
            else
                ChangeOrDisableHighlight(); 
        }
        else
            ChangeOrDisableHighlight();
    }
    
    void ChangeOrDisableHighlight(bool fullClear = true)
    {
        if(_currentlyHighlightedAction)
            _currentlyHighlightedAction = null;
        if(_currentlyHighlightedEntity)
            _currentlyHighlightedEntity = null;
        if (fullClear)
        {
            if (_activeDisplay)
            {
                _activeDisplay.gameObject.SetActive(false);
                _activeDisplay = null;
            }    
        }
        
    }

    public void StartGuiInteraction(int index)
    {
        ChangeOrDisableHighlight();
        Item.ItemType type = Item.ItemType.Armor;
        switch (type)
        {
            case(Item.ItemType.Armor):
                _activeDisplay = armorWepDisplay;
                break;
            case(Item.ItemType.Weapon):
                _activeDisplay = armorWepDisplay;
                break;
            case(Item.ItemType.Tool):
                _activeDisplay = itemDisplay;
                break;
            case(Item.ItemType.ActionItem):
                _activeDisplay = itemDisplay;
                break;
        }
        _activeDisplay.gameObject.SetActive(true);
    }

    public void MoveGuiWindow()
    {
        if(_activeDisplay)
            _activeDisplay.transform.position = Input.mousePosition;
    }

    public void StopGuiInteraction()
    {
        ChangeOrDisableHighlight();   
    }
    
}
