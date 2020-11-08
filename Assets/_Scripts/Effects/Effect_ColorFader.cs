using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect_ColorFader : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private Vector2 fadeRange;
    [SerializeField] private float fadeSpeed;


    private void Update()
    {
        Color c = img.color;
        if (c.a > fadeRange.y)
        {
            c.a -= fadeSpeed * Time.deltaTime;
            img.color = c;
        }
    }
}
