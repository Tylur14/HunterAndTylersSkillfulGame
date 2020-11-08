using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Skill[] skills;
    [Header("Player Defaults")] 
    [SerializeField] private Texture2D defaultCursor;
    public static Texture2D playerDefaultCursor;

    public bool Test { get; set; }

    private void Awake()
    {
        Test = false;
        playerDefaultCursor = defaultCursor;
    }

    public Skill[] GetCopyOfSkills()
    {
        var s = skills;
        return s;
    }
}
