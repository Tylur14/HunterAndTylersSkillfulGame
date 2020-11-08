using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Effect_SelfDestruct : MonoBehaviour
{
    [SerializeField] private float destructTimer;
    [SerializeField] private bool autoStartDestruct;
    
    private void Start()
    {
        if (autoStartDestruct)
            StartCoroutine(Destruct());
    }

    public void TriggerDestruct()
    {
        StartCoroutine(Destruct());
    }

    IEnumerator Destruct()
    {
        yield return new WaitForSeconds(destructTimer);
        Destroy(this.gameObject);
    }
}
