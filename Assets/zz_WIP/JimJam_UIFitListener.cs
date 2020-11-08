using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimJam_UIFitListener : MonoBehaviour
{
    private RectTransform _rect;
    private JimJam_UIFitter _fitterParent;

    private void Awake()
    {
        InitListener();
        _fitterParent.ResizeObject(_rect);
    }

    void InitListener()
    {
        _rect = GetComponent<RectTransform>();
        _fitterParent = GetComponentInParent<JimJam_UIFitter>();
        if (_fitterParent)
            _fitterParent.lastUsedListener = this;
        
        if (_rect == null)
            Debug.LogError("Object: [" + gameObject.name + "] does not have a RectTransform!");
        if (_fitterParent == null)
            Debug.LogError("Object: [" + gameObject.name + "] does not have a JimJam_UIFitter!");
    }
    
    #if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        print("size changing!");
        _fitterParent.ResizeObject(_rect);
    }

    private void OnValidate()
    {
        if (!_rect || !_fitterParent || !_fitterParent.lastUsedListener)
        {
            InitListener();
        }
        _fitterParent.ResizeObject(_rect);
    }
#endif
}
