using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_SimpleParallax : MonoBehaviour
{
    // Need: track, elements, valueMods, 
    [SerializeField] private RectTransform header;
    [SerializeField] private RectTransform[] parallaxElements;
    [SerializeField] private float[] parallaxMods;

    [SerializeField] private float[] _startPositions;

    private void Start()
    {
        InitParallaxElements();
    }

    void InitParallaxElements()
    {
        for (int i = 0; i < parallaxElements.Length; i++)
        {
            _startPositions[i] = parallaxElements[i].anchoredPosition.y;
        }
    }

    private void Update()
    {
        for (int i = 0; i < parallaxElements.Length; i++)
        {
            float dist = (header.anchoredPosition.y * parallaxMods[i]);
            parallaxElements[i].anchoredPosition = new Vector2(parallaxElements[i].anchoredPosition.x, _startPositions[i]+dist);    
        }
        
    }
}
