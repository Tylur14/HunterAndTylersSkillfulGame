using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Interaction Settings")] 
    [SerializeField] private Texture2D onHoverCursorGFX;
    [SerializeField] private float maxPlayerDistance;
    protected bool _cursorOver;
    
    private void OnMouseEnter()
    {
        Cursor.SetCursor(onHoverCursorGFX,Vector2.zero,CursorMode.Auto);
        _cursorOver = true;
    }

    private void OnMouseExit()
    {
        SetCursorToDefault();
    }

    protected void SetCursorToDefault()
    {
        Cursor.SetCursor(Player.playerDefaultCursor,Vector2.zero,CursorMode.Auto);
        _cursorOver = false;
    }

    protected bool IsPlayerInRange()
    {
        // ! This is made for a 2D game so 'z' is ignored
        Transform p = GameObject.FindWithTag("Player").transform;
        if (Vector2.Distance(this.transform.position, p.position) < maxPlayerDistance)
            return true;
        else return false;
    }
    
    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,maxPlayerDistance);
    }
#endif
}
