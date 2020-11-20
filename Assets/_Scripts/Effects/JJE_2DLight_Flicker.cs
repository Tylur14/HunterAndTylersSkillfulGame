using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;
using Random = UnityEngine.Random;

/// <summary>
/// The Jim Jam Effects Library
/// WIP 2D Light Flicker Effect
/// Make a 2d light flicker to create atomospheric areas like a campfire!
///
/// Features:
/// |- Instant intensity change, WIP, looping
///
/// Note: Requires that your project is using 2D Lights, I think currently it's only working for Universal 2D? Should work the same for LWRP but with different refs
/// </summary>

public class JJE_2DLight_Flicker : MonoBehaviour
{
    [SerializeField] private Light2D targetLight;
    [Range(0.05f,5f)]
    [SerializeField] private float snapSpeed = 1f;
    [Range(0.05f,5f)]
    [SerializeField] private float retractSpeed = 1f;
    [SerializeField] private Vector2 flickerRateRange;
    [SerializeField] private Vector2 flickerIntensityRange;

    [Header("Events")]
    [SerializeField] private UnityEvent snapEvents;
    //[SerializeField] private UnityEvent retractEvents;
    
    [Header("Debugging")]
    [SerializeField] private float testFlicker;
    [SerializeField] private float elapsedTime;
    [SerializeField] private float ratio;
    [SerializeField] private float duration;

    private void Awake()
    {
        targetLight = GetComponent<Light2D>();
        StartCoroutine(TestLoop());
    }

    IEnumerator TestLoop()
    {
        testFlicker *= -1;
        var flicker = testFlicker;
        if (flicker < 0)
            flicker = flickerIntensityRange.x;
        
        float e = 0;
        float r = e / duration;
        while(r < 1f)
        {
            elapsedTime = e;
            ratio = r;
            e += Time.deltaTime;
            r = e / duration;     
            targetLight.intensity = Mathf.Lerp(targetLight.intensity,flicker,ratio * Time.deltaTime * snapSpeed);
            yield return null;
        }
        snapEvents.Invoke();
        bool lightCheck = targetLight.intensity > flickerIntensityRange.x; 
        while (lightCheck)
        {
            targetLight.intensity = Mathf.Lerp(targetLight.intensity,flickerIntensityRange.x,Time.deltaTime * retractSpeed);
            if (targetLight.intensity - 0.05f <= flickerIntensityRange.x)
                lightCheck = false;
            yield return null;
        }
        float waitTime = Random.Range(flickerRateRange.x, flickerRateRange.y);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(TestLoop());
    }
    
    IEnumerator DoFlickerLoop()
    {
        float waitTime = Random.Range(flickerRateRange.x, flickerRateRange.y);
        float flicker = Random.Range(flickerIntensityRange.x, flickerIntensityRange.y);
        while (waitTime > 0)
        {
            //https://answers.unity.com/questions/1111308/unity-coroutine-movement-over-time-is-not-consiste.html
            // ^- Not 100% sure what it does but it makes it work
            float elapsedTime = 0;
            float ratio = elapsedTime / 1;
            while(ratio < 1)
            {
                elapsedTime += Time.fixedDeltaTime;
                ratio = elapsedTime / 1;
                waitTime -= Time.fixedDeltaTime;
                targetLight.intensity = Mathf.Lerp(targetLight.intensity,flicker,Time.deltaTime);
                yield return null;
            }
        }
        StartCoroutine(DoFlickerLoop());
    }
}
