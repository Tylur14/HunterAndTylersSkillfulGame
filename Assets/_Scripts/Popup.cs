using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Popup : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fadeSpeed;
    
    [SerializeField] protected  TextMeshPro displayText;
    private SpriteRenderer _renderer;

    public Popup(string text, Sprite icon = null)
    {
        displayText.text = text;
        if(icon)
            _renderer.sprite = icon;
    }
    
    private void Awake()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        displayText = GetComponentInChildren<TextMeshPro>();
        Transform player = GameObject.FindWithTag("Player").transform;
        if (player)
            transform.position = player.position;
        
        // Randomize Starting Position
        var pos = transform.position;
        pos.x += Random.Range(-1f, 1f);
        transform.position = pos;
    }
    
    private void FixedUpdate()
    {
        Move();
        Fade();
    }

    void Fade()
    {
        displayText.alpha -= fadeSpeed * Time.deltaTime;
        if (_renderer)
        {
            Color c = _renderer.color;
            c.a -= fadeSpeed * Time.deltaTime;
            _renderer.color = c;    
        }
        
    }
    
    void Move()
    {
        var pos = transform.position;
        pos.y += moveSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
