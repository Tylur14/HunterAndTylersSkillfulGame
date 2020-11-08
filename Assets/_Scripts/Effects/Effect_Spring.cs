using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// https://twitter.com/3d_eric/status/1148486941907853312
/// Smooth springy looking vector affector... you heard me.
///
/// Features:
///  * Handles Vector manipulationg for:
///     |-> transform.position
///     |-> transform.rotation (converts with QEuler)
///     |-> transform.localScale
///     |-> rectTransform.anchoredPosition
///     |-> rectTransform.rotation
///     |-> rectTransform.sizeDelta
///  * Creates smooth spring effect that goes between active and inActive states
///  * Works with Time.timeScale set to zero
///  * WIP: looping (ping pong spring)
///
/// </summary>
public class Effect_Spring : MonoBehaviour
{
    public enum SpringOptions // Determine single transform Vector to affect
    {
        Mover,
        Scalar,
        Rotator
    }
    public enum TransformType // By default it's used on transform, but GUI affects rectTransform
    {
        WorldSpace,
        GUI
    }

    [Header("Spring Settings")]
    [SerializeField] private SpringOptions effectType;
    [SerializeField] private TransformType transformType;
    [Range(0.0f,1.0f)]
    [SerializeField] float springAmount = 0.15f;
    [Range(0.0f,30.0f)]
    [SerializeField] float springSpeed = 10.0f;
    public bool isActive;
    
    [Header("Effect Settings")]
    public Vector3 activeValue;
    public Vector3 inActiveValue;
    public bool canSpring;

    [Header("WIP Variables")] 
    public bool localMove;
    
    // Private Vector variables
    private Vector3 _value;
    private Vector3 _valueDir;

    private void Awake()
    {
        if (localMove)
        {
            var position = transform.position;
            activeValue += position;
            inActiveValue += position;
        }
        _valueDir = isActive ? activeValue : inActiveValue;
    }

    private void Update()
    {
        if (canSpring)
        {
            if(isActive)
                Spring(activeValue);
            else if(!isActive)
                Spring(inActiveValue);    
        }
        
    }

    public void TempToggle(float timer)
    {
        isActive = !isActive;
        StartCoroutine(toggle());
        IEnumerator toggle()
        {
            yield return new WaitForSeconds(timer);
            isActive = !isActive;
        }
    }

    void Spring(Vector3 target)
    {
        _value = Vector3.Lerp(_value, (target - _valueDir) * springAmount, springSpeed * Time.unscaledDeltaTime);
        _valueDir += _value;

        
        switch (effectType)
        {
            case SpringOptions.Mover:
                ApplyMove(_valueDir);
                break;
            case SpringOptions.Scalar:
                ApplyScale(_valueDir);
                break;
            case SpringOptions.Rotator:
                ApplyRotate(_valueDir);
                break;
        }
    }

    void ApplyScale(Vector3 incValue)
    {
        switch (transformType)
        {
            case TransformType.WorldSpace:
                this.transform.localScale = incValue;
                break;
            case TransformType.GUI:
                RectTransform rt = GetComponent<RectTransform>();
                rt.sizeDelta = incValue;
                break;
        }
        
    }

    void ApplyMove(Vector3 incValue)
    {
        switch (transformType)
        {
            case TransformType.WorldSpace:
                if (!localMove)
                    this.transform.position = incValue;
                else this.transform.localPosition = incValue;
                break;
            case TransformType.GUI:
                RectTransform rt = GetComponent<RectTransform>();
                rt.anchoredPosition = incValue;
                break;
        }
        
    }

    void ApplyRotate(Vector3 incValue)
    {
        switch (transformType)
        {
            case TransformType.WorldSpace:
                this.transform.rotation = Quaternion.Euler(incValue);
                break;
            case TransformType.GUI:
                RectTransform rt = GetComponent<RectTransform>();
                rt.rotation = Quaternion.Euler(incValue);
                break;
        }
        
    }
}
