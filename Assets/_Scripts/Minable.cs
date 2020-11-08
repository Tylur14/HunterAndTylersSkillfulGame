using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Minable : Interactable
{
    [Header("Minable Status")]
    [SerializeField] private int state;
    [Header("Minable Settings")]
    [SerializeField] private bool doSpriteChange = true;
    [SerializeField] private bool doDropItems = true;
    [SerializeField] private GameObject dropItem;
    [SerializeField] private Vector2 stateRange;
    [SerializeField] private Sprite[] stateSprites;

    [Header("Extra Function Calls")] 
    [SerializeField] private UnityEvent hitCalls;

    private SpriteRenderer _render;
    private SpriteMask _mask;

    private void Awake()
    {
        _render = GetComponent<SpriteRenderer>();
        _mask = GetComponent<SpriteMask>();
        
        if(doSpriteChange)
            _render.sprite = stateSprites[state];
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1) && _cursorOver)
            BreakDown();
    }

    
    // todo - add quantity control to each break
    // todo - add multiple hits to affect a state (hp)
    // todo - add variety to item drop pool
    public void BreakDown()
    {
        
        if (CanBreakDown())
        {
            if (IsPlayerInRange()) // to prevent EVERY interactable running their most expensive check
            {
                hitCalls.Invoke();
                if (doDropItems && dropItem)
                    Instantiate(dropItem, transform.position, Quaternion.identity);
                state++;
                if (state >= stateRange.y + 1)
                {
                    SetCursorToDefault();
                    Destroy(this.gameObject);
                }
                else
                {
                    if (doSpriteChange)
                    {
                        _render.sprite = stateSprites[state];
                        if(_mask)
                            _mask.sprite = _render.sprite;
                    }
                }
                    
            }
            
            // instantiate new object(s)
        }
    }
    
    bool CanBreakDown()
    {
        if (state >= stateRange.y+1)
            return false;
        else return true;
    }
}
