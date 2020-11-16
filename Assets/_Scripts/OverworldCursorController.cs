using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class OverworldCursorController : MonoBehaviour
{
    [SerializeField] private HudDisplay entityDisplay; 
    [SerializeField] private HudDisplay actionDisplay;
    private HudDisplay _activeDisplay;

    public bool mouseOverGui = false;
    private void Update()
    {
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
                    if(a)
                        actionDisplay.SetText(a.actionDescription);
                }            
                else if (hit.collider.CompareTag("Entity"))
                {
                    if (actionDisplay.isActiveAndEnabled)
                        actionDisplay.gameObject.SetActive(false);
                
                    _activeDisplay = entityDisplay;
                    _activeDisplay.gameObject.SetActive(true);
                    var e = hit.collider.GetComponent<Entity>();
                    if(e)
                        entityDisplay.SetText(e.entityName,e.entityDescription);
                }
            
            }   
            else
                DisableActiveDisplay(); 
        }
        else
            DisableActiveDisplay();
    }
    
    void DisableActiveDisplay()
    {
        if (_activeDisplay)
        {
            _activeDisplay.gameObject.SetActive(false);
            _activeDisplay = null;
        }
    }
}
